namespace PlaywrightTests.CSharp.Actions;

using Microsoft.Playwright;
using PlaywrightTests.CSharp.Pages;
using PlaywrightTests.CSharp.Helpers;
using PlaywrightTests.CSharp.Resources;

public class AuthActions(IPage page, IBrowserContext context) : CommonActions(page, context)
{
    private readonly AuthPage _authPage = new(page);

    // Verify methods for Mad Gym section
    public async Task VerifyMadGymImageContainer()
    {
        await Assertions.Expect(_authPage.MadGymImageContainer).ToBeVisibleAsync();
    }

    public async Task VerifyMadGymText()
    {
        await Assertions.Expect(_authPage.MadGymText).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.MadGymText).ToHaveTextAsync(Strings.Auth.MadGymTitle);
    }

    public async Task VerifyUnlockSubtext()
    {
        await Assertions.Expect(_authPage.UnlockSubtext).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.UnlockSubtext).ToHaveTextAsync(Strings.Auth.UnlockSubtext);
    }

    // Verify Register Form
    public async Task VerifyRegisterFormContainer()
    {
        await _authPage.RegisterLink.ClickAsync();
        await Assertions.Expect(_authPage.RegisterFormContainer).ToBeVisibleAsync();
    }

    public async Task VerifyJoinUsText()
    {
        await Assertions.Expect(_authPage.JoinUsText).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.JoinUsText).ToHaveTextAsync(Strings.Auth.JoinUsTitle);
    }

    public async Task VerifyCreateAccText()
    {
        await Assertions.Expect(_authPage.CreateAccText).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.CreateAccText).ToHaveTextAsync(Strings.Auth.CreateAccText);
    }

    public async Task VerifyRegisterUserName()
    {
        await Assertions.Expect(_authPage.RegisterUsernameInput).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterUsernameInput)
            .ToHaveAttributeAsync("placeholder", Strings.Auth.RegisterUsernamePlaceholder);
        await Assertions.Expect(_authPage.RegisterUsernameInput)
            .ToHaveAttributeAsync("title", Strings.Auth.RegisterUsernameTitle);
    }

    public async Task VerifyRegisterEmail()
    {
        await Assertions.Expect(_authPage.RegisterEmailInput).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterEmailInput)
            .ToHaveAttributeAsync("placeholder", Strings.Auth.RegisterEmailPlaceholder);
        await Assertions.Expect(_authPage.RegisterEmailInput)
            .ToHaveAttributeAsync("title", Strings.Auth.RegisterEmailTitle);
    }

    public async Task VerifyRegisterPassword()
    {
        await Assertions.Expect(_authPage.RegisterPasswordInput).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterPasswordInput)
            .ToHaveAttributeAsync("placeholder", Strings.Auth.RegisterPasswordPlaceholder);
        await Assertions.Expect(_authPage.RegisterPasswordInput)
            .ToHaveAttributeAsync("title", Strings.Auth.RegisterPasswordTitle);
    }

    public async Task VerifyRegisterSubmitBtn()
    {
        await Assertions.Expect(_authPage.RegisterButton).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterButton).ToHaveTextAsync(Strings.Auth.RegisterButton);
    }

    public async Task VerifyHaveAccSubtext()
    {
        await Assertions.Expect(_authPage.HaveAccSubtext).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.HaveAccSubtext).ToContainTextAsync(Strings.Auth.AlreadyHaveAccText);
    }

    public async Task VerifyLoginLink()
    {
        await Assertions.Expect(_authPage.LoginLink).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.LoginLink).ToHaveTextAsync(Strings.Auth.LoginLinkText);
    }

    // Verify Login Form
    public async Task VerifyLoginFormContainer()
    {
        await Assertions.Expect(_authPage.LoginFormContainer).ToBeVisibleAsync();
    }

    public async Task VerifyWelcomeText()
    {
        await Assertions.Expect(_authPage.WelcomeText).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.WelcomeText).ToHaveTextAsync(Strings.Auth.WelcomeTitle);
    }

    public async Task VerifyLoginSubtext()
    {
        await Assertions.Expect(_authPage.LoginSubtext).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.LoginSubtext).ToHaveTextAsync(Strings.Auth.LoginSubtext);
    }

    public async Task VerifyLoginUserName()
    {
        await Assertions.Expect(_authPage.LoginUserName).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.LoginUserName)
            .ToHaveAttributeAsync("placeholder", Strings.Auth.LoginUsernamePlaceholder);
        await Assertions.Expect(_authPage.LoginUserName)
            .ToHaveAttributeAsync("title", Strings.Auth.LoginUsernameTitle);
    }

    public async Task VerifyLoginPassword()
    {
        await Assertions.Expect(_authPage.LoginPassword).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.LoginPassword)
            .ToHaveAttributeAsync("placeholder", Strings.Auth.LoginPasswordPlaceholder);
        await Assertions.Expect(_authPage.LoginPassword)
            .ToHaveAttributeAsync("title", Strings.Auth.LoginPasswordTitle);
    }

    public async Task VerifyLoginSubmitButton()
    {
        await Assertions.Expect(_authPage.LoginSubmitButton).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.LoginSubmitButton).ToHaveTextAsync(Strings.Auth.LoginButton);
    }

    public async Task VerifyOrSubtext()
    {
        await Assertions.Expect(_authPage.OrSubtext).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.OrSubtext).ToHaveTextAsync(Strings.Auth.OrText);
    }

    public async Task VerifyGoogleBtn()
    {
        await Assertions.Expect(_authPage.GoogleBtn).ToBeVisibleAsync();
    }

    public async Task VerifyFacebookBtn()
    {
        await Assertions.Expect(_authPage.FacebookBtn).ToBeVisibleAsync();
    }

    public async Task VerifyAppleBtn()
    {
        await Assertions.Expect(_authPage.AppleBtn).ToBeVisibleAsync();
    }

    public async Task VerifyRegisterNowSubtext()
    {
        await Assertions.Expect(_authPage.RegisterNowSubtext).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterNowSubtext).ToContainTextAsync(Strings.Auth.DontHaveAccText);
    }

    public async Task VerifyRegisterLink()
    {
        await Assertions.Expect(_authPage.RegisterLink).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterLink).ToHaveTextAsync(Strings.Auth.RegisterNowLink);
    }

    public async Task VerifyForgotPasswordSubtext()
    {
        await Assertions.Expect(_authPage.ForgotPasswordSubtext).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.ForgotPasswordSubtext)
            .ToContainTextAsync(Strings.Auth.ForgotPasswordText);
    }

    public async Task VerifyForgotPasswordLink()
    {
        await Assertions.Expect(_authPage.ForgotPasswordLink).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.ForgotPasswordLink)
            .ToContainTextAsync(Strings.Auth.ResetPasswordLink);
    }

    // Login/Register Actions
    public async Task LoginAsUserTemplate(string username, string password)
    {
        await _authPage.LoginUsernameInput.FillAsync(username);
        await _authPage.LoginPasswordInput.FillAsync(password);
        await _authPage.LoginSubmitButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load, new() { Timeout = 10000 });
        await Assertions.Expect(_commonPage.UserDashButtonDesktop)
            .ToBeVisibleAsync(new() { Timeout = 10000 });
    }

    public async Task LoginAsAdminTemplate(string username, string password)
    {
        await _authPage.LoginUsernameInput.FillAsync(username);
        await _authPage.LoginPasswordInput.FillAsync(password);
        await _authPage.LoginSubmitButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load, new() { Timeout = 10000 });
        await Assertions.Expect(_commonPage.UserDashButtonDesktop)
            .ToBeVisibleAsync(new() { Timeout = 10000 });
    }

    public async Task LoginAsUser()
    {
        var username = Strings.LoginCredentials.Username;
        var password = Strings.LoginCredentials.Password;

        await LoginAsUserTemplate(username, password);
        await Assertions.Expect(_authPage.LoginFormContainer).Not.ToBeVisibleAsync();
    }

    public async Task LoginAsAdmin()
    {
        var username = Strings.LoginCredentials.AdminUsername;
        var password = Strings.LoginCredentials.AdminPassword;

        await LoginAsAdminTemplate(username, password);
        await Assertions.Expect(Page).ToHaveURLAsync("http://localhost:5000/");
    }

    public async Task LoginWithWrongUser()
    {
        await _authPage.LoginUsernameInput.FillAsync(Strings.LoginWrongCredentials.WrongUser);
        await _authPage.LoginPasswordInput.FillAsync(Strings.LoginWrongCredentials.WrongPassword);
        await _authPage.LoginSubmitButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load);

        await Assertions.Expect(_authPage.LoginErrorMessage)
            .ToHaveTextAsync(Strings.AuthErrors.InvalidCredentials);
    }

    public async Task RegisterWithValidUser()
    {
        await _authPage.RegisterLink.ClickAsync();
        await _authPage.RegisterUsernameInput.FillAsync(TestDataGenerator.GenerateUsername());
        await _authPage.RegisterEmailInput.FillAsync(TestDataGenerator.GenerateEmail());
        await _authPage.RegisterPasswordInput.FillAsync(Strings.RegisterCredentials.RegisterPassword);
        await _authPage.RegisterButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load);

        await Assertions.Expect(_authPage.LoginFormContainer).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterUsernameError).ToBeHiddenAsync();
    }

    public async Task RegisterWithWrongUser()
    {
        await _authPage.RegisterUsernameInput.FillAsync(Strings.RegisterWrongCredentials.RegisterUsername);
        await _authPage.RegisterEmailInput.FillAsync(Strings.RegisterWrongCredentials.RegisterEmail);
        await _authPage.RegisterPasswordInput.FillAsync(Strings.RegisterWrongCredentials.RegisterPassword);
        await _authPage.RegisterButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load);

        await Assertions.Expect(_authPage.RegisterUsernameError)
            .ToHaveTextAsync(Strings.AuthErrors.InvalidUsername);
        await Assertions.Expect(_authPage.RegisterEmailError)
            .ToHaveTextAsync(Strings.AuthErrors.InvalidEmail);
        await Assertions.Expect(_authPage.RegisterPasswordError)
            .ToHaveTextAsync(Strings.AuthErrors.InvalidPassword);
    }

    public async Task RegisterWithBlankFields()
    {
        await _authPage.RegisterUsernameInput.FillAsync("");
        await _authPage.RegisterEmailInput.FillAsync("");
        await _authPage.RegisterPasswordInput.FillAsync("");
        await _authPage.RegisterButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load);

        await Assertions.Expect(_authPage.RegisterUsernameError)
            .ToHaveTextAsync(Strings.AuthErrors.BlankFields.Username);
        await Assertions.Expect(_authPage.RegisterEmailError)
            .ToHaveTextAsync(Strings.AuthErrors.BlankFields.Email);
        await Assertions.Expect(_authPage.RegisterPasswordError)
            .ToHaveTextAsync(Strings.AuthErrors.BlankFields.Password);
    }

    public async Task LoginWithBlankFields()
    {
        await _authPage.LoginUserName.FillAsync("");
        await _authPage.LoginPassword.FillAsync("");
        await _authPage.LoginSubmitButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.Load);

        await Assertions.Expect(_authPage.LoginUserNameError)
            .ToHaveTextAsync(Strings.AuthErrors.BlankFields.Username);
        await Assertions.Expect(_authPage.LoginPasswordError)
            .ToHaveTextAsync(Strings.AuthErrors.BlankFields.Password);
    }
}