using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
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
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
        }


        [SetUp]
        protected void TestSetUp()
        {
            driver = new ChromeDriver(Configuration.DRIVER);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);

            helper = new PageObjectHelper(driver);
            pageObjects = new PageObjectInitializer(driver);
        }

        [TearDown]
        protected void TestTearDown()
        {
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

        [TestCase]
        [Description("Dodanie nowego wniosku o świadczenie socjalne.")]
        public void ZFSS_FUN_2()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.Click(pageObjects.MainPage.AddBenefit);
            helper.Click(pageObjects.MainPage.AddSocialServiceBenefit);
            helper.Click(pageObjects.SocialService.GetUserData);
            helper.SetText(pageObjects.SocialService.Position, "Tester");
            helper.SetText(pageObjects.SocialService.DateOfEmployment, "20.06.2000");
            helper.Click(pageObjects.SocialService.AddRelatives);

            helper.SetText(pageObjects.Relatives.Fullname, "Jan Kowalski");
            helper.SetText(pageObjects.Relatives.DateOfBirth, "01.09.2002");
            helper.SetText(pageObjects.Relatives.DegreeOfRelationship, "Syn");
            helper.SetText(pageObjects.Relatives.Notes, "brak");
            helper.Click(pageObjects.Relatives.Add);
            helper.Click(pageObjects.Relatives.Save);

            helper.SelectByText(pageObjects.SocialService.SocialServiceKind, "dofinansowanie do wypoczynku letniego");
            helper.SetText(pageObjects.SocialService.Year, "2019");
            helper.SetText(pageObjects.SocialService.AverageIncome, "3257");
            helper.SetText(pageObjects.SocialService.AdditionInformation, "Brak");
            helper.Click(pageObjects.SocialService.CreateBenefit);
            helper.AcceptAlert();
        }

        [TestCase]
        [Description("Rejestracja nowego użytkownika w systemie.")]
        public void ZFSS_FUN_3()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.Click(pageObjects.MainPage.AdministrativePanel);
            helper.Click(pageObjects.MainPage.AddUser);

            var date = DateTime.Now.ToString("ddMMyyyyHH24mm");

            helper.SetText(pageObjects.RegisterUser.Username, "TesterAutomatyczny" + date);
            helper.SetText(pageObjects.RegisterUser.Firstname, "Tester");
            helper.SetText(pageObjects.RegisterUser.LastName, "Automatyczny");
            helper.SetText(pageObjects.RegisterUser.Password, "zaq1@WSX");
            helper.SetText(pageObjects.RegisterUser.ConfirmPassword, "zaq1@WSX");
            helper.SetText(pageObjects.RegisterUser.DateOfBirth, "17.05.1999");
            helper.SetText(pageObjects.RegisterUser.PhoneNumber, "123456789");
            helper.SetText(pageObjects.RegisterUser.EmailAddress, "testerautomatyczny" + date + "@gmail.com");
            helper.SetText(pageObjects.RegisterUser.Address, "ul. Testowa 21");
            helper.SetText(pageObjects.RegisterUser.PostCode, "05-009");
            helper.SetText(pageObjects.RegisterUser.City, "Testowe");
            helper.SelectByText(pageObjects.RegisterUser.UserGroup, "Pracownik UZ");
            helper.Click(pageObjects.RegisterUser.Save);
        }

        [TestCase]
        [Description("Wyświetlenie wniosku o świadczenie socjalne")]
        public void ZFSS_FUN_4()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.SetText(pageObjects.MainPage.Search, "Wniosek o świadczenie socjalne");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.ShowBenefit);
            helper.Sleep(2);
            Assert.True(helper.IsDisplayed(pageObjects.MainPage.BenefitDialog));
        }
    }
}
