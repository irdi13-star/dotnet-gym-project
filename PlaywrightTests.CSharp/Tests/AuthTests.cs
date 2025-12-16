namespace PlaywrightTests.CSharp.Tests;

using PlaywrightTests.CSharp.Resources;
using PlaywrightTests.CSharp.Helpers;
using PlaywrightTests.CSharp.Utils;

[TestFixture]
[Category("regression")]
[Category("auth")]
public class AuthTests : BaseTest
{
    [Test]
    public async Task UserCanARegister()
    {
        // Arrange
        var (username, email, password) = TestDataGenerator.GenerateUserCredentials();

        // Act
        await Test.Step("Navigate to home page", async () =>
        {
            await App.Base.NavigateTo(Routes.AuthLinks.Login);
        });

        await Test.Step($"Register with username: {username}", async () =>
        {
            await App.Auth.Register(username, email, password);
        });

        // Assert
        await Test.Step("Verify redirect to login page", async () =>
        {
            await App.Navigation.PageUrlContains("AuthPage");
        });
    }

    [Test]
    public async Task UserCanLogin()
    {
        // Act - Now login
        await Test.Step($"Login with username: {Strings.Auth.ValidUsername}", async () =>
        {
            await App.Base.NavigateTo(Routes.HomeLinks.Home);
            await App.Auth.Login(Strings.Auth.ValidUsername, Strings.Auth.ValidPassword);
        });

        // Assert
        await Test.Step("Verify successful login", async () =>
        {
            await App.Navigation.PageUrlAsExpected(Routes.HomeLinks.Home);
        });
    }
}