import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { And, Given, Then } from "../utils/annotations";
import test from "./test";

test.beforeEach(async ({ app }) => {
  Given("the user accesses the MADGYM Home page");
  await test.step("Navigate to MADGYM Home page", async () => {
    await app.base.navigateTo(routes.homeLinks.home);
    await app.navigation.pageUrlAsExpected(routes.homeLinks.home);
    await app.common.browserTabTitleAsExpected(strings.home.homeTitle);
  });

  And("the user navigates to About page");
    await test.step("Navigate to About page", async () => {
      await app.base.navigateTo(routes.allPages.aboutPage);
      await app.navigation.pageUrlAsExpected(routes.allPages.aboutPage);
      await app.common.browserTabTitleAsExpected(strings.aboutPage.aboutPageTabTitle)
    });

});

test.describe("About page tests", { tag: ["@smoke", "@about"] }, async () => {
  test("Verify information", async ({ app }) => {
    And("the user sees page information");
    await test.step("Verify information is visible", async () => {
      await app.about.verifyAboutPageContent();
    });

    And("the user sees Register button");
    await test.step("Verify Register button", async()=> {
      await app.about.verifyRegisterLink();
    });
  });
});
