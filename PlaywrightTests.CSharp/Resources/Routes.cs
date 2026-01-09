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
        public const string Login = "http://localhost:5000/Home/AuthPage";
        public const string Register = "http://localhost:5000/Account/Register";
    }

    public static class NavbarLinks
    {
        public const string About = "/Home/About";
        public const string Services = "/Home/Services";
        public const string Membership = "/Home/Membership";
        public const string Contact = "/Feedback/Contact";
        public const string Login = "/Home/AuthPage";
    }

    public static class AllPages
    {
        public const string AboutPage = "http://localhost:5000/Home/About";
        public const string ServicesMainPage = "http://localhost:5000/Home/Services";
        public const string ServicePersonalTrainingPage = "http://localhost:5000/Services/PersonalTraining";
        public const string ServiceGroupProgramsPage = "http://localhost:5000/Services/GroupPrograms";
        public const string ServiceNutritionCoachingPage = "http://localhost:5000/Services/NutritionCoaching";
        public const string MembershipPage = "http://localhost:5000/Home/Membership";
        public const string CheckoutPage = "http://localhost:5000/Checkout/CheckoutMembership?membershipId=1";
        public const string SuccessOrderPage = "http://localhost:5000/Checkout/OrderSuccess";
        public const string TermsAndCondPage = "http://localhost:5000/Checkout/TermsAndConditions";
        public const string AuthLoginPage = "http://localhost:5000/Home/AuthPage";
        public const string UserProfilePage = "http://localhost:5000/Account/UserDashboard";
        public const string ForgotPasswordPage = "http://localhost:5000/Account/ForgotPassword";
        public const string EditProfilePage = "http://localhost:5000/Account/EditUserProfile";
        public const string PaymentHistoryPage = "http://localhost:5000/Account/PaymentHistory";
        public const string AdminDashboardPage = "http://localhost:5000/Admin/AdminDash";
        public const string ManageCoachesPage = "http://localhost:5000/Admin/ManageCoaches";
        public const string ManageMembershipsPage = "http://localhost:5000/Admin/ManageMemberships";
        public const string ManageDiscountCodesPage = "http://localhost:5000/Admin/ManageDiscountCodes";
        public const string ListOfFeedbacksPage = "http://localhost:5000/Admin/ListOfFeedbacks";
        public const string ActiveMembershipsPage = "http://localhost:5000/Admin/ListOfActiveMemberships";
        public const string OrderListPage = "http://localhost:5000/Admin/ListOfOrders";
        public const string ManageUsersPage = "http://localhost:5000/Admin/ListOfUsers";
        public const string ContactPage = "http://localhost:5000/Feedback/Contact";
        public const string ResetPasswordPage = "http://localhost:5000/Account/ResetPassword";
    }
}