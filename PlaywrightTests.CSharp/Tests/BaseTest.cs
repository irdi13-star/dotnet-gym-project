using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using PlaywrightTests.CSharp.Actions;

namespace PlaywrightTests.CSharp.Tests
{
    public class BaseTest
    {
        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IPage _page;
        protected IBrowserContext _context;
        protected App App;

        [SetUp]
        public async Task SetUp()
        {
            // Initialize Playwright
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            // Initialize App with page + context
            App = new App(_page, _context);

            // Ensure folders exist
            Directory.CreateDirectory("Screenshots");
            Directory.CreateDirectory("playwright-traces");

            // Start tracing
            await _context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Screenshot
                var screenshotPath = Path.Combine("Screenshots", $"{testName}.png");
                await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });
                Console.WriteLine($"Screenshot saved: {screenshotPath}");
            }

            // Stop tracing
            var tracePath = Path.Combine("playwright-traces", $"{testName}-{DateTime.Now:yyyyMMdd_HHmmss}.zip");
            await _context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = tracePath
            });
            Console.WriteLine($"Trace saved: {tracePath}");

            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        /// <summary>
        /// Wraps a test step with logging
        /// </summary>
        protected async Task StepAsync(string stepName, Func<Task> action)
        {
            Console.WriteLine($"STEP START: {stepName}");
            try
            {
                await action();
                Console.WriteLine($"STEP PASS: {stepName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"STEP FAIL: {stepName} - {ex.Message}");
                throw;
            }
        }
    }
}
