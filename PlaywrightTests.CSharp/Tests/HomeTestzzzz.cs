
// using PlaywrightTests.CSharp.Resources;
// using PlaywrightTests.CSharp.Actions;
// using PlaywrightTests.CSharp.Utils;
// using NUnit.Framework;
// using NUnit.Allure.Attributes;
// using NUnit.Allure.Core;

// namespace PlaywrightTests.CSharp.Tests;

// [TestFixture]
// [Category("regression")]
// [Category("home")]
// public class HomeTests : BaseTest
// {
//     [Test]
//     public async Task HeroSection()
//     {
//         await StepAsync("Verify hero carousel images are visible", async () =>
//         {
//             await App.Home.VerifyHeroCarousel();
//         });

//         await StepAsync("Verify hero title is visible", async () =>
//         {
//             await App.Common.HeaderIsVisible(Strings.Home.HeroTitle);
//         });

//         await StepAsync("Verify hero description is visible", async () =>
//         {
//             await App.Common.ParagraphIsVisible(Strings.Home.HeroDescription);
//         });

//         await StepAsync("Verify Join Now button is visible and clickable", async () =>
//         {
//             await App.Home.VerifyJoinNowButton();
//         });
//     }

//     private async Task StepAsync(string stepName, Func<Task> action)
//     {
//         await AllureLifecycle.Instance.WrapInStep(async () =>
//         {
//             await action();
//         }, stepName);
//     }
// }