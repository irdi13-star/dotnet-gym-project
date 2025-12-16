// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using PlaywrightTests.CSharp.Actions;

// namespace PlaywrightTests.CSharp.Tests;

// /// <summary>
// /// Base test class care oferă App fixture pentru toate testele
// /// </summary>
// public class BaseTest : PageTest
// {
//     protected App App { get; private set; } = null!;

//     [SetUp]
//     public async Task BaseSetUp()
//     {
//         // Inițializează App cu Page și Context
//         App = new App(Page, Context);

//         // Optional: Start tracing pentru debugging
//         await Context.Tracing.StartAsync(new()
//         {
//             Screenshots = true,
//             Snapshots = true,
//             Sources = true
//         });
//     }

//     [TearDown]
//     public async Task BaseTearDown()
//     {
//         var tracePath = Path.Combine(
//             TestContext.CurrentContext.WorkDirectory,
//             "playwright-traces",
//             $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
//         );

//         Directory.CreateDirectory(Path.GetDirectoryName(tracePath)!);

//         await Context.Tracing.StopAsync(new()
//         {
//             Path = tracePath
//         });
//     }
// }