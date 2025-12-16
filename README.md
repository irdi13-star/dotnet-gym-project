# Gym Website

The Gym Website is designed to offer various membership options and services for customers.

---

## Prerequisites

To run this project locally, make sure you have the following installed:

- .NET SDK
- C# extension (for Visual Studio Code)

---

## Running the Application

1. Navigate to the web project:
   ```bash
   cd WebsiteGym.Web
   ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Start the application:
    ```bash
    dotnet run
    ```

The website will be available at: 
    ```ardruino
    http://localhost:5000
    ```


## Running CI/Automation Tests

The application must be running before executing the tests.

1. Open a new terminal and navigate to the Playwright test project:
   ```bash
   cd PlaywrightTests.CSharp
   ```

2. Run regression tests:
    ```bash
    dotnet test --filter "Category=regression"
    ```

3. (Optional) Run tests in Playwright debug mode:
    ```bash
    PWDEBUG=1 dotnet test --filter "Category=regression"
    ```


## Test Artifacts

After test execution, the following artifacts may be generated:

- Screenshots (on test failure)
- Playwright traces
- HTML test reports (ExtentReports)

These artifacts are also uploaded automatically in CI (GitHub Actions).