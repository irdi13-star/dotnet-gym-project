namespace PlaywrightTests.CSharp.Actions;

public class CommonActions
{
    private readonly IPage _page;

    public CommonActions(IPage page, IBrowserContext context)
    {
        _page = page;
    }

    public async Task BrowserTabTitleAsExpected(string expectedTitle)
    {
        await Assertions.Expect(_page).ToHaveTitleAsync(expectedTitle);
    }

    public async Task<bool> IsElementVisible(string selector)
    {
        return await _page.Locator(selector).IsVisibleAsync();
    }

    public async Task ClickElement(string selector)
    {
        await _page.Locator(selector).ClickAsync();
    }

    public async Task FillInput(string selector, string text)
    {
        await _page.Locator(selector).FillAsync(text);
    }
}