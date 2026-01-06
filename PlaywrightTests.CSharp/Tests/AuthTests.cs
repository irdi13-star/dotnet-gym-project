namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Helpers;
using PlaywrightTests.CSharp.Utils;
using AventStack.ExtentReports;

[TestFixture]
[Category("regression")]
[Category("auth")]
public class AuthTests : BaseTest
{
    [SetUp]
    public async Task BeforeEach()
    {
        LogInfo("Navigate to home page");
        await App.Base.NavigateTo(Routes.AuthLinks.Login);
        LogPass("Navigation to home succeeded");
    }

    [Test]
    public async Task UserCanRegister()
    {
        var (username, email, password) = TestDataGenerator.GenerateUserCredentials();

        LogInfo($"Register with username: {username}");
        await App.Auth.Register(username, email, password);
        LogPass("Registration succeeded");

        LogInfo("Verify redirect to login page");
        await App.Navigation.PageUrlContains("AuthPage");
        LogPass("Navigation to home succeeded");
    }

    [Test]
    public async Task UserCanLogin()
    {
        LogInfo($"Login with username: {Strings.Auth.ValidUsername}");
        await App.Base.NavigateTo(Routes.HomeLinks.Home);
        await App.Auth.Login(Strings.Auth.ValidUsername, Strings.Auth.ValidPassword);
        LogPass("Login succeeded");

        LogInfo("Verify successful login");
        await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        LogPass("Login succeeded");
    }
}