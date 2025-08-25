import { BrowserContext, Page, expect } from "@playwright/test";
import CommonPage from "../pages/common.page";
import BaseActions from "./base.actions";
import routes from "../resources/routes.json";
import strings from "../resources/strings.json";

export default class CommonActions extends BaseActions {
  commonPage: CommonPage;

  constructor(page: Page, context: BrowserContext) {
    super(page, context);
    this.commonPage = new CommonPage(page, context);
  }

  async browserTabTitleAsExpected(browserTitle: string) {
    const pageTitle = await this.commonPage.tabTitle;
    const pageUrl = await this.commonPage.page.url();
    console.log(
      `Browser tab title for pageUrl - '${pageUrl}' is: '${pageTitle}'`
    );
    await expect(pageTitle, `Looking for page title '${browserTitle}'`).toBe(
      browserTitle
    );
  }

  async checkH1(header: string) {
    const locator = this.commonPage.h1Locator(header);
    await expect(locator).toBeVisible();
    await expect(locator).toHaveText(header);
    console.log(`Checked H1: "${header}" is visible and has correct text.`);
  }

  async checkH2(header: string) {
    const locator = this.commonPage.h2Locator(header);
    await expect(locator).toBeVisible();
    await expect(locator).toHaveText(header);
    console.log(`Checked H2: "${header}" is visible and has correct text.`);
  }

  async checkH3(header: string) {
    const locator = this.commonPage.h3Locator(header);
    await expect(locator).toBeVisible();
    await expect(locator).toHaveText(header);
    console.log(`Checked H3: "${header}" is visible and has correct text.`);
  }

  async checkP(text: string) {
    const locator = this.commonPage.pLocator(text);
    await expect(locator).toBeVisible();
    await expect(locator).toHaveText(text);
    console.log(`Checked P: "${text}" is visible and has correct text.`);
  }

  async checkLi(text: string) {
    const locator = this.commonPage.liLocator(text);
    await expect(locator).toBeVisible();
    await expect(locator).toHaveText(text);
    console.log(`Checked list item: "${text}"`);
  }

  async checkLinkByTextAndHref(text: string, expectedHref: string) {
    const locator = this.commonPage.getLinkByText(text);
    await expect(locator).toBeVisible();
    await expect(locator).toHaveAttribute("href", expectedHref);
    console.log(`Checked link href for text "${text}" is: "${expectedHref}"`);

    await locator.click();
    console.log(`Clicked link with text "${text}"`);

    const currentUrl = await this.commonPage.page.url();
    console.log(`Navigated to URL: ${currentUrl}`);

    await this.commonPage.page.goBack();
    console.log("Went back to previous page in the same tab");
  }

  async verifyImageSrc(imageSrc: string) {
    const imageLocator = this.commonPage.getImageBySrc(imageSrc);
    await expect(imageLocator).toBeVisible();
    await expect(imageLocator).toHaveAttribute("src", imageSrc);

  }

   async goBackMultiple(times: number) {
    for (let i = 0; i < times; i++) {
      await this.page.goBack();
      await this.page.waitForLoadState("load");
    }
  }











  async goToUserProfile() {
    const desktopButton = this.commonPage.userDashButtonDesktop;

    try {
      await expect(desktopButton).toBeVisible({ timeout: 5000 });
      await desktopButton.click();
      await this.page.waitForLoadState("load");
    } catch (error) {
      console.error("failed", error);
      throw new Error(
        "Uuser Dashboard desktop button not visible"
      );
    }
  }

  async goToAdminProfile() {
    const desktopButton = this.commonPage.adminDashboardButtonDesktop;

    try {
      await expect(desktopButton).toBeVisible({ timeout: 5000 });
      await desktopButton.click();
      await this.page.waitForLoadState("load");
    } catch (error) {
      console.error("fail", error);
      throw new Error(
        "admin Dashboard desktop button not visible"
      );
    }
  }

  async verifyUserIsLoggedIn() {
    await expect(this.commonPage.userDashButtonDesktop).toBeVisible({
      timeout: 5000,
    });
  }

  async verifyAdminIsLoggedIn() {
    await expect(this.commonPage.adminDashboardButtonDesktop).toBeVisible({
      timeout: 5000,
    });
  }
}
