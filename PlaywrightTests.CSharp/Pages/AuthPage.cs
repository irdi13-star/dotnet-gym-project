namespace PlaywrightTests.CSharp.Pages;

public class AuthPage
{
    private readonly IPage _page;

    // Selectori
    public string RegisterLink => "#registerLink";
    public string LoginLink => "#loginLink";
    public string UsernameInput => "#username";
    public string EmailInput => "#email";
    public string PasswordInput => "#password";
    public string RegisterButton => "button[type='submit']:text('Register')";
    public string LoginButton => "button[type='submit']:text('Login')";

    public AuthPage(IPage page)
    {
        _page = page;
    }
}