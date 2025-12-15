namespace PlaywrightTests.CSharp.Resources;

public static class Routes
{
    public static class HomeLinks
    {
        public const string Home = "http://localhost:5000";
        public const string About = "http://localhost:5000/Home/About";
        public const string Services = "http://localhost:5000/Home/Services";
    }

    public static class AuthLinks
    {
        public const string Login = "http://localhost:5000/Account/Login";
        public const string Register = "http://localhost:5000/Account/Register";
    }
}