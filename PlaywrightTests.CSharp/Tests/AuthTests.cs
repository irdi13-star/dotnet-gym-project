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
        LogInfo("Navigate to login page");
        await App.Base.NavigateTo(Routes.AuthLinks.Login);
        await App.Navigation.PageUrlAsExpected(Routes.AuthLinks.Login);
        LogPass("Navigation to home succeeded");
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