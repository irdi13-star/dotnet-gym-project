namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class CommonActions(IPage page)
{
    private readonly IPage _page = page;
    private readonly CommonPage _commonPage = new CommonPage(page);

    public async Task BrowserTabTitleAsExpected(string expectedTitle)
    {
        await Assertions.Expect(_commonPage.Page)
            .ToHaveTitleAsync(expectedTitle);
    }

    public async Task HeaderIsVisible(string headerText)
    {
        await Assertions.Expect(
            _commonPage.HeaderByName(headerText)
        ).ToBeVisibleAsync();
    }

    public async Task ParagraphIsVisible(string text)
    {
        await Assertions.Expect(
            _commonPage.ParagraphByText(text)
        ).ToBeVisibleAsync();
    }

    public async Task ButtonIsVisible(string buttonText)
    {
        await Assertions.Expect(
            _commonPage.ButtonByName(buttonText)
        ).ToBeVisibleAsync();
    }

    public async Task ClickButtonByName(string buttonTitle)
    {
        await _commonPage.ButtonByName(buttonTitle).ClickAsync();
    }
}
