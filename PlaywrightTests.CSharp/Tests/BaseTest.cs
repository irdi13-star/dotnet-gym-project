using AventStack.ExtentReports;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using PlaywrightTests.CSharp.Actions;

namespace PlaywrightTests.CSharp.Tests;

public class BaseTest : PageTest
{
    protected App App { get; private set; } = null!;
    protected ExtentTest Test { get; private set; } = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        ExtentReportManager.GetExtent();
    }

    [SetUp]
    public async Task BaseSetUp()
    {
        Test = ExtentReportManager.GetExtent()
            .CreateTest(TestContext.CurrentContext.Test.MethodName)
            .AssignCategory(TestContext.CurrentContext.Test.ClassName!);

        App = new App(Page, Context);

        await Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task BaseTearDown()
    {
        var testName = TestContext.CurrentContext.Test.MethodName;
        var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

        var tracePath = Path.Combine(
            TestContext.CurrentContext.WorkDirectory,
            "test-results",
            "traces",
            $"{testName}.zip"
        );

        Directory.CreateDirectory(Path.GetDirectoryName(tracePath)!);

        await Context.Tracing.StopAsync(new() { Path = tracePath });

        var screenshotPath = Path.Combine(
            TestContext.CurrentContext.WorkDirectory,
            "test-results",
            "screenshots",
            $"{testName}.png"
        );

        Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath)!);
        await Page.ScreenshotAsync(new() { Path = screenshotPath, FullPage = true });

        if (testStatus == TestStatus.Failed)
        {
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Test.Fail($"Test failed: {errorMessage}");
            Test.AddScreenCaptureFromPath(screenshotPath, "Failure Screenshot");
        }
        else if (testStatus == TestStatus.Passed)
        {
            Test.Pass("Test passed successfully");
            Test.AddScreenCaptureFromPath(screenshotPath, "Final Screenshot");
        }
        else if (testStatus == TestStatus.Skipped)
        {
            Test.Skip("Test was skipped");
        }

        Test.Info($"Trace file: {Path.GetFileName(tracePath)}");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        ExtentReportManager.Flush();
    }

    protected void LogInfo(string message)
    {
        Test.Info(message);
        TestContext.Progress.WriteLine($"ℹ️ {message}");
    }

    protected void LogPass(string message)
    {
        Test.Pass(message);
        TestContext.Progress.WriteLine($"✅ {message}");
    }

    protected void LogWarning(string message)
    {
        Test.Warning(message);
        TestContext.Progress.WriteLine($"⚠️ {message}");
    }
}