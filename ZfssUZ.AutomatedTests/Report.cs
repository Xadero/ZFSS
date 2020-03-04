using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace ZfssUZ.AutomatedTests
{
    public static class Report
    {
        private static ExtentReports _ExtentReport;
        private static ExtentTest Test;
        private static ExtentHtmlReporter HtmlReporter;
        private static ChromeDriver ChromeDriver;

        private static string Message;
        private static string Description;

        private static string PathToReport = "D:\\Projekty\\SeleniumReports\\" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        private static string FailedScreenshotPath = PathToReport + "Screenshots\\Passed\\";
        private static string PassedScreenshotPath = PathToReport + "Screenshots\\Failed\\";

        public static void ReportOneTimeSetUp()
        {
            HtmlReporter = new ExtentHtmlReporter(PathToReport);
            HtmlReporter.Config.EnableTimeline = true;
            HtmlReporter.Config.Theme = Theme.Dark;
            _ExtentReport = new ExtentReports();
            _ExtentReport.AttachReporter(HtmlReporter);
        }

        public static void ReportSetUp(ChromeDriver chromeDriver)
        {
            ChromeDriver = chromeDriver;
            Message = string.Empty;
            Description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
            Test = _ExtentReport.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public static void ReportTearDown()
        {
            var details = new StringBuilder();
            Status status;
            try
            {
                details.AppendLine("<pre>Nazwa testu:        " + TestContext.CurrentContext.Test.Name);
                details.AppendLine(Description);
                details.AppendLine("<br>Adres url:              " + ChromeDriver.Url);
                details.AppendLine("<br>Status testu:     " + TestContext.CurrentContext.Result.Outcome.Status);
                details.AppendLine("<br>Nazwa strony:        " + TestContext.CurrentContext.Result.Outcome.Site);
                details.AppendLine("<br>Nazwa użytkownika:         " + Environment.UserName);
            }
            catch (Exception)
            {
                status = Status.Fail;
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                status = Status.Pass;
                Test.Log(status);
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                status = Status.Fail;
                Test.Log(status);
            }
            else
            {
                status = Status.Fatal;
                Test.Log(status);
            }

            _ExtentReport.Flush();
        }


        public static void ReportOneTimeTearDown()
        {
            _ExtentReport.Flush();
        }

        public static void AddMessageToTestReport(string message)
        {
            Message = Message + message + "<br>";
        }

        private static string CreateScreenshot(bool isPass)
        {
            if (isPass)
            {
                CreateDirectory(PassedScreenshotPath);
                return PassedScreenshotPath;
            }
            else
            {
                CreateDirectory(FailedScreenshotPath);
                return FailedScreenshotPath;
            }
        }

        private static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
