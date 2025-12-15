namespace PlaywrightTests.CSharp.Actions;

public class NavigationActions
{
    private readonly IPage _page;

    public NavigationActions(IPage page, IBrowserContext context)
    {
        _page = page;
    }

    public async Task PageUrlAsExpected(string expectedUrl)
    {
        await Assertions.Expect(_page).ToHaveURLAsync(expectedUrl);
    }

    public async Task PageUrlContains(string urlPart)
    {
        await Assertions.Expect(_page).ToHaveURLAsync(new Regex($".*{Regex.Escape(urlPart)}.*"));
    }
}