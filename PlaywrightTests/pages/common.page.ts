import { BrowserContext, Page } from "@playwright/test";
import BasePage from "./base.page";

export default class CommonPage extends BasePage {
  constructor(page: Page, context: BrowserContext) {
    super(page, context);
  }

  get tabTitle() {
    return this.page.title();
  }

  //-------- Headers & Text
  h1Locator(text: string) {
    return this.page.locator("h1", { hasText: text });
  }

  h2Locator(text: string) {
    return this.page.locator("h2", { hasText: text });
  }

  h3Locator(text: string) {
    return this.page.locator("h3", { hasText: text });
  }

  pLocator(text: string) {
    return this.page.locator("p", { hasText: text });
  }

  liLocator(text: string) {
    return this.page.locator("li", { hasText: text });
  }

  strongLocator(text: string) {
    return this.page.locator("strong", { hasText: text });
  }

  getLinkByText(text: string) {
    return this.page.locator("a", { hasText: text });
  }

  getImageBySrc(src: string) {
    return this.page.locator(`img[src="${src}"]`);
  }


  //-------- User Dashboard
  userProfileLink(username: string) {
    return this.page.getByRole("link", { name: username });
  }

  get userDashButtonDesktop() {
    return this.page.locator("#userDashboardButtonDesktop");
  }

  get userDashButtonMobile() {
    return this.page.locator("#userDashboardButtonMobile");
  }

  //-------- Navigation Links
  get aboutLinkDesktop() {
    return this.page.locator("#aboutLinkDesktop");
  }

  get aboutLinkMobile() {
    return this.page.locator("#aboutLinkMobile");
  }

  get servicesLinkDesktop() {
    return this.page.locator("#servicesLinkDesktop");
  }

  get servicesLinkMobile() {
    return this.page.locator("#servicesLinkMobile");
  }

  get membershipLinkDesktop() {
    return this.page.locator("#membershipLinkDesktop");
  }

  get membershipLinkMobile() {
    return this.page.locator("#membershipLinkMobile");
  }

  get contactLinkDesktop() {
    return this.page.locator("#contactLinkDesktop");
  }

  get contactLinkMobile() {
    return this.page.locator("#contactLinkMobile");
  }

  //-------- Admin Dashboard
  get adminDashboardButtonDesktop() {
    return this.page.locator("#adminDashboardButtonDesktop");
  }

  get adminDashboardButtonMobile() {
    return this.page.locator("#adminDashboardButtonMobile");
  }

  //-------- Auth Pages
  get authPageLinkDesktop() {
    return this.page.locator("#authPageLinkDesktop");
  }

  get authPageLinkMobile() {
    return this.page.locator("#authPageLinkMobile");
  }

  //-------- Profile & Settings
  get forgotPasswordLink() {
    return this.page.locator("#forgotPasswordLink");
  }

  get editProfileButton() {
    return this.page.locator("#editProfileLink");
  }

  get resetPasswordLink() {
    return this.page.locator("#resetPasswordLink");
  }

  get paymentHistoryLink() {
    return this.page.locator("#paymentHistoryLink");
  }

  get orderSuccessLink() {
    return this.page.locator("#orderSuccessLink");
  }

  get termsAndConditionsLink() {
    return this.page.locator("#termsAndCondLink");
  }

  //-------- Admin Panel Links
  get adminManageCoachesLink() {
    return this.page.locator("#adminManageCoaches");
  }

  get adminManageMembershipsLink() {
    return this.page.locator("#adminManageMemberships");
  }

  get adminManageDiscountCodesLink() {
    return this.page.locator("#adminManageDiscountCodes");
  }

  get adminListFeedbacksLink() {
    return this.page.locator("#adminListFeedbacks");
  }

  get adminActiveMembershipsLink() {
    return this.page.locator("#adminActiveMemberships");
  }

  get adminOrdersListLink() {
    return this.page.locator("#adminOrdersList");
  }

  get adminManageUsersLink() {
    return this.page.locator("#adminManageUsers");
  }

  get adminFeedbacksLink() {
    return this.page.locator("#adminFeedbacks");
  }

  get adminMembershipsLink() {
    return this.page.locator("#adminMemberships");
  }

  get adminLogoutLink() {
    return this.page.locator("#adminLogout");
  }


}
