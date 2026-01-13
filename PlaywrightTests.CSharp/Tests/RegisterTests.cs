namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Utils;

[TestFixture]
[Category("regression")]
[Category("registration")]
public class RegisterTests : BaseTest
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
    public async Task Should_Register_With_Valid_Credentials()
    {
    
        LogInfo("Navigate to register form");
        await App.Auth.VerifyRegisterFormContainer();
        LogPass("Register form displayed");

        LogInfo("Fill registration form with valid data");
        await App.Auth.RegisterWithValidUser();
        LogPass("Registration succeeded");

        LogInfo("Verify redirect to login page");
        await App.Navigation.PageUrlContains("AuthPage");
        LogPass("Redirect to login page verified");
    }

    [Test]
    public async Task Should_Show_Errors_For_Invalid_Credentials()
    {
        LogInfo("Navigate to register form");
        await App.Auth.VerifyRegisterFormContainer();
        LogPass("Register form displayed");

        LogInfo("Fill registration form with invalid credentials");
        await App.Auth.RegisterWithWrongUser();
        LogPass("Error messages displayed for invalid credentials");
    }

    [Test]
    public async Task Should_Show_Errors_For_Blank_Fields()
    {
        LogInfo("Navigate to register form");
        await App.Auth.VerifyRegisterFormContainer();
        LogPass("Register form displayed");

        LogInfo("Submit empty registration form and check errors");
        await App.Auth.RegisterWithBlankFields();
        LogPass("Error messages displayed for blank fields");
    }

    [Test]
    public async Task Should_Display_Login_Link_In_Register_Form()
    {
        LogInfo("Verify register form container is visible");
        await App.Auth.VerifyRegisterFormContainer();
        LogPass("Register form container verified");

        LogInfo("Verify have account subtext");
        await App.Auth.VerifyHaveAccSubtext();
        LogPass("Have account subtext verified");

        LogInfo("Verify login link and navigation");
        await App.Auth.VerifyLoginLink();
        LogPass("Login link verified");
    }

    [Test]
    public async Task Should_Display_All_Register_Form_Elements()
    {
        LogInfo("Verify register form container is visible");
        await App.Auth.VerifyRegisterFormContainer();
        LogPass("Register form container verified");

        LogInfo("Verify Join Us title is correct");
        await App.Auth.VerifyJoinUsText();
        LogPass("Join Us title verified");

        LogInfo("Verify Create Account text is correct");
        await App.Auth.VerifyCreateAccText();
        LogPass("Create Account text verified");

        LogInfo("Verify register username input");
        await App.Auth.VerifyRegisterUserName();
        LogPass("Username input verified");

        LogInfo("Verify register email input");
        await App.Auth.VerifyRegisterEmail();
        LogPass("Email input verified");

        LogInfo("Verify register password input");
        await App.Auth.VerifyRegisterPassword();
        LogPass("Password input verified");

        LogInfo("Verify register submit button");
        await App.Auth.VerifyRegisterSubmitBtn();
        LogPass("Register submit button verified");
    }
}