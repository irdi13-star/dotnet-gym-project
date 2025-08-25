import { BrowserContext, Page } from "@playwright/test";
import BasePage from "./base.page";

export default class AuthPage extends BasePage {
  get madGymImageContainter() {
    return this.page.locator("#madGymImageContainter");
  }

  get madGymText() {
    return this.page.locator("#madGymText");
  }

  get unlockSubtext() {
    return this.page.locator("#unlockSubtext");
  }

  get registerFormContainer() {
    return this.page.locator("#registerFormContainer");
  }

  get joinUsText() {
    return this.page.locator("#joinUsText");
  }

  get createAccText() {
    return this.page.locator("#createAccText");
  }

  get registerUsernameField() {
    return this.page.locator("#registerUsernameField  input");
  }

  get registerUserName() {
    return this.page.locator("#registerUsernameField");
  }

  get registerEmailField() {
    return this.page.locator("#registerEmailField");
  }

  get registerPasswordField() {
    return this.page.locator("#registerPasswordField");
  }

  get registerSubmitBtn() {
    return this.page.locator("#registerSubmitBtn");
  }

  get haveAccSubtext() {
    return this.page.locator("#haveAccSubtext");
  }

  get loginLink() {
    return this.page.locator("#loginLink");
  }

  get loginFormContainer() {
    return this.page.locator("#loginFormContainer");
  }

  get welcomeText() {
    return this.page.locator("#welcomeText");
  }

  get loginSubtext() {
    return this.page.locator("#loginSubtext");
  }

  get usernameField() {
    return this.page.locator("#usernameField");
  }

  get loginUserName() {
    return this.page.locator("#loginUserName");
  }

  get passwordField() {
    return this.page.locator("#passwordField");
  }

  get loginPassword() {
    return this.page.locator("#loginPassword");
  }

  get loginSubmitBtn() {
    return this.page.locator("#loginSubmitBtn");
  }

  get orSubtext() {
    return this.page.locator("#orSubtext");
  }

  get googleBtn() {
    return this.page.locator("#googleBtn");
  }

  get facebookBtn() {
    return this.page.locator("#facebookBtn");
  }

  get appleBtn() {
    return this.page.locator("#appleBtn");
  }

  get registerNowSubtext() {
    return this.page.locator("#registerNowSubtext");
  }

  get registerLink() {
    return this.page.locator("#registerLink");
  }

  get forgotPasswordSubtext() {
    return this.page.locator("#forgotPasswordSubtext");
  }

  get forgotPasswordLink() {
    return this.page.locator("#forgotPasswordLink");
  }
  

    //-------- Auth
  get usernameInput() {
    return this.page.locator('input[name="Login.UserName"]');
  }

  get passwordInput() {
    return this.page.locator('input[name="Login.Password"]');
  }

  get loginButton() {
    return this.page.locator("#LoginSubmitBtn");
  }

  
}
