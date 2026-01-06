namespace PlaywrightTests.CSharp.Pages;

public class AuthPage(IPage page)
{
    private readonly IPage _page = page;

    // Selectori
    public ILocator RegisterLink => _page.Locator("#registerLink");
    public ILocator RegisterUsernameInput => _page.Locator("#registerUsernameField");
    public ILocator RegisterEmailInput => _page.Locator("#registerEmailField");
    public ILocator RegisterPasswordInput => _page.Locator("#registerPasswordField");
    public ILocator RegisterButton => _page.Locator("#registerSubmitBtn");
    public ILocator LoginFormContainer => _page.Locator("#loginFormContainer");
    public ILocator LoginLink => _page.Locator("#authPageLinkDesktop");
    public ILocator UsernameInput => _page.Locator("input[name='Login.UserName']");
    public ILocator PasswordInput => _page.Locator("input[name='Login.Password']");
    public ILocator LoginButton => _page.Locator("button[type='submit']:has-text('Login')");
    public ILocator RegisterUsernameError => _page.Locator("#registerUsernameError");
}