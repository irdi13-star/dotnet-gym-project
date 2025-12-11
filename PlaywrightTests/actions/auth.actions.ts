import BaseActions from "./base.actions";
import HomePage from "../pages/home.page";
import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { BrowserContext, expect, Page } from "@playwright/test";
import CommonActions from "./common.actions";
import AuthPage from "../pages/auth.page";

export default class AuthActions extends CommonActions {
  auth: AuthPage;

  constructor(page: Page, context: BrowserContext) {
    super(page, context);
    this.auth = new AuthPage(page, context);
  }

  async verifyMadGymImageContainter() {
    const container = this.auth.madGymImageContainter;
    await expect(container).toBeVisible();
  }

  async verifyMadGymText() {
    const title = this.auth.madGymText;
    await expect(title).toBeVisible();
    await expect(title).toHaveText(strings.auth.madGymTitle);
  }

  async verifyUnlockSubtext() {
    const subtext = this.auth.unlockSubtext;
    await expect(subtext).toBeVisible();
    await expect(subtext).toHaveText(strings.auth.unlockSubtext);
  }

  /// ---

  async verifyRegisterFormContainer() {
    await this.auth.registerLink.click();
    await expect(this.auth.registerFormContainer).toBeVisible();
  }

  async verifyJoinUsText() {
    const heading = this.auth.joinUsText;
    await expect(heading).toBeVisible();
    await expect(heading).toHaveText(strings.auth.joinUsTitle);
  }

  async verifyCreateAccText() {
    const text = this.auth.createAccText;
    await expect(text).toBeVisible();
    await expect(text).toHaveText(strings.auth.createAccText);
  }

  async verifyRegisterUserName() {
    const input = this.auth.registerUsernameField;
    await expect(input).toBeVisible();
    await expect(input).toHaveAttribute(
      "placeholder",
      strings.auth.registerUsernamePlaceholder
    );
    await expect(input).toHaveAttribute(
      "title",
      strings.auth.registerUsernameTitle
    );
  }

  async verifyRegisterEmail() {
    const input = this.auth.registerEmailField;
    await expect(input).toBeVisible();
    await expect(input).toHaveAttribute(
      "placeholder",
      strings.auth.registerEmailPlaceholder
    );
    await expect(input).toHaveAttribute(
      "title",
      strings.auth.registerEmailTitle
    );
  }

  async verifyRegisterPassword() {
    const input = this.auth.registerPasswordField;
    await expect(input).toBeVisible();
    await expect(input).toHaveAttribute(
      "placeholder",
      strings.auth.registerPasswordPlaceholder
    );
    await expect(input).toHaveAttribute(
      "title",
      strings.auth.registerPasswordTitle
    );
  }

  async verifyRegisterSubmitBtn() {
    const button = this.auth.registerSubmitBtn;
    await expect(button).toBeVisible();
    await expect(button).toHaveText(strings.auth.registerButton);
  }

  async verifyHaveAccSubtext() {
    const text = this.auth.haveAccSubtext;
    await expect(text).toBeVisible();
    await expect(text).toContainText(strings.auth.alreadyHaveAccText);
  }

  async verifyLoginLink() {
    const link = this.auth.loginLink;
    await expect(link).toBeVisible();
    await expect(link).toHaveText(strings.auth.loginLinkText);
  }

  async verifyLoginFormContainer() {
    const container = this.auth.loginFormContainer;
    await expect(container).toBeVisible();
  }

  async verifyWelcomeText() {
    const heading = this.auth.welcomeText;
    await expect(heading).toBeVisible();
    await expect(heading).toHaveText(strings.auth.welcomeTitle);
  }

  async verifyLoginSubtext() {
    const subtext = this.auth.loginSubtext;
    await expect(subtext).toBeVisible();
    await expect(subtext).toHaveText(strings.auth.loginSubtext);
  }

  async verifyLoginUserName() {
    const input = this.auth.loginUserName;
    await expect(input).toBeVisible();
    await expect(input).toHaveAttribute(
      "placeholder",
      strings.auth.loginUsernamePlaceholder
    );
    await expect(input).toHaveAttribute(
      "title",
      strings.auth.loginUsernameTitle
    );
  }

  async verifyLoginPassword() {
    const input = this.auth.loginPassword;
    await expect(input).toBeVisible();
    await expect(input).toHaveAttribute(
      "placeholder",
      strings.auth.loginPasswordPlaceholder
    );
    await expect(input).toHaveAttribute(
      "title",
      strings.auth.loginPasswordTitle
    );
  }

  async verifyLoginSubmitBtn() {
    const button = this.auth.loginSubmitBtn;
    await expect(button).toBeVisible();
    await expect(button).toHaveText(strings.auth.loginButton);
  }

  async verifyOrSubtext() {
    const text = this.auth.orSubtext;
    await expect(text).toBeVisible();
    await expect(text).toHaveText(strings.auth.orText);
  }

  async verifyGoogleBtn() {
    const button = this.auth.googleBtn;
    await expect(button).toBeVisible();
  }

  async verifyFacebookBtn() {
    const button = this.auth.facebookBtn;
    await expect(button).toBeVisible();
  }

  async verifyAppleBtn() {
    const button = this.auth.appleBtn;
    await expect(button).toBeVisible();
  }

  async verifyRegisterNowSubtext() {
    const locator = this.auth.registerNowSubtext;
    await expect(locator).toBeVisible();
    await expect(locator).toContainText(strings.auth.dontHaveAccText);
  }

  async verifyRegisterLink() {
    const link = this.auth.registerLink;
    await expect(link).toBeVisible();
    await expect(link).toHaveText(strings.auth.registerNowLink);
  }

  async verifyForgotPasswordSubtext() {
    const text = this.auth.forgotPasswordSubtext;
    await expect(text).toBeVisible();
    await expect(text).toContainText(strings.auth.forgotPasswordText);
  }

  async verifyForgotPasswordLink() {
    const link = this.auth.forgotPasswordLink;
    await expect(link).toBeVisible();
    await expect(link).toContainText(strings.auth.resetPasswordLink);
  }

  async loginAsUserTemplate(username: string, password: string) {
    await this.auth.usernameInput.fill(username);
    await this.auth.passwordInput.fill(password);
    await this.auth.loginSubmitBtn.click();
    await this.page.waitForLoadState("load", { timeout: 10000 });
    await expect(this.commonPage.userDashButtonDesktop).toBeVisible({
      timeout: 10000,
    });
  }

  async loginAsAdminTemplate(username: string, password: string) {
    await this.auth.usernameInput.fill(username);
    await this.auth.passwordInput.fill(password);
    await this.auth.loginSubmitBtn.click();
    await this.page.waitForLoadState("load", { timeout: 10000 });
    await expect(this.commonPage.adminDashboardButtonDesktop).toBeVisible({
      timeout: 10000,
    });
  }

  async loginAsUser() {
    const username = strings.loginCredentials.username;
    const password = strings.loginCredentials.password;

    await this.loginAsUserTemplate(username, password);
    await expect(this.page).toHaveURL(routes.allPages.adminDashboardPage);
  }

  async loginAsAdmin() {
    const username = strings.loginCredentials.adminUsername;
    const password = strings.loginCredentials.adminPassword;

    await this.loginAsAdminTemplate(username, password);
    await expect(this.page).toHaveURL("https://localhost:44336/");
  }

  async loginWithWrongUser() {
    await this.auth.loginUserName.fill(strings.loginWrongCredentials.wrongUser);
    await this.auth.loginPassword.fill(
      strings.loginWrongCredentials.wrongPassword
    );
    await this.auth.loginSubmitBtn.click();
    await this.page.waitForLoadState("load");

    await expect(this.auth.loginErrorMessage).toHaveText(
      strings.authErrors.invalidCredentials
    );
  }

  async registerWithValidUser() {
    await this.auth.registerUsernameInput.fill(
      strings.registerCredentials.registerUsername
    );
    await this.auth.registerEmailInput.fill(
      strings.registerCredentials.registerEmail
    );
    await this.auth.registerPasswordInput.fill(
      strings.registerCredentials.registerPassword
    );
    await this.auth.registerSubmitBtn.click();
    await this.page.waitForLoadState("load");

    await expect(this.auth.loginFormContainer).toBeVisible();
  }

  async registerWithWrongUser() {
    await this.auth.registerUsernameInput.fill(
      strings.registerWrongCredentials.registerUsername
    );
    await this.auth.registerEmailInput.fill(
      strings.registerWrongCredentials.registerEmail
    );
    await this.auth.registerPasswordInput.fill(
      strings.registerWrongCredentials.registerPassword
    );
    await this.auth.registerSubmitBtn.click();
    await this.page.waitForLoadState("load");

    await expect(this.auth.registerUsernameError).toHaveText(
      strings.authErrors.invalidUsername
    );
    await expect(this.auth.registerEmailError).toHaveText(
      strings.authErrors.invalidEmail
    );
    await expect(this.auth.registerPasswordError).toHaveText(
      strings.authErrors.invalidPassword
    );
  }

  async registerWithBlankFields() {
    await this.auth.registerUsernameInput.fill("");
    await this.auth.registerEmailInput.fill("");
    await this.auth.registerPasswordInput.fill("");
    await this.auth.registerSubmitBtn.click();
    await this.page.waitForLoadState("load");

    await expect(this.auth.registerUsernameError).toHaveText(
      strings.authErrors.blankFields.username
    );
    await expect(this.auth.registerEmailError).toHaveText(
      strings.authErrors.blankFields.email
    );
    await expect(this.auth.registerPasswordError).toHaveText(
      strings.authErrors.blankFields.password
    );
  }

  async loginWithBlankFields() {
    await this.auth.loginUserName.fill("");
    await this.auth.loginPassword.fill("");
    await this.auth.loginSubmitBtn.click();
    await this.page.waitForLoadState("load");

    await expect(this.auth.loginUserNameError).toHaveText(
      strings.authErrors.blankFields.username
    );
    await expect(this.auth.loginPasswordError).toHaveText(
      strings.authErrors.blankFields.password
    );
  }
}
