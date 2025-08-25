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
});

test.describe("Home page tests", { tag: ["@regression", "@home"] }, async () => {
  test("Hero section", async ({ app }) => {
    And("the user sees hero carousel images");
    await test.step("Verify hero carousel images are visible", async () => {
      await app.home.verifyHeroCarousel();
    });

    And("the user sees hero title");
    await test.step("Verify hero title is visible", async () => {
      await app.home.verifyHeroTitle();
    });

    And("the user sees hero description");
    await test.step("Verify hero description is visible", async () => {
      await app.home.verifyHeroDescription();
    });

    And("the user sees and clicks on Join Now button");
    await test.step("Verify Join Now button is visible and clickable", async () => {
      await app.home.verifyJoinNowButton();
    });
  });

  test("Our Services section", async ({ app }) => {
    And("the user sees Our Services cards and main title");
    await test.step("Verify Our Services cards and title are visible", async () => {
      await app.home.verifyServicesSectionTitle();
      await app.home.verifyOurServicesCards();
    });

    And("the user sees Our Services cards titles");
    await test.step("Verify Our Services cards titles", async () => {
      await app.home.verifyServicesCardTitle();
    });

    And("the user sees Our Services cards description");
    await test.step("Verify Our Services cards description", async () => {
      await app.home.verifyServicesCardDescription();
    });

    And("the user sees Our Services section button See Services");
    await test.step("Verify Our Services section button", async () => {
      await app.home.verifySeeServicesButton();
    });
  });

  test("Our Memberships section", async ({ app }) => {
    And("the user sees Our Memberships cards and main title");
    await test.step("Verify Our Memberships cards and title are visible", async () => {
      await app.home.verifyMembershipsSectionTitle();
      await app.home.verifyOurMembershipsCards();
    });

    And("the user sees Our Memberships cards titles");
    await test.step("Verify Our Memberships cards titles", async () => {
      await app.home.verifyMembershipsCardTitle();
    });

    And("the user sees Our Memberships cards description");
    await test.step("Verify Our Memberships cards description", async () => {
      await app.home.verifyMembershipsCardDescription();
    });

    And("the user sees Our Memberships section button See Memberships");
    await test.step("Verify Our Memberships section button", async () => {
      await app.home.verifySeeMembershipsButton();
    });
  });

  test("About MadGym section", async ({ app }) => {
    And("the user sees About MadGym section title");
    await test.step("Verify About MadGym section title", async () => {
      await app.home.verifyAboutSectionTitle();
    });

    And("the user sees About MadGym section description");
    await test.step("Verify About MadGym section description", async () => {
      await app.home.verifyAboutSectionDescription();
    });

    And("the user sees About MadGym section button Learn More");
    await test.step("Verify About MadGym section button", async () => {
      await app.home.verifyLearnMoreButton();
    });
  });
});
