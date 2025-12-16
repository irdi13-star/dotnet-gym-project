namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class AuthActions
{
    private readonly IPage _page;
    private readonly AuthPage _authPage;

    public AuthActions(IPage page, IBrowserContext context)
    {
        _page = page;
        _authPage = new AuthPage(page);
    }

    public async Task Register(string username, string email, string password)
    {
        await _page.Locator(_authPage.RegisterLink).ClickAsync();
        await _page.Locator(_authPage.RegisterUsernameInput).FillAsync(username);
        await _page.Locator(_authPage.RegisterEmailInput).FillAsync(email);
        await _page.Locator(_authPage.RegisterPasswordInput).FillAsync(password);
        await _page.Locator(_authPage.RegisterButton).ClickAsync();
        await Assertions.Expect(_page.Locator(_authPage.LoginFormContainer)).ToBeVisibleAsync();
        await Assertions.Expect(_page.Locator(_authPage.RegisterUsernameError)).ToBeHiddenAsync();
    }

    public async Task Login(string username, string password)
    {
        await _page.Locator(_authPage.LoginLink).ClickAsync();
        await _page.Locator(_authPage.UsernameInput).FillAsync(username);
        await _page.Locator(_authPage.PasswordInput).FillAsync(password);
        await _page.Locator(_authPage.LoginButton).ClickAsync();
    }
}