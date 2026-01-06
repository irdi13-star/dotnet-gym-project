namespace PlaywrightTests.CSharp.Actions;

public class ServicesActions(IPage page)
{
    private readonly IPage _page = page;

    public async Task VerifyServicesPageLoaded()
    {
        await Assertions.Expect(_page).ToHaveURLAsync(new Regex(".*Services"));
    }
}