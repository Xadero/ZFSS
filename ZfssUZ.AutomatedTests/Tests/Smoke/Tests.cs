using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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

        [TestCase(Description = "Wyświetlenie formularza 'Logowanie'")]
        public void ZFSS_DYM_1()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            var assertions = new List<bool>();
            assertions.Add(pageObjectHelper.IsDisplayed(pageObjects.LoginPage.Username) && pageObjectHelper.IsDisplayed(pageObjects.LoginPage.Username));
            assertions.Add(pageObjectHelper.IsDisplayed(pageObjects.LoginPage.Password) && pageObjectHelper.IsDisplayed(pageObjects.LoginPage.Password));
            assertions.Add(pageObjectHelper.IsDisplayed(pageObjects.LoginPage.Login) && pageObjectHelper.IsDisplayed(pageObjects.LoginPage.Login));
            assertions.Add(pageObjectHelper.IsDisplayed(pageObjects.LoginPage.ForgotPassword) && pageObjectHelper.IsDisplayed(pageObjects.LoginPage.ForgotPassword));
            Assert.True(assertions.TrueForAll(a => a == true));
        }
    }
}
