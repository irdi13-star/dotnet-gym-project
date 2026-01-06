namespace PlaywrightTests.CSharp.Actions;

using Microsoft.Playwright;

public class App
{
    public BaseActions Base { get; }
    public NavigationActions Navigation { get; }
    public CommonActions Common { get; }
    public HomeActions Home { get; }
    public NavbarFooterActions NavbarFooter { get; }
    public AboutActions About { get; }
    public ServicesActions Services { get; }
    public AuthActions Auth { get; }

    public App(IPage page, IBrowserContext context)
    {
        Base = new BaseActions(page, context);
        Navigation = new NavigationActions(page, context);
        Common = new CommonActions(page);
        Home = new HomeActions(page, context);
        NavbarFooter = new NavbarFooterActions(page, context);
        About = new AboutActions(page, context);
        Services = new ServicesActions(page, context);
        Auth = new AuthActions(page, context);
    }
}
