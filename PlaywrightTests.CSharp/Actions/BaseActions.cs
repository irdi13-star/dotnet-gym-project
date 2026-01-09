namespace PlaywrightTests.CSharp.Actions;

using Microsoft.Playwright;

public class BaseActions(IPage page, IBrowserContext context)
{
    protected readonly IPage Page = page;
    protected readonly IBrowserContext Context = context;

    public async Task NavigateTo(string url)
    {
        await Page.GotoAsync(url, new() { WaitUntil = WaitUntilState.NetworkIdle });
    }

    public async Task WaitForTimeout(int milliseconds)
    {
        await Page.WaitForTimeoutAsync(milliseconds);
    }

    public Task<string> GetCurrentUrl()
    {
        return Task.FromResult(Page.Url);
    }
}
