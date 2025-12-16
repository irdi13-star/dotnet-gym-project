namespace PlaywrightTests.CSharp.Pages;

public class HomePage
{
    private readonly IPage _page;

    public ILocator HeroCarousel => _page.Locator("#heroCarousel .carousel-item img");
    public ILocator HeroBanner => _page.Locator("#hero");
    public ILocator JoinNowButton =>
     _page.Locator("a.btn.btn-primary.btn-lg[href='#services']");

    public HomePage(IPage page)
    {
        _page = page;
    }
}