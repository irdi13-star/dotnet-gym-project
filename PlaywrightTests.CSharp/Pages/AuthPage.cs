namespace PlaywrightTests.CSharp.Pages;

public class AuthPage
{
    private readonly IPage _page;

    // Selectori
    public string RegisterLink => "#registerLink";
    public string RegisterUsernameInput => "#registerUsernameField";
    public string RegisterEmailInput => "#registerEmailField";
    public string RegisterPasswordInput => "#registerPasswordField";
    public string RegisterButton => "#registerSubmitBtn";
    public string LoginFormContainer => "#loginFormContainer";
    public string LoginLink => "#authPageLinkDesktop";
    public string UsernameInput => "input[name='Login.UserName']";
    public string EmailInput => "#email";
    public string PasswordInput => "input[name='Login.Password']";
    public string LoginButton => "button[type='submit']:text('Login')";
    public string RegisterUsernameError => "#registerUsernameError";
  

    public AuthPage(IPage page)
    {
        _page = page;
    }
}