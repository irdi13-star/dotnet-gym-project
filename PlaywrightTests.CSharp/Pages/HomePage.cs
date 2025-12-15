namespace PlaywrightTests.CSharp.Pages;

public class HomePage
{
    private readonly IPage _page;

    // Selectori
    public string HeroCarousel => ".hero-carousel";
    public string HeroTitle => "h1.hero-title";
    public string HeroDescription => ".hero-description";
    public string JoinNowButton => "button:text('Join Now')";

    public HomePage(IPage page)
    {
        _page = page;
    }

    public ILocator GetHeroCarousel() => _page.Locator(HeroCarousel);
    public ILocator GetHeroTitle() => _page.Locator(HeroTitle);
}