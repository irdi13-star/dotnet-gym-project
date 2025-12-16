using NUnit.Framework;
using PlaywrightTests.CSharp.Resources;
using System;
using System.Threading.Tasks;

namespace PlaywrightTests.CSharp.Tests
{
    [TestFixture]
    [Category("regression")]
    [Category("home")]
    public class HomeTests : BaseTest
    {
        [Test]
        public async Task HeroSection()
        {
            await StepAsync("Navigate to MADGYM Home page", async () =>
            {
                await App.Base.NavigateTo(Routes.HomeLinks.Home);
                await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
                await App.Common.BrowserTabTitleAsExpected(Strings.Home.HomeBrowserTitle);
            });
            
            await StepAsync("Verify hero carousel images are visible", async () =>
            {
                await App.Home.VerifyHeroCarousel();
            });

            await StepAsync("Verify hero title is visible", async () =>
            {
                await App.Common.HeaderIsVisible(Strings.Home.HeroTitle);
            });

            await StepAsync("Verify hero description is visible", async () =>
            {
                await App.Common.ParagraphIsVisible(Strings.Home.HeroDescription);
            });

            await StepAsync("Verify Join Now button is visible and clickable", async () =>
            {
                await App.Home.VerifyJoinNowButton();
            });
        }
    }
}
