namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class CommonActions(IPage page, IBrowserContext context) : BaseActions(page, context)
{
    private readonly CommonPage _commonPage = new(page);

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

    public async Task BrowserTabTitleAsExpected(string browserTitle)
    {
        var pageTitle = await _commonPage.TabTitle();
        var pageUrl = _commonPage.Page.Url;
        Console.WriteLine($"Browser tab title for pageUrl - '{pageUrl}' is: '{pageTitle}'");

        await Assertions.Expect(_commonPage.Page)
            .ToHaveTitleAsync(browserTitle);
    }

    public async Task CheckH1(string header)
    {
        var locator = _commonPage.H1Locator(header);
        await Assertions.Expect(locator).ToBeVisibleAsync();
        await Assertions.Expect(locator).ToHaveTextAsync(header);
        Console.WriteLine($"Checked H1: \"{header}\" is visible and has correct text.");
    }

    public async Task CheckH2(string header)
    {
        var locator = _commonPage.H2Locator(header);
        await Assertions.Expect(locator).ToBeVisibleAsync();
        await Assertions.Expect(locator).ToHaveTextAsync(header);
        Console.WriteLine($"Checked H2: \"{header}\" is visible and has correct text.");
    }

    public async Task CheckH3(string header)
    {
        var locator = _commonPage.H3Locator(header);
        await Assertions.Expect(locator).ToBeVisibleAsync();
        await Assertions.Expect(locator).ToHaveTextAsync(header);
        Console.WriteLine($"Checked H3: \"{header}\" is visible and has correct text.");
    }

    public async Task CheckP(string text)
    {
        var locator = _commonPage.PLocator(text);
        await Assertions.Expect(locator).ToBeVisibleAsync();
        await Assertions.Expect(locator).ToHaveTextAsync(text);
        Console.WriteLine($"Checked P: \"{text}\" is visible and has correct text.");
    }

    public async Task CheckLi(string text)
    {
        var locator = _commonPage.LiLocator(text);
        await Assertions.Expect(locator).ToBeVisibleAsync();
        await Assertions.Expect(locator).ToHaveTextAsync(text);
        Console.WriteLine($"Checked list item: \"{text}\"");
    }

    public async Task CheckLinkByTextAndHref(string text, string expectedHref)
    {
        var locator = _commonPage.GetLinkByText(text);
        await Assertions.Expect(locator).ToBeVisibleAsync();
        await Assertions.Expect(locator).ToHaveAttributeAsync("href", expectedHref);
        Console.WriteLine($"Checked link href for text \"{text}\" is: \"{expectedHref}\"");

        await locator.ClickAsync();
        Console.WriteLine($"Clicked link with text \"{text}\"");

        var currentUrl = _commonPage.Page.Url;
        Console.WriteLine($"Navigated to URL: {currentUrl}");

        await _commonPage.Page.GoBackAsync();
        Console.WriteLine("Went back to previous page in the same tab");
    }

    public async Task VerifyImageSrc(string imageSrc)
    {
        var imageLocator = _commonPage.GetImageBySrc(imageSrc);
        await Assertions.Expect(imageLocator).ToBeVisibleAsync();
        await Assertions.Expect(imageLocator).ToHaveAttributeAsync("src", imageSrc);
    }

    public async Task GoBackMultiple(int times)
    {
        for (int i = 0; i < times; i++)
        {
            await Page.GoBackAsync();
            await Page.WaitForLoadStateAsync(LoadState.Load);
        }
    }

    public async Task GoToUserProfile()
    {
        var desktopButton = _commonPage.UserDashButtonDesktop;

        try
        {
            await Assertions.Expect(desktopButton)
                .ToBeVisibleAsync(new() { Timeout = 5000 });
            await desktopButton.ClickAsync();
            await Page.WaitForLoadStateAsync(LoadState.Load);
        }
        catch (Exception error)
        {
            Console.WriteLine($"Failed: {error.Message}");
            throw new Exception("User Dashboard desktop button not visible", error);
        }
    }

    public async Task GoToAdminProfile()
    {
        var desktopButton = _commonPage.AdminDashboardButtonDesktop;

        try
        {
            await Assertions.Expect(desktopButton)
                .ToBeVisibleAsync(new() { Timeout = 5000 });
            await desktopButton.ClickAsync();
            await Page.WaitForLoadStateAsync(LoadState.Load);
        }
        catch (Exception error)
        {
            Console.WriteLine($"Failed: {error.Message}");
            throw new Exception("Admin Dashboard desktop button not visible", error);
        }
    }

    public async Task VerifyUserIsLoggedIn()
    {
        await Assertions.Expect(_commonPage.UserDashButtonDesktop)
            .ToBeVisibleAsync(new() { Timeout = 5000 });
    }

    public async Task VerifyAdminIsLoggedIn()
    {
        await Assertions.Expect(_commonPage.AdminDashboardButtonDesktop)
            .ToBeVisibleAsync(new() { Timeout = 5000 });
    }

}
