namespace PlaywrightTests.CSharp.Actions;

using PlaywrightTests.CSharp.Pages;

public class HomeActions(IPage page)
{
    private readonly IPage _page = page;
    public readonly HomePage _homePage = new HomePage(page);

    public async Task VerifyHeroCarousel()
    {
        await Assertions.Expect(_homePage.HeroBanner).ToBeVisibleAsync();

        var images = _homePage.HeroCarousel;
        int count = await images.CountAsync();

        for (int i = 0; i < count; i++)
        {
            var image = images.Nth(i);

            await Assertions.Expect(image).ToHaveAttributeAsync("src", new Regex(".+"));
            string? src = await image.GetAttributeAsync("src");

            Console.WriteLine($"Image {i + 1} found with src {src}");
        }
    }

    public async Task VerifyJoinNowButton()
    {
        var joinButton = _homePage.JoinNowButton;
        await Assertions.Expect(joinButton).ToBeVisibleAsync();
        await Assertions.Expect(joinButton).ToBeEnabledAsync();
    }

    public async Task ClickJoinNowButton()
    {
        await _homePage.JoinNowButton.ClickAsync();
    }
}