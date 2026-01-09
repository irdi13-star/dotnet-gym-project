namespace PlaywrightTests.CSharp.Pages;

using Microsoft.Playwright;

public class CommonPage(IPage page)
{
    private readonly IPage _page = page;

    public IPage Page => _page;

    public ILocator HeaderByName(string header) =>
        _page.GetByRole(AriaRole.Heading, new() { Name = header });

    public ILocator ParagraphByText(string text) =>
        _page.Locator("p", new() { HasTextString = text });

    public ILocator ButtonByName(string buttonTitle) =>
        _page.GetByRole(AriaRole.Button, new() { Name = buttonTitle });

    public async Task<string> TabTitle()
    {
        return await Page.TitleAsync();
    }

    //-------- Headers & Text
    public ILocator H1Locator(string text)
    {
        return Page.Locator("h1", new() { HasTextString = text });
    }

    public ILocator H2Locator(string text)
    {
        return Page.Locator("h2", new() { HasTextString = text });
    }

    public ILocator H3Locator(string text)
    {
        return Page.Locator("h3", new() { HasTextString = text });
    }

    public ILocator PLocator(string text)
    {
        return Page.Locator("p", new() { HasTextString = text });
    }

    public ILocator LiLocator(string text)
    {
        return Page.Locator("li", new() { HasTextString = text });
    }

    public ILocator StrongLocator(string text)
    {
        return Page.Locator("strong", new() { HasTextString = text });
    }

    public ILocator GetLinkByText(string text)
    {
        return Page.Locator("a", new() { HasTextString = text });
    }

    public ILocator GetImageBySrc(string src)
    {
        return Page.Locator($"img[src=\"{src}\"]");
    }

    //-------- User Dashboard
    public ILocator UserProfileLink(string username)
    {
        return Page.GetByRole(AriaRole.Link, new() { Name = username });
    }

    public ILocator UserDashButtonDesktop => Page.Locator("#userDashboardButtonDesktop");

    public ILocator UserDashButtonMobile => Page.Locator("#userDashboardButtonMobile");

    //-------- Navigation Links
    public ILocator AboutLinkDesktop => Page.Locator("#aboutLinkDesktop");

    public ILocator AboutLinkMobile => Page.Locator("#aboutLinkMobile");

    public ILocator ServicesLinkDesktop => Page.Locator("#servicesLinkDesktop");

    public ILocator ServicesLinkMobile => Page.Locator("#servicesLinkMobile");

    public ILocator MembershipLinkDesktop => Page.Locator("#membershipLinkDesktop");

    public ILocator MembershipLinkMobile => Page.Locator("#membershipLinkMobile");

    public ILocator ContactLinkDesktop => Page.Locator("#contactLinkDesktop");

    public ILocator ContactLinkMobile => Page.Locator("#contactLinkMobile");

    //-------- Admin Dashboard
    public ILocator AdminDashboardButtonDesktop => Page.Locator("#adminDashboardButtonDesktop");

    public ILocator AdminDashboardButtonMobile => Page.Locator("#adminDashboardButtonMobile");

    //-------- Auth Pages
    public ILocator AuthPageLinkDesktop => Page.Locator("#authPageLinkDesktop");

    public ILocator AuthPageLinkMobile => Page.Locator("#authPageLinkMobile");

    //-------- Profile & Settings
    public ILocator ForgotPasswordLink => Page.Locator("#forgotPasswordLink");

    public ILocator EditProfileButton => Page.Locator("#editProfileLink");

    public ILocator ResetPasswordLink => Page.Locator("#resetPasswordLink");

    public ILocator PaymentHistoryLink => Page.Locator("#paymentHistoryLink");

    public ILocator OrderSuccessLink => Page.Locator("#orderSuccessLink");

    public ILocator TermsAndConditionsLink => Page.Locator("#termsAndCondLink");

    //-------- Admin Panel Links
    public ILocator AdminManageCoachesLink => Page.Locator("#adminManageCoaches");

    public ILocator AdminManageMembershipsLink => Page.Locator("#adminManageMemberships");

    public ILocator AdminManageDiscountCodesLink => Page.Locator("#adminManageDiscountCodes");

    public ILocator AdminListFeedbacksLink => Page.Locator("#adminListFeedbacks");

    public ILocator AdminActiveMembershipsLink => Page.Locator("#adminActiveMemberships");

    public ILocator AdminOrdersListLink => Page.Locator("#adminOrdersList");

    public ILocator AdminManageUsersLink => Page.Locator("#adminManageUsers");

    public ILocator AdminFeedbacksLink => Page.Locator("#adminFeedbacks");

    public ILocator AdminMembershipsLink => Page.Locator("#adminMemberships");

    public ILocator AdminLogoutLink => Page.Locator("#adminLogout");
}
