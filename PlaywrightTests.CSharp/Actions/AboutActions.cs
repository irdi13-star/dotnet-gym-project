namespace PlaywrightTests.CSharp.Actions;

public class AboutActions
{
    private readonly IPage _page;

    public AboutActions(IPage page, IBrowserContext context)
    {
        _page = page;
    }

    public async Task VerifyAboutPageLoaded()
    {
        await Assertions.Expect(_page).ToHaveURLAsync(new Regex(".*About"));
    }
}
