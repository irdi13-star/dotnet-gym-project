namespace PlaywrightTests.CSharp.TestReporting;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


public class ExtentReportManager
{
    private static ExtentReports? _extent;
    private static readonly Lock _lock = new();

    public static ExtentReports GetExtent()
    {
        if (_extent == null)
        {
            lock (_lock)
            {
                if (_extent == null)
                {
                    var reportPath = Path.Combine(
                        TestContext.CurrentContext.WorkDirectory,
                        "test-results",
                        "extent-report.html"
                    );

                    Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);

                    var htmlReporter = new ExtentSparkReporter(reportPath);

                    // Configurare reporter
                    htmlReporter.Config.DocumentTitle = "Playwright Test Report";
                    htmlReporter.Config.ReportName = "MADGYM Automation Tests";
                    // htmlReporter.Config.Theme = Theme.Dark;
                    htmlReporter.Config.Encoding = "UTF-8";

                    _extent = new ExtentReports();
                    _extent.AttachReporter(htmlReporter);

                    // System info
                    _extent.AddSystemInfo("Application", "MADGYM");
                    _extent.AddSystemInfo("Environment", "Test");
                    _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                    _extent.AddSystemInfo(".NET Version", Environment.Version.ToString());
                }
            }
        }
        return _extent;
    }

    public static void Flush()
    {
        _extent?.Flush();
    }
}