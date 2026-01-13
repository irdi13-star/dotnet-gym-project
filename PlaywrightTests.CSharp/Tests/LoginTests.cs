namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Utils;

[TestFixture]
[Category("regression")]
[Category("login")]
public class LoginTests : BaseTest
{
    [SetUp]
    public async Task BeforeEach()
    {
        LogInfo("Navigate to login page");
        await App.Base.NavigateTo(Routes.AuthLinks.Login);
        await App.Navigation.PageUrlAsExpected(Routes.AuthLinks.Login);
        await App.Common.BrowserTabTitleAsExpected(Strings.Auth.AuthTabTitle);
        LogPass("Navigation to Auth page succeeded");
    }

    [Test]
    public async Task Should_Display_All_Login_Form_Elements()
    {
        LogInfo("Verify MAD GYM image container is visible");
        await App.Auth.VerifyMadGymImageContainer();
        LogPass("MAD GYM image container verified");

        LogInfo("Verify MAD GYM title is correct");
        await App.Auth.VerifyMadGymText();
        LogPass("MAD GYM title verified");

        LogInfo("Verify unlock subtext is correct");
        await App.Auth.VerifyUnlockSubtext();
        LogPass("Unlock subtext verified");

        LogInfo("Verify login form container is visible");
        await App.Auth.VerifyLoginFormContainer();
        LogPass("Login form container verified");

        LogInfo("Verify welcome title is correct");
        await App.Auth.VerifyWelcomeText();
        LogPass("Welcome title verified");

        LogInfo("Verify login subtext is correct");
        await App.Auth.VerifyLoginSubtext();
        LogPass("Login subtext verified");

        LogInfo("Verify login username input");
        await App.Auth.VerifyLoginUserName();
        LogPass("Username input verified");

        LogInfo("Verify login password input");
        await App.Auth.VerifyLoginPassword();
        LogPass("Password input verified");

        LogInfo("Verify login submit button");
        await App.Auth.VerifyLoginSubmitButton();
        LogPass("Login submit button verified");
    }

    [Test]
    public async Task Should_Display_All_Social_Login_Buttons()
    {
        LogInfo("Verify OR subtext");
        await App.Auth.VerifyOrSubtext();
        LogPass("OR subtext verified");

        LogInfo("Verify Google login button");
        await App.Auth.VerifyGoogleBtn();
        LogPass("Google button verified");

        LogInfo("Verify Facebook login button");
        await App.Auth.VerifyFacebookBtn();
        LogPass("Facebook button verified");

        LogInfo("Verify Apple login button");
        await App.Auth.VerifyAppleBtn();
        LogPass("Apple button verified");
    }

    [Test]
    public async Task Should_Display_Register_And_ForgotPassword_Links()
    {
        LogInfo("Verify register now subtext");
        await App.Auth.VerifyRegisterNowSubtext();
        LogPass("Register now subtext verified");

        LogInfo("Verify register link and navigation");
        await App.Auth.VerifyRegisterLink();
        LogPass("Register link verified");

        LogInfo("Verify forgot password subtext");
        await App.Auth.VerifyForgotPasswordSubtext();
        LogPass("Forgot password subtext verified");

        LogInfo("Verify forgot password link and navigation");
        await App.Auth.VerifyForgotPasswordLink();
        LogPass("Forgot password link verified");
    }

    [Test]
    public async Task Should_Login_With_Valid_Credentials()
    {
        LogInfo("Fill username and password fields");
        await App.Auth.LoginAsUser();
        LogPass("Login with valid credentials succeeded");

        LogInfo("Verify successful login redirect");
        await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        LogPass("Redirect to home page verified");
    }

    [Test]
    public async Task Should_Show_Error_For_Wrong_Credentials()
    {
        LogInfo("Fill login fields with wrong username");
        await App.Auth.LoginWithWrongUser();
        LogPass("Error message displayed for wrong credentials");
    }

    [Test]
    public async Task Should_Show_Errors_For_Blank_Fields()
    {
        LogInfo("Submit empty login form and check errors");
        await App.Auth.LoginWithBlankFields();
        LogPass("Error messages displayed for blank fields");
    }
}