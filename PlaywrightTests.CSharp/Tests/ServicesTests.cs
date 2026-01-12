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

        LogInfo("Verify Services page is loaded");
        await App.Services.GoToServicesPage();
        await App.Navigation.PageUrlContains(Routes.NavbarLinks.Services);
        LogPass("Services page succeeded");
    }

    [Test]
    public async Task OurServicesVerifications()
    {
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

    [Test]
    public async Task PersonalTrainingVerifications()
    {
        LogInfo("Verify Personal Training page is loaded");
        await App.Services.ClickPersonalTrainingCard();
        await App.Navigation.PageUrlContains(Routes.AllPages.ServicePersonalTrainingPage);
        LogPass("Personal Training page succeeded");

        LogInfo("Verify Services page Tab title and main Title");
        await App.Common.BrowserTabTitleAsExpected(
          Strings.Services.PersonalTrainingPage.PageTitle
        );
        LogPass("Services page Tab as expected");

        LogInfo("Verify Personal Training header section");
        await App.Services.VerifyPersonalTrainingHeaderSection();
        LogPass("Personal Training header as expected");

        LogInfo("Verify Personal Training info section");
        await App.Services.VerifyPersonalTrainingInfoSection();
        LogPass("Personal Training info as expected");

        LogInfo("Verify Personal Training benefits section");
        await App.Services.VerifyPersonalTrainingBenefitsSection();
        LogPass("Personal Training benefits as expected");

        LogInfo("Verify Personal Training contact section");
        await App.Services.VerifyPersonalTrainingContactSection();
        LogPass("Personal Training contact as expected");
    }

    [Test]
    public async Task GroupProgramsVerifications()
    {
        LogInfo("Verify Group Programs page is loaded");
        await App.Services.ClickGroupProgramsCard();
        await App.Navigation.PageUrlContains(Routes.AllPages.ServiceGroupProgramsPage);
        LogPass("Group Programs page succeeded");

        LogInfo("Verify Group Programs Tab Title");
        await App.Common.BrowserTabTitleAsExpected(
          Strings.Services.GroupProgramsPage.PageTitle
        );
        LogPass("Group Programs page Tab as expected");

        LogInfo("Verify Group Programs header section");
        await App.Services.VerifyGroupProgramsHeaderSection();
        LogPass("Group Programs header as expected");

        LogInfo("Verify Group Programs info section");
        await App.Services.VerifyGroupProgramsInfoSection();
        LogPass("Group Programs info as expected");

        LogInfo("Verify Group Programs benefits section");
        await App.Services.VerifyGroupProgramsBenefitsSection();
        LogPass("Group Programs benefits as expected");

        LogInfo("Verify Group Programs contact section and button");
        await App.Services.VerifyGroupProgramsContactSection();
        LogPass("Group Programs contact as expected");
    }

    [Test]
    public async Task NutritionCoachingVerifications()
    {
        LogInfo("Verify Nutrition Coaching page is loaded");
        await App.Services.ClickNutritionCoachingCard();
        await App.Navigation.PageUrlContains(Routes.AllPages.ServiceNutritionCoachingPage);
        LogPass("Nutrition Coaching page succeeded");

        LogInfo("Verify Nutrition Coaching Tab Title");
        await App.Common.BrowserTabTitleAsExpected(
          Strings.Services.NutritionCoachingPage.PageTitle
        );
        LogPass("Nutrition Coaching page Tab as expected");

        LogInfo("Verify Nutrition Coaching header section");
        await App.Services.VerifyNutritionCoachingHeaderSection();
        LogPass("Nutrition Coaching header as expected");

        LogInfo("Verify Nutrition Coaching info section");
        await App.Services.VerifyNutritionCoachingInfoSection();
        LogPass("Nutrition Coaching info as expected");

        LogInfo("Verify Nutrition Coaching benefits section");
        await App.Services.VerifyNutritionCoachingBenefitsSection();
        LogPass("Nutrition Coaching benefits as expected");

        LogInfo("Verify Nutrition Coaching contact section and button");
        await App.Services.VerifyNutritionCoachingContactSection();
        LogPass("Nutrition Coaching contact as expected");
    }
}