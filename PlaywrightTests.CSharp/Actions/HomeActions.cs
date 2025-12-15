namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class HomeActions
{
    private readonly IPage _page;
    private readonly HomePage _homePage;

    public HomeActions(IPage page, IBrowserContext context)
    {
        _page = page;
        _homePage = new HomePage(page);
    }

    public async Task VerifyHeroCarousel()
    {
        await Assertions.Expect(_page.Locator(_homePage.HeroCarousel))
            .ToBeVisibleAsync();
    }

    public async Task VerifyHeroTitle()
    {
        await Assertions.Expect(_page.Locator(_homePage.HeroTitle))
            .ToBeVisibleAsync();
    }

    public async Task VerifyHeroDescription()
    {
        await Assertions.Expect(_page.Locator(_homePage.HeroDescription))
            .ToBeVisibleAsync();
    }

    public async Task VerifyJoinNowButton()
    {
        var joinButton = _page.Locator(_homePage.JoinNowButton);
        await Assertions.Expect(joinButton).ToBeVisibleAsync();
        await Assertions.Expect(joinButton).ToBeEnabledAsync();
    }

    public async Task ClickJoinNowButton()
    {
        await _page.Locator(_homePage.JoinNowButton).ClickAsync();
    }
}