namespace PlaywrightTests.CSharp.Helpers;

using Bogus;

public static class TestDataGenerator
{
    private static readonly Faker _faker = new();

    public static string GenerateUsername(int minLength = 5)
    {
        return _faker.Internet.UserName().PadRight(minLength, 'x');
    }

    public static string GenerateEmail()
    {
        return _faker.Internet.Email();
    }

    public static string GeneratePassword(int length = 10)
    {
        return _faker.Internet.Password(length, false, "", "Aa1!");
    }

    public static (string Username, string Email, string Password) GenerateUserCredentials()
    {
        return (
            GenerateUsername(),
            GenerateEmail(),
            GeneratePassword()
        );
    }
}