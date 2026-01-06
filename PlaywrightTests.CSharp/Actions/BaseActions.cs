namespace PlaywrightTests.CSharp.Actions;

using Microsoft.Playwright;

public class BaseActions
{
    protected readonly IPage Page;
    protected readonly IBrowserContext Context;

    public BaseActions(IPage page, IBrowserContext context)
    {
        Page = page;
        Context = context;
    }

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
