namespace PlaywrightTests.CSharp.Pages;

public class HomePage(IPage page, IBrowserContext context)
{
    private readonly IPage _page = page;
    private readonly IBrowserContext _context = context;

    public ILocator HeroCarousel => _page.Locator("#heroCarousel .carousel-item img");
    public ILocator HeroBanner => _page.Locator("#hero");
    public ILocator JoinNowButton =>
     _page.Locator("a.btn.btn-primary.btn-lg[href='#services']");

    public ILocator LoginButton => _page.Locator("#authPageLinkDesktop");

}