namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Helpers;
using PlaywrightTests.CSharp.Utils;

[TestFixture]
[Category("regression")]
[Category("services")]
public class ServicesTests : BaseTest
{
    [SetUp]
    public async Task BeforeEach()
    {
        LogInfo("Navigate to MADGYM Home page");
        await App.Base.NavigateTo(Routes.HomeLinks.Home);
        await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        LogPass("Navigation to home succeeded");
    }

    [Test]
    public async Task OurServicesVerifications()
    {
        LogInfo($"Verify Services page is loaded");
        await App.Services.GoToServicesPage();
        await App.Navigation.PageUrlContains(Routes.NavbarLinks.Services);
        LogPass("Services page succeeded");

        LogInfo("Verify Services page Tab title and main Title");
        await App.Common.BrowserTabTitleAsExpected(
          Strings.Services.ServicesTabTitle
        );
        await App.Services.VerifyOurServicesTitle();
        LogPass("Tab title and main Title are good");

        LogInfo("Verify all service titles are visible");
        await App.Services.VerifyAllServiceTitles();
        LogPass("Service titles are good");

        LogInfo("Verify all service images are loaded");
        await App.Services.VerifyAllServiceImages();
        LogPass("Service images are good");

        LogInfo("Verify overlays appear on hover");
        await App.Services.VerifyAllServiceOverlays();
        LogPass("Service overlays are good");

        LogInfo("Click each service card and go back");
        await App.Services.ClickAllCardsAndGoBack();
        LogPass("Service cards are good");
    }
}