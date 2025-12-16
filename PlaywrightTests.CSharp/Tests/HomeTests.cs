namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Actions;
using PlaywrightTests.CSharp.Utils;

[TestFixture]
[Category("regression")]
[Category("home")]
public class HomeTests : BaseTest
{
    [SetUp]
    public async Task SetUp()
    {
        // Given: the user accesses the MADGYM Home page
        await Test.Step("Navigate to MADGYM Home page", async () =>
        {
            await App.Base.NavigateTo(Routes.HomeLinks.Home);
            await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
            await App.Common.BrowserTabTitleAsExpected(Strings.Home.HomeBrowserTitle);
        });
    }

    [Test]
    public async Task HeroSection()
    {
        // And: the user sees hero carousel images
        await Test.Step("Verify hero carousel images are visible", async () =>
        {
            await App.Home.VerifyHeroCarousel();
        });

        // And: the user sees hero title
        await Test.Step("Verify header title is visible", async () =>
        {
            await App.Common.HeaderIsVisible(Strings.Home.HeroTitle);
        });

        // And: the user sees hero description
        await Test.Step("Verify hero description is visible", async () =>
        {
            await App.Common.ParagraphIsVisible(Strings.Home.HeroDescription);
        });

        // And: the user sees and clicks on Join Now button
        await Test.Step("Verify Join Now button is visible and clickable", async () =>
        {
            await App.Home.VerifyJoinNowButton();
        });
    }
}