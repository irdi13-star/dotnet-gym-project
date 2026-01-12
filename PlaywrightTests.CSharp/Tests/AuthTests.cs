namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Helpers;
using PlaywrightTests.CSharp.Utils;

[TestFixture]
[Category("regression")]
[Category("auth")]
public class AuthTests : BaseTest
{
    [SetUp]
    public async Task BeforeEach()
    {
        LogInfo("Navigate to home page");
        await App.Base.NavigateTo(Routes.HomeLinks.Home);
        await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        LogPass("Navigation to home succeeded");

        LogInfo("Navigate to login page");
        await App.Auth.ClickLoginLink();
        await App.Navigation.PageUrlAsExpected(Routes.AuthLinks.Login);
        await App.Common.BrowserTabTitleAsExpected(Strings.Auth.AuthTabTitle);
        LogPass("Navigation to authentication succeeded");
    }

    [Test]
    public async Task UserCanRegister()
    {
        LogInfo("Register a new user");
        await App.Auth.RegisterWithValidUser();
        LogPass("Registration succeeded");

        LogInfo("Verify redirect to login page");
        await App.Navigation.PageUrlContains("AuthPage");
        LogPass("Navigation to home succeeded");
    }

    [Test]
    public async Task UserCanLogin()
    {
        LogInfo("Login with valid user");
        await App.Auth.LoginAsUser();
        LogPass("Login succeeded");

        LogInfo("Verify successful login");
        await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        LogPass("Login succeeded");
    }
}