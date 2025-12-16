namespace PlaywrightTests.CSharp.Actions;

// using Microsoft.Playwright.Assertions;
using PlaywrightTests.CSharp.Pages;

public class CommonActions
{
    private readonly CommonPage _commonPage;

    public CommonActions(CommonPage commonPage)
    {
        _commonPage = commonPage;
    }

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
