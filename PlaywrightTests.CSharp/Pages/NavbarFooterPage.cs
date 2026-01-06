namespace PlaywrightTests.CSharp.Pages;

public class NavbarFooterPage(IPage page)
{
    private readonly IPage _page = page;

    public ILocator Navbar => _page.Locator("nav.navbar");
    public ILocator Footer => _page.Locator("footer");
    public ILocator HomeLink => _page.Locator("a[href='/']");
    public ILocator AboutLink => _page.Locator("a[href='/Home/About']");
    public ILocator ServicesLink => _page.Locator("a[href='/Home/Services']");
}