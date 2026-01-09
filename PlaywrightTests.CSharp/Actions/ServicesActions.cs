using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightTests.CSharp.Actions
{
    public class ServicesActions(IPage page, IBrowserContext context) : CommonActions(page, context)
    {
        private readonly ServicesPage _services = new(page);

        public async Task GoToServicesPage()
        {
            var servicesButton = _services.ServicesLinkDesktop;
            await servicesButton.ClickAsync();
            await Task.Delay(3000);
        }

        public async Task VerifyOurServicesTitle()
        {
            var ourServicesTitle = Strings.Services.OurServicesTitle;
            await CheckH1(ourServicesTitle);
        }

        // ---------cards images
        public async Task VerifyPersonalTrainingImage()
        {
            var personalTrainingImage = Strings.Services.PersonalTrainingSrc;
            await VerifyImageSrc(personalTrainingImage);
        }

        public async Task VerifyGroupProgramsImage()
        {
            var groupProgramsImage = Strings.Services.GroupProgramsSrc;
            await VerifyImageSrc(groupProgramsImage);
        }

        public async Task VerifyNutritionCoachingImage()
        {
            var nutritionCoachingImage = Strings.Services.NutritionCoachingSrc;
            await VerifyImageSrc(nutritionCoachingImage);
        }

        public async Task VerifyAllServiceImages()
        {
            await VerifyPersonalTrainingImage();
            await VerifyGroupProgramsImage();
            await VerifyNutritionCoachingImage();
        }

        // ------- cards titles
        public async Task VerifyPersonalTrainingTitle()
        {
            var personalTrainingTitle = _services.PersonalTrainingCardTitle;
            await Assertions.Expect(personalTrainingTitle).ToBeVisibleAsync();
        }

        public async Task VerifyGroupProgramsTitle()
        {
            var groupProgramsTitle = _services.GroupProgramsCardTitle;
            await Assertions.Expect(groupProgramsTitle).ToBeVisibleAsync();
        }

        public async Task VerifyNutritionCoachingTitle()
        {
            var nutritionCoachingTitle = _services.NutritionCoachingCardTitle;
            await Assertions.Expect(nutritionCoachingTitle).ToBeVisibleAsync();
        }

        public async Task VerifyAllServiceTitles()
        {
            await VerifyPersonalTrainingTitle();
            await VerifyGroupProgramsTitle();
            await VerifyNutritionCoachingTitle();
        }

        // ---------cards overlay
        public async Task VerifyPersonalTrainingOverlay()
        {
            await _services.PersonalTrainingCard.HoverAsync();
            await Assertions.Expect(_services.MeetOurTeamOverlay).ToBeVisibleAsync();
        }

        public async Task VerifyGroupProgramsOverlay()
        {
            await _services.GroupProgramsCard.HoverAsync();
            await Assertions.Expect(_services.SignUpForFreeOverlay).ToBeVisibleAsync();
        }

        public async Task VerifyNutritionCoachingOverlay()
        {
            await _services.NutritionCoachingCard.HoverAsync();
            await Assertions.Expect(_services.CreateYourDietOverlay).ToBeVisibleAsync();
        }

        public async Task VerifyAllServiceOverlays()
        {
            await VerifyPersonalTrainingOverlay();
            await VerifyGroupProgramsOverlay();
            await VerifyNutritionCoachingOverlay();
        }

        // ----- CLICK verify
        public async Task ClickPersonalTrainingCard()
        {
            await _services.PersonalTrainingCard.ClickAsync();
            await Assertions.Expect(Page).ToHaveURLAsync(Routes.AllPages.ServicePersonalTrainingPage);
        }

        public async Task ClickGroupProgramsCard()
        {
            await _services.GroupProgramsCard.ClickAsync();
            await Assertions.Expect(Page).ToHaveURLAsync(Routes.AllPages.ServiceGroupProgramsPage);
        }

        public async Task ClickNutritionCoachingCard()
        {
            await _services.NutritionCoachingCard.ClickAsync();
            await Assertions.Expect(Page).ToHaveURLAsync(Routes.AllPages.ServiceNutritionCoachingPage);
        }

        public async Task ClickAllCardsAndGoBack()
        {
            await ClickPersonalTrainingCard();
            await Page.GoBackAsync();
            await ClickGroupProgramsCard();
            await Page.GoBackAsync();
            await ClickNutritionCoachingCard();
            await Page.GoBackAsync();
        }

        public async Task CheckHeaderSection(
            ILocator header,
            ILocator title,
            ILocator subtitle,
            string expectedTitle,
            string expectedSubtitle)
        {
            await Assertions.Expect(header).ToBeVisibleAsync();
            await Assertions.Expect(title).ToHaveTextAsync(expectedTitle);
            await Assertions.Expect(subtitle).ToHaveTextAsync(expectedSubtitle);
        }

        public async Task CheckInfoSection(
            ILocator section,
            ILocator title,
            string expectedTitle,
            ILocator text,
            string expectedText,
            string expectedImageSrc)
        {
            await Assertions.Expect(section).ToBeVisibleAsync();
            await Assertions.Expect(title).ToHaveTextAsync(expectedTitle);
            await Assertions.Expect(text).ToHaveTextAsync(expectedText);
            await VerifyImageSrc(expectedImageSrc);
        }

        public async Task CheckBenefitsSection(
            ILocator section,
            ILocator title,
            string expectedTitle,
            ILocator items,
            string[] expectedItems)
        {
            await Assertions.Expect(section).ToBeVisibleAsync();
            await Assertions.Expect(title).ToHaveTextAsync(expectedTitle);

            var count = await items.CountAsync();
            Assert.Equals(expectedItems.Length, count);

            for (int i = 0; i < expectedItems.Length; i++)
            {
                await Assertions.Expect(items.Nth(i)).ToContainTextAsync(expectedItems[i]);
            }
        }

        public async Task CheckContactSectionAndButton(
            ILocator section,
            ILocator text,
            string expectedText,
            ILocator button,
            string expectedButtonText,
            string expectedUrl)
        {
            await Assertions.Expect(section).ToBeVisibleAsync();
            await Assertions.Expect(text).ToHaveTextAsync(expectedText);
            await Assertions.Expect(button).ToBeVisibleAsync();
            await Assertions.Expect(button).ToHaveTextAsync(expectedButtonText);

            await button.ClickAsync();
            await Assertions.Expect(Page).ToHaveURLAsync(expectedUrl);
            await Page.GoBackAsync();
        }

        public async Task VerifyPersonalTrainingHeaderSection()
        {
            await CheckHeaderSection(
                _services.PersonalTrainingHeader,
                _services.PersonalTrainingTitle,
                _services.PersonalTrainingSubtitle,
                Strings.Services.PersonalTrainingPage.HeaderTitle,
                Strings.Services.PersonalTrainingPage.HeaderSubtitle
            );
        }

        public async Task VerifyPersonalTrainingInfoSection()
        {
            await CheckInfoSection(
                _services.PersonalTrainingInfo,
                _services.PersonalTrainingWhatTitle,
                Strings.Services.PersonalTrainingPage.WhatIsTitle,
                _services.PersonalTrainingWhatText,
                Strings.Services.PersonalTrainingPage.WhatIsText,
                Strings.Services.PersonalTrainingSrc
            );
        }

        public async Task VerifyPersonalTrainingBenefitsSection()
        {
            await CheckBenefitsSection(
                _services.PersonalTrainingBenefits,
                _services.PersonalTrainingBenefitsTitle,
                Strings.Services.PersonalTrainingPage.BenefitsTitle,
                _services.PersonalTrainingBenefitsList,
                Strings.Services.PersonalTrainingPage.BenefitsList
            );
        }

        public async Task VerifyPersonalTrainingContactSection()
        {
            await CheckContactSectionAndButton(
                _services.PersonalTrainingContact,
                _services.PersonalTrainingContactText,
                Strings.Services.PersonalTrainingPage.ContactText,
                _services.PersonalTrainingContactButton,
                Strings.Services.PersonalTrainingPage.ContactButton,
                Routes.AllPages.ContactPage
            );
        }

        public async Task VerifyGroupProgramsHeaderSection()
        {
            await CheckHeaderSection(
                _services.GroupProgramsHeader,
                _services.GroupProgramsTitle,
                _services.GroupProgramsSubtitle,
                Strings.Services.GroupProgramsPage.HeaderTitle,
                Strings.Services.GroupProgramsPage.HeaderSubtitle
            );
        }

        public async Task VerifyGroupProgramsInfoSection()
        {
            await CheckInfoSection(
                _services.GroupProgramsInfo,
                _services.GroupProgramsWhatTitle,
                Strings.Services.GroupProgramsPage.WhatIsTitle,
                _services.GroupProgramsWhatText,
                Strings.Services.GroupProgramsPage.WhatIsText,
                Strings.Services.GroupProgramsSrc
            );
        }

        public async Task VerifyGroupProgramsBenefitsSection()
        {
            await CheckBenefitsSection(
                _services.GroupProgramsBenefits,
                _services.GroupProgramsBenefitsTitle,
                Strings.Services.GroupProgramsPage.BenefitsTitle,
                _services.GroupProgramsBenefitsList,
                Strings.Services.GroupProgramsPage.BenefitsList
            );
        }

        public async Task VerifyGroupProgramsContactSection()
        {
            await CheckContactSectionAndButton(
                _services.GroupProgramsContact,
                _services.GroupProgramsContactText,
                Strings.Services.GroupProgramsPage.ContactText,
                _services.GroupProgramsContactButton,
                Strings.Services.GroupProgramsPage.ContactButton,
                Routes.AllPages.ContactPage
            );
        }

        public async Task VerifyNutritionCoachingHeaderSection()
        {
            await CheckHeaderSection(
                _services.NutritionCoachingHeader,
                _services.NutritionCoachingTitle,
                _services.NutritionCoachingSubtitle,
                Strings.Services.NutritionCoachingPage.HeaderTitle,
                Strings.Services.NutritionCoachingPage.HeaderSubtitle
            );
        }

        public async Task VerifyNutritionCoachingInfoSection()
        {
            await CheckInfoSection(
                _services.NutritionCoachingInfo,
                _services.NutritionCoachingWhatTitle,
                Strings.Services.NutritionCoachingPage.WhatIsTitle,
                _services.NutritionCoachingWhatText,
                Strings.Services.NutritionCoachingPage.WhatIsText,
                Strings.Services.NutritionCoachingSrc
            );
        }

        public async Task VerifyNutritionCoachingBenefitsSection()
        {
            await CheckBenefitsSection(
                _services.NutritionCoachingBenefits,
                _services.NutritionCoachingBenefitsTitle,
                Strings.Services.NutritionCoachingPage.BenefitsTitle,
                _services.NutritionCoachingBenefitsList,
                Strings.Services.NutritionCoachingPage.BenefitsList
            );
        }

        public async Task VerifyNutritionCoachingContactSection()
        {
            await CheckContactSectionAndButton(
                _services.NutritionCoachingContact,
                _services.NutritionCoachingContactText,
                Strings.Services.NutritionCoachingPage.ContactText,
                _services.NutritionCoachingContactButton,
                Strings.Services.NutritionCoachingPage.ContactButton,
                Routes.AllPages.ContactPage
            );
        }
    }
}