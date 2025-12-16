namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class NavbarFooterActions
{
    private readonly IPage _page;
    private readonly NavbarFooterPage _navbarFooterPage;

    public NavbarFooterActions(IPage page, IBrowserContext context)
    {
        _page = page;
        _navbarFooterPage = new NavbarFooterPage(page);
    }

    public async Task ClickHomeLink()
    {
        await _page.Locator(_navbarFooterPage.HomeLink).ClickAsync();
    }

    public async Task ClickAboutLink()
    {
        await _page.Locator(_navbarFooterPage.AboutLink).ClickAsync();
    }

    public async Task VerifyNavbarVisible()
    {
        await Assertions.Expect(_page.Locator(_navbarFooterPage.Navbar))
            .ToBeVisibleAsync();
    }

    public async Task VerifyFooterVisible()
    {
        await Assertions.Expect(_page.Locator(_navbarFooterPage.Footer))
            .ToBeVisibleAsync();
    }
}