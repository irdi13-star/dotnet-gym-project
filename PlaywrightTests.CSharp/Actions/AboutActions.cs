namespace PlaywrightTests.CSharp.Actions;

public class AboutActions(IPage page)
{
    private readonly IPage _page = page;

    public async Task VerifyAboutPageLoaded()
    {
        await Assertions.Expect(_page).ToHaveURLAsync(new Regex(".*About"));
    }
}
