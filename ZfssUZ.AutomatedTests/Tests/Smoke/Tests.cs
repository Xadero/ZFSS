using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using ZfssUZ.AutomatedTests.PageObjects;

namespace ZfssUZ.AutomatedTests.Tests.Smoke
{
    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver;
        private PageObjectInitializer pageObjects;
        private PageObjectHelper pageObjectHelper;


        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            //Report.ReportOneTimeSetUp();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            //Report.ReportOneTimeTearDown();
        }


        [SetUp]
        protected void TestSetUp()
        {
            driver = new ChromeDriver(@"D:\Projekty\ZFSS\ZfssUZ.AutomatedTests");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);

            //Report.ReportSetUp(driver);

            pageObjectHelper = new PageObjectHelper(driver);
            pageObjects = new PageObjectInitializer(driver);
        }

        [TearDown]
        protected void TestTearDown()
        {
            //Report.ReportTearDown();

            driver.Quit();
        }

        [TestCase(Description = "TestowyTestSimple1")]
        public void Test1()
        {
            driver.Navigate().GoToUrl("http://localhost/zfss");
            pageObjectHelper.SetTextOnWebElement(pageObjects.LoginPage.Username, "admin");
            pageObjectHelper.SetTextOnWebElement(pageObjects.LoginPage.Password, "zaq1@WSX");
            pageObjectHelper.Click(pageObjects.LoginPage.ShowPassword);
            Thread.Sleep(10000);
        }
    }
}
