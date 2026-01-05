namespace PlaywrightTests.CSharp.Actions;

public class ServicesActions
{
    private readonly IPage _page;

    public ServicesActions(IPage page, IBrowserContext context)
    {
        _page = page;
    }

    public async Task VerifyServicesPageLoaded()
    {
        await Assertions.Expect(_page).ToHaveURLAsync(new Regex(".*Services"));
    }
}