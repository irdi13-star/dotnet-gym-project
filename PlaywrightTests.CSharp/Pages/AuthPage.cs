namespace PlaywrightTests.CSharp.Pages;

public class AuthPage(IPage page, IBrowserContext context)
{
    private readonly IPage _page = page;
    private readonly IBrowserContext _context = context;

    // Selectori
    public ILocator RegisterLink => _page.Locator("#registerLink");
    public ILocator RegisterUsernameInput => _page.Locator("#registerUsernameField");
    public ILocator RegisterEmailInput => _page.Locator("#registerEmailField");
    public ILocator RegisterPasswordInput => _page.Locator("#registerPasswordField");
    public ILocator RegisterButton => _page.Locator("#registerSubmitBtn");
    public ILocator RegisterUsernameError => _page.Locator("#registerUsernameError");
    public ILocator RegisterEmailError => _page.Locator("#registerEmailError");
    public ILocator RegisterPasswordError => _page.Locator("#registerPasswordError");
    public ILocator RegisterNowSubtext => _page.Locator("#registerNowSubtext");
    public ILocator LoginFormContainer => _page.Locator("#loginFormContainer");
    public ILocator LoginHref => _page.GetByRole(AriaRole.Link, new() { Name = "Login" });
    public ILocator LoginUsernameInput => _page.Locator("input[name='Login.UserName']");
    public ILocator LoginPasswordInput => _page.Locator("input[name='Login.Password']");
    public ILocator LoginSubmitButton => _page.Locator("button[type='submit']:has-text('Login')");
    public ILocator LoginSubtext => _page.Locator("#loginSubtext");
    public ILocator LoginUserNameError => _page.Locator("#loginUserNameError");
    public ILocator LoginPasswordError => _page.Locator("#loginPasswordError");
    public ILocator LoginErrorMessage => _page.Locator("#loginErrorMessage");

    public ILocator MadGymImageContainer => _page.Locator("#madGymImageContainter");
    public ILocator MadGymText => _page.Locator("#madGymText");
    public ILocator RegisterFormContainer => _page.Locator("#registerFormContainer");
    public ILocator JoinUsText => _page.Locator("#joinUsText");
    public ILocator CreateAccText => _page.Locator("#createAccText");
    public ILocator HaveAccSubtext => _page.Locator("#haveAccSubtext");
    public ILocator WelcomeText => _page.Locator("#welcomeText");
    public ILocator UsernameField => _page.Locator("#usernameField");
    public ILocator LoginUserName => _page.Locator("#loginUserName");
    public ILocator PasswordField => _page.Locator("#passwordField");
    public ILocator LoginPassword => _page.Locator("#loginPassword");
    public ILocator LoginSubmitBtn => _page.Locator("#loginSubmitBtn");
    public ILocator OrSubtext => _page.Locator("#orSubtext");
    public ILocator GoogleBtn => _page.Locator("#googleBtn");
    public ILocator FacebookBtn => _page.Locator("#facebookBtn");
    public ILocator AppleBtn => _page.Locator("#appleBtn");
    public ILocator ForgotPasswordSubtext => _page.Locator("#forgotPasswordSubtext");
    public ILocator ForgotPasswordLink => _page.Locator("#forgotPasswordLink");
    public ILocator UnlockSubtext => _page.Locator("#unlockSubtext");
}