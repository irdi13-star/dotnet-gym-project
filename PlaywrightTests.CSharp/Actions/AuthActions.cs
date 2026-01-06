namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class AuthActions(IPage page, IBrowserContext context)
{
    private readonly AuthPage _authPage = new AuthPage(page);

    public async Task Register(string username, string email, string password)
    {
        await _authPage.RegisterLink.ClickAsync();
        await _authPage.RegisterUsernameInput.FillAsync(username);
        await _authPage.RegisterEmailInput.FillAsync(email);
        await _authPage.RegisterPasswordInput.FillAsync(password);
        await _authPage.RegisterButton.ClickAsync();

        await Assertions.Expect(_authPage.LoginFormContainer).ToBeVisibleAsync();
        await Assertions.Expect(_authPage.RegisterUsernameError).ToBeHiddenAsync();
    }

    public async Task Login(string username, string password)
    {
        await _authPage.LoginLink.ClickAsync();
        await _authPage.UsernameInput.FillAsync(username);
        await _authPage.PasswordInput.FillAsync(password);
        await _authPage.LoginButton.ClickAsync();
    }
}
