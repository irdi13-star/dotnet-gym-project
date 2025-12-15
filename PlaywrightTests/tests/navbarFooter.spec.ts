import routes from "../resources/routes.json";
import strings from "../resources/strings.json";
import { And, Given } from "../utils/annotations";
import test from "./test";

test.beforeEach(async ({ app }) => {
  Given("the user accesses the MADGYM Home page");
  await test.step("Navigate to MADGYM Home page", async () => {
    await app.base.navigateTo(routes.homeLinks.home);
    await app.navigation.pageUrlAsExpected(routes.homeLinks.home);
    await app.common.browserTabTitleAsExpected(strings.home.homeTitle);
  });
});

test.describe(
  "Navbar&Footer tests on Home page",
  { tag: ["@regression", "@navbarFooter"] },
  async () => {
    test("Verify Logo", async ({ app }) => {
      And("the user sees Navigation bar");
      await test.step("Locate Navigation bar is visible", async () => {
        await app.navbarFooter.locateNavbar();
      });

      And("the user locates Logo");
      await test.step("Locate Logo", async () => {
        await app.navbarFooter.locateLogo();
      });

      And("the user sees Logo image");
      await test.step("Verify Logo image and image title", async () => {
        await app.navbarFooter.verifyLogoImg();
      });

      And("the user sees Logo text");
      await test.step("Verify Logo text", async () => {
        await app.navbarFooter.verifyLogoText();
      });
    });

    test("Verify Nav-bar Links text", async ({ app }) => {
      And("the user sees Links");
      await test.step("Verify links text", async () => {
        await app.navbarFooter.verifyNavbarTextLinks();
      });

      And("the user clicks on each Link");
      await test.step("Click on each Link", async () => {
        await app.navbarFooter.verifyNavbarLinks();
      });
    });

    test("Verify Footer", async ({ app }) => {
      And("the user sees Footer");
      await test.step("Verify Footer text", async () => {
        await app.navbarFooter.verifyFooterText();
      });
    });
  }
);

test.describe(
  "Navbar&Footer tests on Other pages",
  { tag: ["@regression", "@navbarFooter"] },
  async () => {
    test("Main links", async ({ app }) => {
      And("the user verifies Navbar and Footer on About page");
      await test.step("Verify Navbar and Footer on About page", async () => {
        await app.navbarFooter.verifyAboutFlow();
      });

      And("the user verifies Navbar and Footer on Services page");
      await test.step("Verify Navbar and Footer on Services page", async () => {
        await app.navbarFooter.verifyServicesFlow();
      });



      And("the user verifies Navbar and Footer on Services - Personal Training page");
      await test.step("Verify Navbar and Footer on Services page - Personal Training page", async () => {
        await app.navbarFooter.verifyPersonalTrainingFlow(
        );
      });

      And("the user verifies Navbar and Footer on Services - Group Programs page");
      await test.step("Verify Navbar and Footer on Services page - Group Programs page", async () => {
        await app.navbarFooter.verifyGroupClassesFlow();
      });

      And("the user verifies Navbar and Footer on Services - Nutrition Coaching page");
      await test.step("Verify Navbar and Footer on Services page - Nutrition Coaching page", async () => {
        await app.navbarFooter.verifyNutritionCoachingFlow();
      });








      And("the user verifies Navbar and Footer on Membership page");
      await test.step("Verify Navbar and Footer on Membership page", async () => {
        await app.navbarFooter.verifyMembershipFlow();
      });

      And("the user verifies Navbar and Footer on Contact page");
      await test.step("Verify Navbar and Footer on Contact page", async () => {
        await app.navbarFooter.verifyContactFlow();
      });

      And("the user verifies Navbar and Footer on Login page");
      await test.step("Verify Navbar and Footer on Login page", async () => {
        await app.navbarFooter.verifyLoginFlow();
      });
    });


    test("Main user pages", async ({ app }) => {
      And("the user logs in");
      await test.step("Login as user", async () => {
        await app.navbarFooter.navigateToPageByLinkText(
          strings.navBar.login,
          routes.allPages.authLoginPage
        );
        await app.navbarFooter.loginAsUser();
      });

      And("the user verifies Navbar and Footer on User Dashboard");
      await test.step("Verify User Dashboard page", async () => {
        await app.navbarFooter.verifyUserDashboardFlow();
      });

      And("the user verifies Navbar and Footer on Edit Profile page");
      await test.step("Verify Edit Profile page", async () => {
        await app.navbarFooter.verifyEditProfilePage();
      });

      And("the user verifies Navbar and Footer on Change Password page");
      await test.step("Verify Change Password page", async () => {
        await app.navbarFooter.verifyChangePasswordPage();
      });

      And("the user verifies Navbar and Footer on Reset Password page");
      await test.step("Verify Reset Password page", async () => {
        await app.navbarFooter.verifyResetPasswordPage();
      });

      And("the user verifies Navbar and Footer on Payment History page");
      await test.step("Verify Payment History page", async () => {
        await app.navbarFooter.verifyPaymentHistoryPage();
      });

      And("the user verifies Navbar and Footer on Checkout page");
      await test.step("Verify Membership Checkout page", async () => {
        await app.navbarFooter.verifyMembershipCheckoutPage();
      });

      And("the user verifies Navbar and Footer on Order Success page");
      await test.step("Verify Order Success page", async () => {
        await app.navbarFooter.verifyOrderSuccessPage();
      });

      And("the user verifies Navbar and Footer on Terms and Conditions page");
      await test.step("Verify Terms and Conditions page", async () => {
        await app.navbarFooter.verifyTermsAndConditionsPage();
      });
    });

    test("Main admin pages", async ({ app }) => {
      And("the admin logs in");
      await test.step("Login as admin", async () => {
        await app.navbarFooter.navigateToPageByLinkText(
          strings.navBar.login,
          routes.allPages.authLoginPage
        );
        await app.navbarFooter.loginAsAdmin();
      });

      And("the user verifies Navbar and Footer on Admin Dashboard");
      await test.step("Verify Admin Dashboard page", async () => {
        await app.navbarFooter.verifyAdminDashboardFlow();
      });

      And("the admin verifies Navbar and Footer on Manage Coaches page");
      await test.step("Verify Manage Coaches page", async () => {
        await app.navbarFooter.verifyManageCoachesPage();
      });

      And("the admin verifies Navbar and Footer on Manage Memberships page");
      await test.step("Verify Manage Memberships page", async () => {
        await app.navbarFooter.verifyManageMembershipsPage();
      });

      And("the admin verifies Navbar and Footer on Manage Discount Codes page");
      await test.step("Verify Manage Discount Codes page", async () => {
        await app.navbarFooter.verifyManageDiscountCodesPage();
      });

      And("the admin verifies Navbar and Footer on Manage Users page");
      await test.step("Verify Manage Users page", async () => {
        await app.navbarFooter.verifyManageUsersPage();
      });

      And("the admin verifies Navbar and Footer on Feedback List page");
      await test.step("Verify Feedback List page", async () => {
        await app.navbarFooter.verifyFeedbackListPage();
      });

      And("the admin verifies Navbar and Footer on Active Memberships page");
      await test.step("Verify Active Memberships page", async () => {
        await app.navbarFooter.verifyActiveMembershipsPage();
      });

      And("the admin verifies Navbar and Footer on Orders List page");
      await test.step("Verify Orders List page", async () => {
        await app.navbarFooter.verifyOrdersListPage();
      });
    });
  }
);
