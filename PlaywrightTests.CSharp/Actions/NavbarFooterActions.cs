namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class NavbarFooterActions(IPage page)
{
    private readonly IPage _page = page;
    private readonly NavbarFooterPage _navbarFooterPage = new NavbarFooterPage(page);

    public async Task ClickHomeLink()
    {
        await _navbarFooterPage.HomeLink.ClickAsync();
    }

    public async Task ClickAboutLink()
    {
        await _navbarFooterPage.AboutLink.ClickAsync();
    }

    public async Task VerifyNavbarVisible()
    {
        await Assertions.Expect(_navbarFooterPage.Navbar)
            .ToBeVisibleAsync();
    }

    public async Task VerifyFooterVisible()
    {
        await Assertions.Expect(_navbarFooterPage.Footer)
            .ToBeVisibleAsync();
    }

    public async Task NavigateToPageByLinkText(string linkText, string expectedUrl)
    {
        var link = _page.Locator($"text={linkText}");
        await Assertions.Expect(link).ToBeVisibleAsync();

        await link.ClickAsync();

        await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 10000 });
        await Assertions.Expect(_page).ToHaveURLAsync(expectedUrl);
    }
}