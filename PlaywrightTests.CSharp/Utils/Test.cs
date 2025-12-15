namespace PlaywrightTests.CSharp.Utils;

public static class Test
{
    public static async Task Step(string description, Func<Task> action)
    {
        TestContext.Progress.WriteLine($"  → {description}");
        await action();
    }
}