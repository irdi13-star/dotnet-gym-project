namespace PlaywrightTests.CSharp.Pages;

public class NavbarFooterPage
{
    private readonly IPage _page;

    public string Navbar => "nav.navbar";
    public string Footer => "footer";
    public string HomeLink => "a[href='/']";
    public string AboutLink => "a[href='/Home/About']";
    public string ServicesLink => "a[href='/Home/Services']";

    public NavbarFooterPage(IPage page)
    {
        _page = page;
    }
}