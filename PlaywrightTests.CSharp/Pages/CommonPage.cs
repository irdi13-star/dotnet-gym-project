namespace PlaywrightTests.CSharp.Pages;

using Microsoft.Playwright;

public class CommonPage
{
    private readonly IPage _page;

    public CommonPage(IPage page)
    {
        _page = page;
    }

    public IPage Page => _page;

    public ILocator HeaderByName(string header) =>
        _page.GetByRole(AriaRole.Heading, new() { Name = header });

    public ILocator ParagraphByText(string text) =>
        _page.Locator("p", new() { HasTextString = text });

    public ILocator ButtonByName(string buttonTitle) =>
        _page.GetByRole(AriaRole.Button, new() { Name = buttonTitle });
}
