import BaseActions from "./base.actions";
import HomePage from "../pages/home.page";
import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { BrowserContext, expect, Locator, Page } from "@playwright/test";
import NavbarFooterPage from "../pages/navbarFooter.page";
import CommonActions from "./common.actions";
import ServicesPage from "../pages/services.page";
import ServicesActions from "./services.action";
import AuthActions from "./auth.actions";

export default class navbarFooterActions extends AuthActions {
  navbarFooter: NavbarFooterPage;
  home: HomePage;
  services: ServicesPage;

  constructor(page: Page, context: BrowserContext) {
    super(page, context);
    this.navbarFooter = new NavbarFooterPage(page, context);
    this.home = new HomePage(page, context);
    this.services = new ServicesPage(page, context);
  }

  /// general TESTS FOR NAV BAR and FOOTER
  async locateNavbar() {
    await expect(this.navbarFooter.navbar).toBeVisible();
    return this.navbarFooter.navbar;
  }

  async locateLogo() {
    await expect(this.navbarFooter.logo).toBeVisible();
    return this.navbarFooter.logo;
  }

  async verifyLogoImg() {
    const logo = this.navbarFooter.logoImg;
    await expect(logo).toBeVisible();
    await expect(logo).toHaveAttribute("alt", strings.navBar.logoImageTitle);
    await expect(logo).toHaveAttribute("src", strings.navBar.logoSrc);
  }

  async verifyLogoText() {
    const logoText = this.navbarFooter.logoText;
    await expect(logoText).toBeVisible();
  }

  async checkNavbarTextLinks(linkText: string) {
    const locator = this.page.getByRole("link", {
      name: linkText,
      exact: true,
    });

    await expect(locator).toBeVisible();
    await expect(locator).toHaveText(linkText);
  }

  async verifyNavbarTextLinks() {
    await this.checkNavbarTextLinks(strings.navBar.about);
    await this.checkNavbarTextLinks(strings.navBar.services);
    await this.checkNavbarTextLinks(strings.navBar.membership);
    await this.checkNavbarTextLinks(strings.navBar.contact);

    const loginLocator = this.page.getByRole("link", {
      name: strings.navBar.login,
      exact: true,
    });

    if (await loginLocator.isVisible()) {
      await this.checkNavbarTextLinks(strings.navBar.login);
    } else {
      console.log("Login link is nottttttt visible");
    }
  }

  async verifyNavbarLinks() {
    const links = this.navbarFooter.navbarLinks;
    const count = await links.count();

    for (let i = 0; i < count; i++) {
      const link = links.nth(i);
      const text = await link.textContent();
      const href = await link.getAttribute("href");

      await expect(link).toBeVisible();
      await link.click();

      await expect(this.page).toHaveURL(href!);
      console.log(`Link '${text}' navigated to '${href}'`);

      await this.page.goBack();
    }
  }

  async verifyFooterText() {
    const footerText = strings.footer;
    const footerParagraph = this.commonPage.pLocator(footerText);

    await expect(footerParagraph).toBeVisible();
    await expect(footerParagraph).toHaveText(footerText);
  }

  async verifyNavbarAndFooter() {
    await this.locateNavbar();
    await this.locateLogo();
    await this.verifyLogoImg();
    await this.verifyLogoText();
    await this.verifyNavbarTextLinks();

    await this.verifyFooterText();
  }

  async verifyCommonLayoutAndNavigation(linkText: string, expectedUrl: string) {
    const link = this.page.getByRole("link", { name: linkText, exact: true });
    await expect(link).toBeVisible();
    await link.click();
    await this.page.waitForLoadState("load");

    await expect(this.page).toHaveURL(expectedUrl);
    await this.locateNavbar();
    await this.locateLogo();
    await this.verifyLogoImg();
    await this.verifyLogoText();
    await this.verifyNavbarTextLinks();
    //await this.verifyNavbarLinks();

    await this.verifyFooterText();

    await this.page.goBack();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(routes.homeLinks.home);
  }

  async navigateToPageByLinkText(linkText: string, expectedUrl: string) {
    const link = this.page.getByRole("link", { name: linkText, exact: true });
    await expect(link).toBeVisible();
    await link.click();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(expectedUrl);
  }

  async verifyPageWithCommonLayout(linkText: string, expectedUrl: string) {
    await this.navigateToPageByLinkText(linkText, expectedUrl);
    await this.verifyNavbarAndFooter();
    await this.page.goBack();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(routes.homeLinks.home);
  }

  // 3 SERVICES Pages

  async clickPersonalTrainingCard() {
    await this.navbarFooter.personalTrainingCard.click();
    await expect(this.page).toHaveURL(
      routes.allPages.servicePersonalTrainingPage
    );
  }

  async clickGroupProgramsCard() {
    await this.navbarFooter.groupProgramsCard.click();
    await expect(this.page).toHaveURL(routes.allPages.serviceGroupProgramsPage);
  }

  async clickNutritionCoachingCard() {
    await this.navbarFooter.nutritionCoachingCard.click();
    await expect(this.page).toHaveURL(
      routes.allPages.serviceNutritionCoachingPage
    );
  }

  async verifyPersonalTrainingFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.services,
      routes.allPages.servicesMainPage
    );

    await this.clickPersonalTrainingCard();

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(2);
  }

  async verifyNutritionCoachingFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.services,
      routes.allPages.servicesMainPage
    );

    await this.clickNutritionCoachingCard();

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(2);
  }

  async verifyGroupClassesFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.services,
      routes.allPages.servicesMainPage
    );

    await this.clickGroupProgramsCard();

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(2);
  }

  // -------------------------------------------------------------

  async verifyAboutFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.about,
      routes.allPages.aboutPage
    );

    await this.verifyNavbarAndFooter();

    await this.page.goBack();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(routes.homeLinks.home);
  }

  async verifyServicesFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.services,
      routes.allPages.servicesMainPage
    );

    await this.verifyNavbarAndFooter();

    await this.page.goBack();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(routes.homeLinks.home);
  }

  async verifyMembershipFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.membership,
      routes.allPages.membershipPage
    );

    await this.verifyNavbarAndFooter();

    await this.page.goBack();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(routes.homeLinks.home);
  }

  async verifyContactFlow() {
    await this.navigateToPageByLinkText(
      strings.navBar.contact,
      routes.allPages.contactPage
    );

    await this.verifyNavbarAndFooter();

    await this.page.goBack();
    await this.page.waitForLoadState("load");
    await expect(this.page).toHaveURL(routes.homeLinks.home);
  }

   async verifyLoginFlow() {
    const loginLink = this.page.getByRole("link", {
      name: strings.navBar.login,
      exact: true,
    });

    if (await loginLink.isVisible()) {
      await this.navigateToPageByLinkText(
        strings.navBar.login,
        routes.allPages.authLoginPage
      );
      await this.verifyNavbarAndFooter();

      await this.page.goBack();
      await this.page.waitForLoadState("load");
      await expect(this.page).toHaveURL(routes.homeLinks.home);
    } else {
      console.warn("User is already logged in");
      await this.verifyUserIsLoggedIn();
    }
  }


  // ---------------------------------------------------------------------------


 

  ///////// Login AS USER
  
  async loginAndGoToUserProfile() {
    await this.verifyPageWithCommonLayout(
      strings.navBar.login,
      routes.allPages.authLoginPage
    );
    await this.loginAsUser();
    await this.goToUserProfile();
    await this.verifyNavbarAndFooter();
  }

  async verifyUserPagesWithTwoClicks(locator: Locator) {
    await this.verifyUserIsLoggedIn();
    await this.goToUserProfile();

    await expect(locator).toBeVisible();
    await locator.click();
    await this.page.waitForLoadState("load");

    console.log("URL:", this.page.url());

    await this.verifyNavbarAndFooter();
    await this.goBackMultiple(2);
  }

  async verifyEditProfilePage() {
    await this.verifyUserPagesWithTwoClicks(this.commonPage.editProfileButton);
  }

  async verifyChangePasswordPage() {
    await this.verifyUserPagesWithTwoClicks(this.commonPage.forgotPasswordLink);
  }

  async verifyPaymentHistoryPage() {
    await this.verifyUserPagesWithTwoClicks(this.commonPage.paymentHistoryLink);
  }

  async verifyResetPasswordPage() {
    await this.verifyUserIsLoggedIn();

    await this.goToUserProfile();
    const changePasswordLink = this.commonPage.forgotPasswordLink;
    await expect(changePasswordLink).toBeVisible();
    await changePasswordLink.click();
    await this.page.waitForLoadState("load");

    const resetPasswordLink = this.commonPage.resetPasswordLink;
    await expect(resetPasswordLink).toBeVisible();
    await resetPasswordLink.click();
    await this.page.waitForLoadState("load");

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(2);
  }

  async verifyMembershipCheckoutPage() {
    await this.verifyUserIsLoggedIn();

    const membershipLink = this.commonPage.membershipLinkDesktop;
    await expect(membershipLink).toBeVisible();
    await membershipLink.click();
    await this.page.waitForLoadState("load");

    const checkoutLink = this.page
      .getByRole("link", { name: strings.membership.checkout })
      .first();
    await expect(checkoutLink).toBeVisible();
    await checkoutLink.click();
    await this.page.waitForLoadState("load");

    console.log("URL:", this.page.url());

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(2);
  }

  //de schimbat 
  async fillCheckoutFormAndPlaceOrder() {
    const checkout = strings.checkout;

    await this.page
      .locator(`#${checkout.id_firstName}`)
      .fill(checkout.value_firstName);
    await this.page
      .locator(`#${checkout.id_lastName}`)
      .fill(checkout.value_lastName);
    await this.page.locator(`#${checkout.id_email}`).fill(checkout.value_email);

    await this.page
      .locator(`#${checkout.id_membershipDuration}`)
      .selectOption({ label: checkout.value_membershipDuration });

    await this.page
      .locator(`#${checkout.id_cardNumber}`)
      .fill(checkout.value_cardNumber);
    await this.page.locator(`#${checkout.id_cvv}`).fill(checkout.value_cvv);
    await this.page
      .locator(`#${checkout.id_expirationDate}`)
      .fill(checkout.value_expirationDate);

    await this.page.locator(`#${checkout.id_termsAndConditions}`).check();
    const placeOrderButton = this.commonPage.orderSuccessLink;
    await expect(placeOrderButton).toBeVisible();
    await placeOrderButton.click();

    await this.page.waitForLoadState("load");
  }

  async verifyOrderSuccessPage() {
    await this.verifyUserIsLoggedIn();

    const membershipLink = this.commonPage.membershipLinkDesktop;
    await expect(membershipLink).toBeVisible();
    await membershipLink.click();
    await this.page.waitForLoadState("load");

    const checkoutLink = this.page
      .getByRole("link", { name: strings.membership.checkout })
      .first();
    await expect(checkoutLink).toBeVisible();
    await checkoutLink.click();
    await this.page.waitForLoadState("load");

    await this.fillCheckoutFormAndPlaceOrder();

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(3);
  }

  async verifyTermsAndConditionsPage() {
    await this.verifyUserIsLoggedIn();

    const membershipLink = this.commonPage.membershipLinkDesktop;
    await expect(membershipLink).toBeVisible();
    await membershipLink.click();
    await this.page.waitForLoadState("load");

    const checkoutLink = this.page
      .getByRole("link", { name: strings.membership.checkout })
      .first();
    await expect(checkoutLink).toBeVisible();
    await checkoutLink.click();
    await this.page.waitForLoadState("load");

    const termsAndCondButton = this.commonPage.termsAndConditionsLink;
    await expect(termsAndCondButton).toBeVisible();
    await termsAndCondButton.click();

    await this.page.waitForLoadState("load");
    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(3);
  }


  /// LOGIN AS ADMINN

  
  async verifyAdminPagesWithTwoClicks(locator: Locator) {
    await this.verifyAdminIsLoggedIn();
    await this.goToAdminProfile();

    await locator.click();
    await this.page.waitForLoadState("load");

    await this.verifyNavbarAndFooter();
    await this.goBackMultiple(2);
  }

  async verifyManageCoachesPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminManageCoachesLink
    );
  }

  async verifyManageMembershipsPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminManageMembershipsLink
    );
  }

  async verifyManageDiscountCodesPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminManageDiscountCodesLink
    );
  }

  async verifyManageUsersPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminManageUsersLink
    );
  }

  async verifyFeedbackListPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminListFeedbacksLink
    );
  }

  async verifyActiveMembershipsPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminActiveMembershipsLink
    );
  }

  async verifyOrdersListPage() {
    await this.verifyAdminPagesWithTwoClicks(
      this.commonPage.adminOrdersListLink
    );
  }

  async verifyUserDashboardFlow() {
    await this.goToUserProfile();
    await this.page.waitForLoadState("load");
    await this.verifyNavbarAndFooter();
    await this.goBackMultiple(1);
  }

  async verifyAdminDashboardFlow() {
    await this.verifyAdminIsLoggedIn();
    await this.goToAdminProfile();
    await this.page.waitForLoadState("load");

    await this.verifyNavbarAndFooter();

    await this.goBackMultiple(1);
  }
}
