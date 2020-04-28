using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZ.AutomatedTests.PageObjects;

namespace ZfssUZ.AutomatedTests.Tests.Functional
{
    public class Tests
    {
        private ChromeDriver driver;
        private PageObjectInitializer pageObjects;
        private PageObjectHelper helper;


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

            helper = new PageObjectHelper(driver);
            pageObjects = new PageObjectInitializer(driver);
        }

        [TearDown]
        protected void TestTearDown()
        {
            //Report.ReportTearDown();

            driver.Quit();
        }

        [TestCase]
        [Description("Zalogowanie do aplikacji ZFŚS")]
        public void ZFSS_FUN_1()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            if (!helper.IsDisplayed(pageObjects.LoginPage.Login))
                Assert.Fail();

            pageObjects.LoginPage.LogIn();
        }
    }
}
