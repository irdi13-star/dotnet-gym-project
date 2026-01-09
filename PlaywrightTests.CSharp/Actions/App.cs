namespace PlaywrightTests.CSharp.Actions;

using Microsoft.Playwright;

public class App(IPage page, IBrowserContext context)
{
    public BaseActions Base { get; } = new BaseActions(page, context);
    public NavigationActions Navigation { get; } = new NavigationActions(page);
    public CommonActions Common { get; } = new CommonActions(page, context);
    public HomeActions Home { get; } = new HomeActions(page);
    public NavbarFooterActions NavbarFooter { get; } = new NavbarFooterActions(page);
    public AboutActions About { get; } = new AboutActions(page);
    public ServicesActions Services { get; } = new ServicesActions(page, context);
    public AuthActions Auth { get; } = new AuthActions(page);
}
