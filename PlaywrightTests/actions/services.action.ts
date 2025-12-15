import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { BrowserContext, expect, Locator, Page } from "@playwright/test";
import CommonActions from "./common.actions";
import ServicesPage from "../pages/services.page";

export default class ServicesActions extends CommonActions {
  
  services: ServicesPage;

  constructor(page: Page, context: BrowserContext) {
    super(page, context);
    this.services = new ServicesPage(page, context);
  }

  async goToServicesPage() {
    const servicesButton = this.services.servicesLinkDesktop;
    await servicesButton.click();
    await this.page.waitForLoadState("load", { timeout: 30000 });
  }

  async verifyOurServicesTitle() {
    const ourServicesTitle = strings.services.ourServicesTitle;
    await this.checkH1(ourServicesTitle);
  }

  // ---------cards images
  async verifyPersonalTrainingImage() {
    const personalTrainingImage = strings.services.personalTrainingSrc;
    await this.verifyImageSrc(personalTrainingImage);
  }

  async verifyGroupProgramsImage() {
    const groupProgramsImage = strings.services.groupProgramsSrc;
    await this.verifyImageSrc(groupProgramsImage);
  }

  async verifyNutritionCoachingImage() {
    const nutritionCoachingImage = strings.services.nutritionCoachingSrc;
    await this.verifyImageSrc(nutritionCoachingImage);
  }

  async verifyAllServiceImages() {
    await this.verifyPersonalTrainingImage();
    await this.verifyGroupProgramsImage();
    await this.verifyNutritionCoachingImage();
  }

  // ------- cards titles

  async verifyPersonalTrainingTitle() {
    const personalTrainingTitle = this.services.personalTrainingCardTitle;
    await expect(personalTrainingTitle).toBeVisible();
  }

  async verifyGroupProgramsTitle() {
    const groupProgramsTitle = this.services.groupProgramsCardTitle;
    await expect(groupProgramsTitle).toBeVisible();
  }

  async verifyNutritionCoachingTitle() {
    const nutritionCoachingTitle = this.services.nutritionCoachingCardTitle;
    await expect(nutritionCoachingTitle).toBeVisible();
  }

  async verifyAllServiceTitles() {
    await this.verifyPersonalTrainingTitle();
    await this.verifyGroupProgramsTitle();
    await this.verifyNutritionCoachingTitle();
  }

  // ---------cards overlay

  async verifyPersonalTrainingOverlay() {
    await this.services.personalTrainingCard.hover();
    await expect(this.services.meetOurTeamOverlay).toBeVisible();
  }

  async verifyGroupProgramsOverlay() {
    await this.services.groupProgramsCard.hover();
    await expect(this.services.signUpForFreeOverlay).toBeVisible();
  }

  async verifyNutritionCoachingOverlay() {
    await this.services.nutritionCoachingCard.hover();
    await expect(this.services.createYourDietOverlay).toBeVisible();
  }

  async verifyAllServiceOverlays() {
    await this.verifyPersonalTrainingOverlay();
    await this.verifyGroupProgramsOverlay();
    await this.verifyNutritionCoachingOverlay();
  }

  // ----- CLICK verify

  async clickPersonalTrainingCard() {
    await this.services.personalTrainingCard.click();
    await expect(this.page).toHaveURL(
      routes.allPages.servicePersonalTrainingPage
    );
  }

  async clickGroupProgramsCard() {
    await this.services.groupProgramsCard.click();
    await expect(this.page).toHaveURL(routes.allPages.serviceGroupProgramsPage);
  }

  async clickNutritionCoachingCard() {
    await this.services.nutritionCoachingCard.click();
    await expect(this.page).toHaveURL(
      routes.allPages.serviceNutritionCoachingPage
    );
  }

  async clickAllCardsAndGoBack() {
    await this.clickPersonalTrainingCard();
    await this.page.goBack();
    await this.clickGroupProgramsCard();
    await this.page.goBack();
    await this.clickNutritionCoachingCard();
    await this.page.goBack();
  }

  async checkHeaderSection(
    header: Locator,
    title: Locator,
    subtitle: Locator,
    expectedTitle: string,
    expectedSubtitle: string
  ) {
    await expect(header).toBeVisible();
    await expect(title).toHaveText(expectedTitle);
    await expect(subtitle).toHaveText(expectedSubtitle);
  }

  async checkInfoSection(
    section: Locator,
    title: Locator,
    expectedTitle: string,
    text: Locator,
    expectedText: string,
    expectedImageSrc: string
  ) {
    await expect(section).toBeVisible();
    await expect(title).toHaveText(expectedTitle);
    await expect(text).toHaveText(expectedText);
    await this.verifyImageSrc(expectedImageSrc);
  }

  async checkBenefitsSection(
    section: Locator,
    title: Locator,
    expectedTitle: string,
    items: Locator,
    expectedItems: string[]
  ) {
    await expect(section).toBeVisible();
    await expect(title).toHaveText(expectedTitle);

    const count = await items.count();
    expect(count).toBe(expectedItems.length);

    for (let i = 0; i < expectedItems.length; i++) {
      await expect(items.nth(i)).toContainText(expectedItems[i]);
    }
  }

  async checkContactSectionAndButton(
    section: Locator,
    text: Locator,
    expectedText: string,
    button: Locator,
    expectedButtonText: string,
    expectedUrl: string
  ) {
    await expect(section).toBeVisible();
    await expect(text).toHaveText(expectedText);
    await expect(button).toBeVisible();
    await expect(button).toHaveText(expectedButtonText);

    await button.click();
    await expect(this.page).toHaveURL(expectedUrl);
    await this.page.goBack();
  }

  async verifyPersonalTrainingHeaderSection() {
    await this.checkHeaderSection(
      this.services.personalTrainingHeader,
      this.services.personalTrainingTitle,
      this.services.personalTrainingSubtitle,
      strings.services.personalTrainingPage.headerTitle,
      strings.services.personalTrainingPage.headerSubtitle
    );
  }

  async verifyPersonalTrainingInfoSection() {
    await this.checkInfoSection(
      this.services.personalTrainingInfo,
      this.services.personalTrainingWhatTitle,
      strings.services.personalTrainingPage.whatIsTitle,
      this.services.personalTrainingWhatText,
      strings.services.personalTrainingPage.whatIsText,
      strings.services.personalTrainingSrc
    );
  }

  async verifyPersonalTrainingBenefitsSection() {
    await this.checkBenefitsSection(
      this.services.personalTrainingBenefits,
      this.services.personalTrainingBenefitsTitle,
      strings.services.personalTrainingPage.benefitsTitle,
      this.services.personalTrainingBenefitsList,
      strings.services.personalTrainingPage.benefitsList
    );
  }

  async verifyPersonalTrainingContactSection() {
    await this.checkContactSectionAndButton(
      this.services.personalTrainingContact,
      this.services.personalTrainingContactText,
      strings.services.personalTrainingPage.contactText,
      this.services.personalTrainingContactButton,
      strings.services.personalTrainingPage.contactButton,
      routes.allPages.contactPage
    );
  }

  async verifyGroupProgramsHeaderSection() {
    await this.checkHeaderSection(
      this.services.groupProgramsHeader,
      this.services.groupProgramsTitle,
      this.services.groupProgramsSubtitle,
      strings.services.groupProgramsPage.headerTitle,
      strings.services.groupProgramsPage.headerSubtitle
    );
  }

  async verifyGroupProgramsInfoSection() {
    await this.checkInfoSection(
      this.services.groupProgramsInfo,
      this.services.groupProgramsWhatTitle,
      strings.services.groupProgramsPage.whatIsTitle,
      this.services.groupProgramsWhatText,
      strings.services.groupProgramsPage.whatIsText,
      strings.services.groupProgramsSrc
    );
  }

  async verifyGroupProgramsBenefitsSection() {
    await this.checkBenefitsSection(
      this.services.groupProgramsBenefits,
      this.services.groupProgramsBenefitsTitle,
      strings.services.groupProgramsPage.benefitsTitle,
      this.services.groupProgramsBenefitsList,
      strings.services.groupProgramsPage.benefitsList
    );
  }

  async verifyGroupProgramsContactSection() {
    await this.checkContactSectionAndButton(
      this.services.groupProgramsContact,
      this.services.groupProgramsContactText,
      strings.services.groupProgramsPage.contactText,
      this.services.groupProgramsContactButton,
      strings.services.groupProgramsPage.contactButton,
      routes.allPages.contactPage
    );
  }

  async verifyNutritionCoachingHeaderSection() {
    await this.checkHeaderSection(
      this.services.nutritionCoachingHeader,
      this.services.nutritionCoachingTitle,
      this.services.nutritionCoachingSubtitle,
      strings.services.nutritionCoachingPage.headerTitle,
      strings.services.nutritionCoachingPage.headerSubtitle
    );
  }

  async verifyNutritionCoachingInfoSection() {
    await this.checkInfoSection(
      this.services.nutritionCoachingInfo,
      this.services.nutritionCoachingWhatTitle,
      strings.services.nutritionCoachingPage.whatIsTitle,
      this.services.nutritionCoachingWhatText,
      strings.services.nutritionCoachingPage.whatIsText,
      strings.services.nutritionCoachingSrc
    );
  }

  async verifyNutritionCoachingBenefitsSection() {
    await this.checkBenefitsSection(
      this.services.nutritionCoachingBenefits,
      this.services.nutritionCoachingBenefitsTitle,
      strings.services.nutritionCoachingPage.benefitsTitle,
      this.services.nutritionCoachingBenefitsList,
      strings.services.nutritionCoachingPage.benefitsList
    );
  }

  async verifyNutritionCoachingContactSection() {
    await this.checkContactSectionAndButton(
      this.services.nutritionCoachingContact,
      this.services.nutritionCoachingContactText,
      strings.services.nutritionCoachingPage.contactText,
      this.services.nutritionCoachingContactButton,
      strings.services.nutritionCoachingPage.contactButton,
      routes.allPages.contactPage
    );
  }
}
