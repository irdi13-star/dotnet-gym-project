import BaseActions from "./base.actions";
import HomePage from "../pages/home.page";
import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { BrowserContext, expect, Page } from "@playwright/test";
import CommonActions from "./common.actions";

export default class HomeActions extends CommonActions {
  home: HomePage;

  constructor(page: Page, context: BrowserContext) {
    super(page, context);
    this.home = new HomePage(page, context);
  }

  // -------- Hero Section
  async verifyHeroCarousel() {
    await expect(this.home.heroBanner).toBeVisible();

    const images = this.home.heroCarousel;
    const count = await images.count();

    for (let i = 0; i < count; i++) {
      const image = images.nth(i);

      await expect(image).toHaveAttribute("src");
      const src = await image.getAttribute("src");

      console.log(`Image ${i + 1} found with src ${src}`);
    }
  }

  async verifyHeroTitle() {
    const heroTitle = strings.home.heroSection.heroTitle;
    await this.checkH1(heroTitle);
  }

  async verifyHeroDescription() {
    const heroDescription = strings.home.heroSection.heroDescription;
    await this.checkP(heroDescription);
  }

  async verifyJoinNowButton() {
    const joinNowButton = this.home.joinNowHref(routes.homeLinks.joinNowHref); // Apel corect

    await expect(joinNowButton).toBeVisible();
    await expect(joinNowButton).toHaveAttribute(
      "href",
      routes.homeLinks.joinNowHref
    );

    console.log(
      "Join Now button href: " + (await joinNowButton.getAttribute("href"))
    );

    await expect(joinNowButton).toHaveText(strings.home.heroSection.joinNow);
    await joinNowButton.click();
    await expect(this.page).toHaveURL(routes.homeLinks.joinNowHref);

    console.log(
      "Join Now button clicked and URL changed to:",
      await this.page.url()
    );
  }

  // --------- Our Services Section
  //TODO: verifyOurServiceCards doesn't work
  async verifyOurServicesCards() {
    const serviceCards = this.home.ourServicesCards;
    const count = await serviceCards.count();

    for (let i = 0; i < count; i++) {
      const card = serviceCards.nth(i);
      await card.hover();
      await expect(card).toBeVisible();
      console.log("Service card " + (i + 1) + " is visible");
    }
  }

  async verifyServicesSectionTitle() {
    const servicesSectionTitle = strings.home.ourServicesCards.ourServicesTitle;
    await this.checkH2(servicesSectionTitle);
  }

  async checkServicesCardTitle(serviceName: string) {
    await this.checkH3(serviceName);
  }

  async verifyServicesCardTitle() {
    await this.checkMembershipsCardTitle(
      strings.home.ourServicesCards.personalTraining
    );
    await this.checkMembershipsCardTitle(
      strings.home.ourServicesCards.groupClasses
    );
    await this.checkMembershipsCardTitle(
      strings.home.ourServicesCards.nutritionCoaching
    );
  }

  async verifyServicesCardDescription() {
    const personalTrainingDescription =
      strings.home.ourServicesCards.personalTrainingDescription;
    const groupClassesDescription =
      strings.home.ourServicesCards.groupClassesDescription;
    const nutritionCoachingDescription =
      strings.home.ourServicesCards.nutritionCoachingDescription;

    await this.checkP(personalTrainingDescription);
    await this.checkP(groupClassesDescription);
    await this.checkP(nutritionCoachingDescription);
  }

  async verifySeeServicesButton() {
    const seeServicesButton = this.home.seeServicesHref(
      routes.homeLinks.seeServices
    );

    await expect(seeServicesButton).toBeVisible();
    await expect(seeServicesButton).toHaveAttribute(
      "href",
      routes.homeLinks.seeServices
    );

    console.log(
      "See Services button href: " +
        (await seeServicesButton.getAttribute("href"))
    );

    await expect(seeServicesButton).toHaveText(
      strings.home.ourServicesCards.seeServicesButton
    );

    await seeServicesButton.click();
    await expect(this.page).toHaveURL(routes.homeLinks.seeServices);
  }

  // -------- Our Memberships Section

  async verifyOurMembershipsCards() {
    const membershipCards = this.home.ourMembershipCards;
    const count = await membershipCards.count();

    for (let i = 0; i < count; i++) {
      const card = membershipCards.nth(i);
      await card.hover();
      await expect(card).toBeVisible();
      console.log("Membership card " + (i + 1) + " is visible");
    }
  }

  async verifyMembershipsSectionTitle() {
    const membesrhipSectionTitle =
      strings.home.ourMembershipsCards.ourMembershipsTitle;
    await this.checkH2(membesrhipSectionTitle);
  }

  async checkMembershipsCardTitle(membershipName: string) {
    await this.checkH3(membershipName);
  }

  async verifyMembershipsCardTitle() {
    await this.checkMembershipsCardTitle(
      strings.home.ourMembershipsCards.basicCardTitle
    );
    await this.checkMembershipsCardTitle(
      strings.home.ourMembershipsCards.eliteCardTitle
    );
    await this.checkMembershipsCardTitle(
      strings.home.ourMembershipsCards.premiumCardTitle
    );
  }

  async checkMembershipsCardDescription(membershipDescription: string) {
    await this.checkP(membershipDescription);
  }

  async verifyMembershipsCardDescription() {
    await this.checkMembershipsCardDescription(
      strings.home.ourMembershipsCards.basicCardDescription
    );
    await this.checkMembershipsCardDescription(
      strings.home.ourMembershipsCards.eliteCardDescription
    );
    await this.checkMembershipsCardDescription(
      strings.home.ourMembershipsCards.premiumCardDescription
    );
  }

  async verifySeeMembershipsButton() {
    const seeMembershipsButton = this.home.seeMembershipsHref(
      routes.homeLinks.seeMemberships
    );

    await expect(seeMembershipsButton).toBeVisible();
    await expect(seeMembershipsButton).toHaveAttribute(
      "href",
      routes.homeLinks.seeMemberships
    );

    console.log(
      "See Memberships button href: " +
        (await seeMembershipsButton.getAttribute("href"))
    );

    await expect(seeMembershipsButton).toHaveText(
      strings.home.ourMembershipsCards.seeMembershipsButton
    );
    await seeMembershipsButton.click();
    await expect(this.page).toHaveURL(routes.homeLinks.seeMemberships);
  }

  // --------- About MadGym Section

  async verifyAboutSectionTitle() {
    const aboutSectionTitle = strings.home.aboutSection.aboutTitle;
    await this.checkH2(aboutSectionTitle);
  }

  async verifyAboutSectionDescription() {
    const aboutSectionDescription = strings.home.aboutSection.aboutDescription;
    await this.checkP(aboutSectionDescription);
  }

  async verifyLearnMoreButton() {
    const learnMoreButton = this.home.learnMoreHref(
      routes.homeLinks.learnMoreHref
    );

    await expect(learnMoreButton).toBeVisible();
    await expect(learnMoreButton).toHaveAttribute(
      "href",
      routes.homeLinks.learnMoreHref
    );

    console.log(
      "Learn More button href: " + (await learnMoreButton.getAttribute("href"))
    );

    await expect(learnMoreButton).toHaveText(
      strings.home.aboutSection.learnMoreButton
    );

    await learnMoreButton.click();
    await expect(this.page).toHaveURL(routes.homeLinks.learnMoreHref);

    console.log(
      "Learn More button clicked and URL changed to:",
      await this.page.url()
    );
  }
}
