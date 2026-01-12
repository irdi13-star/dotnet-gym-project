namespace PlaywrightTests.CSharp.Tests;

using NUnit.Framework;
using PlaywrightTests.CSharp.Resources;

[TestFixture]
[Category("regression")]
[Category("home")]
public class HomeTestsWithReporting : BaseTest
{
    [SetUp]
    public async Task SetUp()
    {
        LogInfo("Navigating to MADGYM Home page");
        await App.Base.NavigateTo(Routes.HomeLinks.Home);
        await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        await App.Common.BrowserTabTitleAsExpected(Strings.Home.HomeTitle);
        LogPass("Successfully navigated to home page");
    }

    [Test]
    public async Task HeroSection_ShouldDisplayCorrectly()
    {
        LogInfo("Verifying hero carousel");
        await App.Home.VerifyHeroCarousel();
        LogPass("Hero carousel is visible");

        LogInfo("Verifying hero title");
        await App.Common.HeaderIsVisible(Strings.Home.HeroTitle);
        LogPass("Hero title is visible");

        LogInfo("Verifying hero description");
        await App.Common.ParagraphIsVisible(Strings.Home.HeroDescription);
        LogPass("Hero description is visible");

        LogInfo("Verifying Join Now button");
        await App.Home.VerifyJoinNowButton();
        LogPass("Join Now button is visible and enabled");
    }
}

