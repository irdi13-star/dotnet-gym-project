import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { And, Given } from "../utils/annotations";
import test from "./test";

test.beforeEach(async ({ app }) => {
  Given("the user accesses MADGYM Home page");
  await test.step("Navigate to MADGYM Home page", async () => {
    await app.base.navigateTo(routes.homeLinks.home);
    await app.navigation.pageUrlAsExpected(routes.homeLinks.home);
    await app.common.browserTabTitleAsExpected(strings.home.homeTitle);
  });

  And("the user accesses Auth page");
  await test.step("Navigate to Auth page", async () => {
    await app.navbarFooter.navigateToPageByLinkText(
      strings.navBar.login,
      routes.allPages.authLoginPage
    );
    await app.navigation.pageUrlAsExpected(routes.navbarLinks.login);
    await app.common.browserTabTitleAsExpected(strings.auth.authTabTitle);
  });
});

test.describe(
  "Auth page general tests",
  { tag: ["@regression", "@auth"] },
  async () => {
    test("Login form section", async ({ app }) => {
      And("the user sees the MAD GYM image container");
      await test.step("Verify MAD GYM image container is visible", async () => {
        await app.auth.verifyMadGymImageContainter();
      });

      And("the user sees the MAD GYM title");
      await test.step("Verify MAD GYM title is correct", async () => {
        await app.auth.verifyMadGymText();
      });

      And("the user sees the unlock subtext");
      await test.step("Verify unlock subtext is correct", async () => {
        await app.auth.verifyUnlockSubtext();
      });

      And("the user sees the login form container");
      await test.step("Verify login form container is visible", async () => {
        await app.auth.verifyLoginFormContainer();
      });

      And("the user sees the Welcome title");
      await test.step("Verify welcome title is correct", async () => {
        await app.auth.verifyWelcomeText();
      });

      And("the user sees the login subtext");
      await test.step("Verify login subtext is correct", async () => {
        await app.auth.verifyLoginSubtext();
      });

      And("the user sees the username input");
      await test.step("Verify login username input", async () => {
        await app.auth.verifyLoginUserName();
      });

      And("the user sees the password input");
      await test.step("Verify login password input", async () => {
        await app.auth.verifyLoginPassword();
      });

      And("the user sees the LOGIN button");
      await test.step("Verify login submit button", async () => {
        await app.auth.verifyLoginSubmitBtn();
      });
    });

    test("Social login section", async ({ app }) => {
      And("the user sees the OR subtext");
      await test.step("Verify OR subtext", async () => {
        await app.auth.verifyOrSubtext();
      });

      And("the user sees the Google button");
      await test.step("Verify Google login button", async () => {
        await app.auth.verifyGoogleBtn();
      });

      And("the user sees the Facebook button");
      await test.step("Verify Facebook login button", async () => {
        await app.auth.verifyFacebookBtn();
      });

      And("the user sees the Apple button");
      await test.step("Verify Apple login button", async () => {
        await app.auth.verifyAppleBtn();
      });
    });

    test("Login form links", async ({ app }) => {
      And("the user sees the 'Don't have an account?' text");
      await test.step("Verify register now subtext", async () => {
        await app.auth.verifyRegisterNowSubtext();
      });

      And("the user sees and clicks the Register Now link");
      await test.step("Verify register link and navigation", async () => {
        await app.auth.verifyRegisterLink();
        // TODO: to add click on link and go back
      });

      And("the user sees the 'Forgot password?' text");
      await test.step("Verify forgot password subtext", async () => {
        await app.auth.verifyForgotPasswordSubtext();
      });

      And("the user sees and clicks the Reset Password link");
      await test.step("Verify forgot password link and navigation", async () => {
        await app.auth.verifyForgotPasswordLink();
        // TODO: to add click on link and go back
      });
    });

    test("Register form section", async ({ app }) => {
      And("the user sees the register form container");
      await test.step("Verify register form container is visible", async () => {
        await app.auth.verifyRegisterFormContainer();
      });

      And("the user sees the Join Us title");
      await test.step("Verify Join Us title is correct", async () => {
        await app.auth.verifyJoinUsText();
      });

      And("the user sees the Create Account text");
      await test.step("Verify Create Account text is correct", async () => {
        await app.auth.verifyCreateAccText();
      });

      And("the user sees the username input");
      await test.step("Verify register username input", async () => {
        await app.auth.verifyRegisterUserName();
      });

      And("the user sees the email input");
      await test.step("Verify register email input", async () => {
        await app.auth.verifyRegisterEmail();
      });

      And("the user sees the password input");
      await test.step("Verify register password input", async () => {
        await app.auth.verifyRegisterPassword();
      });

      And("the user sees the REGISTER button");
      await test.step("Verify register submit button", async () => {
        await app.auth.verifyRegisterSubmitBtn();
      });
    });

    test("Register form links", async ({ app }) => {
      And("the user sees the register form container");
      await test.step("Verify register form container is visible", async () => {
        await app.auth.verifyRegisterFormContainer();
      });

      And("the user sees the 'Already have an account?' text");
      await test.step("Verify have account subtext", async () => {
        await app.auth.verifyHaveAccSubtext();
      });

      And("the user sees and clicks the Login link");
      await test.step("Verify login link and navigation", async () => {
        await app.auth.verifyLoginLink();
        //TODO: to add click on login link and go back
      });
    });
  }
);

test.describe(
  "Credentials for Login",
  { tag: ["@regression", "@auth"] },
  async () => {
    test("Login with valid user credentials", async ({ app }) => {
      And("the user fills in the valid username and password");
      await test.step("Fill username and password fields", async () => {
        await app.auth.loginAsUser();
      });
    });

    test("Login with wrong credentials", async ({ app }) => {
      And("the user fills in a wrong username and sees error message");
      await test.step("Fill login fields with wrong username", async () => {
        await app.auth.loginWithWrongUser();
      });
    });

    test("Login with blank fields", async ({ app }) => {
      And("the user submits the login form without filling fields");
      await test.step("Submit empty login form and check errors", async () => {
        await app.auth.loginWithBlankFields();
      });
    });
  }
);

test.describe(
  "Credentials for Register",
  { tag: ["@regression", "@auth"] },
  async () => {
    test("Register with valid credentials", async ({ app }) => {
      And("the user fills in valid registration details");
      await test.step("Fill registration form", async () => {
        await app.auth.verifyRegisterFormContainer();
        await app.auth.registerWithValidUser();
      });
    });

    test("Register with invalid credentials", async ({ app }) => {
      And(
        "the user fills in invalid registration details and sees error message"
      );
      await test.step("Fill registration form with wrong credentials", async () => {
        await app.auth.verifyRegisterFormContainer();
        await app.auth.registerWithWrongUser();
      });
    });

    test("Register with blank fields", async ({ app }) => {
      And("the user submits the registration form without filling fields");
      await test.step("Submit empty registration form and check errors", async () => {
        await app.auth.verifyRegisterFormContainer();
        await app.auth.registerWithBlankFields();
      });
    });
  }
);