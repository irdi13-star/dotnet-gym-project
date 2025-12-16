
using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Actions;
using PlaywrightTests.CSharp.Utils;
using NUnit.Framework;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Allure.Steps;

namespace PlaywrightTests.CSharp.Tests;

[TestFixture]
[Category("regression")]
[Category("home")]
[AllureNUnit]
public class HomeTests : BaseTest
{
    [SetUp]
    public async Task SetUp()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });
        _page = await _browser.NewPageAsync();

        await _page.Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Test.Step("Navigate to MADGYM Home page", async () =>
        {
            await App.Base.NavigateTo(Routes.HomeLinks.Home);
            await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
            await App.Common.BrowserTabTitleAsExpected(Strings.Home.HomeBrowserTitle);
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        var outcome = TestContext.CurrentContext.Result.Outcome.Status;
        if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            // Screenshot la fail
            var screenshotPath = $"Screenshots/{TestContext.CurrentContext.Test.Name}.png";
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });
            AllureLifecycle.Instance.AddAttachment(
                TestContext.CurrentContext.Test.Name,
                "image/png",
                screenshotPath
            );
        }

        // Stop tracing
        await _page.Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = $"playwright-traces/{TestContext.CurrentContext.Test.Name}-{DateTime.Now:yyyyMMdd_HHmmss}.zip"
        });

        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("QA Automation")]
    public async Task HeroSection()
    {
        // And: the user sees hero carousel images
        await StepAsync("Verify hero carousel images are visible", async () =>
        {
            await App.Home.VerifyHeroCarousel();
        });

        // And: the user sees hero title
        await StepAsync("Verify header title is visible", async () =>
        {
            await App.Common.HeaderIsVisible(Strings.Home.HeroTitle);
        });

        // And: the user sees hero description
        await StepAsync("Verify hero description is visible", async () =>
        {
            await App.Common.ParagraphIsVisible(Strings.Home.HeroDescription);
        });

        // And: the user sees and clicks on Join Now button
        await StepAsync("Verify Join Now button is visible and clickable", async () =>
        {
            await App.Home.VerifyJoinNowButton();
        });
    }

    private async Task StepAsync(string stepName, Func<Task> action)
    {
        AllureLifecycle.Instance.WrapInStep(async () =>
        {
            await action();
        }, stepName);
    }
}