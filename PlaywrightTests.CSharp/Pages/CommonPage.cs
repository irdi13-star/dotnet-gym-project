namespace PlaywrightTests.CSharp.Pages;

using Microsoft.Playwright;

public class CommonPage(IPage page)
{
    private readonly IPage _page = page;

    public IPage Page => _page;

    public ILocator HeaderByName(string header) =>
        _page.GetByRole(AriaRole.Heading, new() { Name = header });

    public ILocator ParagraphByText(string text) =>
        _page.Locator("p", new() { HasTextString = text });

    public ILocator ButtonByName(string buttonTitle) =>
        _page.GetByRole(AriaRole.Button, new() { Name = buttonTitle });
}
