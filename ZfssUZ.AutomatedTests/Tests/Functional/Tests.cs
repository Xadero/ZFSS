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

        [TestCase]
        [Description("Edycja wniosku o świadczenie socjalne")]
        public void ZFSS_FUN_5()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.SetText(pageObjects.MainPage.Search, "Wniosek o pożyczkę mieszkaniową Przekazany");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.EditBenefit);

            helper.SetText(pageObjects.SocialService.AdditionInformation, "brak TA");
            helper.SetText(pageObjects.SocialService.Year, DateTime.Now.AddYears(1).Year.ToString());
            helper.Click(pageObjects.SocialService.SaveBenefit);
            helper.AcceptAlert();
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.ShowBenefit);
        }

        [TestCase]
        [Description("Usunięcie wniosku")]
        public void ZFSS_FUN_6()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.SetText(pageObjects.MainPage.Search, "Przekazany");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            var benefitNumber = pageObjects.MainPage.BenefitNumberFirstRow.Text;
            helper.Click(pageObjects.MainPage.DeleteBenefit);
            helper.Sleep(1);
            helper.AcceptAlert();
            helper.AcceptAlert();

            helper.SetText(pageObjects.MainPage.Search, benefitNumber);
            Assert.True(pageObjects.MainPage.FirstRowInGrid.GetAttribute("value") == "No matching records found");
        }

        [TestCase]
        [Description("Przyjęcie wniosku do weryfikacji")]
        public void ZFSS_FUN_7()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.SetText(pageObjects.MainPage.Search, "Przekazany");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.VerifyBenefit);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "W trakcie weryfikacji");
        }

        [TestCase]
        [Description("Zatwierdzenie wniosku")]
        public void ZFSS_FUN_8()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.SetText(pageObjects.MainPage.Search, "W trakcie weryfikacji");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.AcceptBenefit);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "Zatwierdzony");
        }

        [TestCase]
        [Description("Odrzucenie wniosku")]
        public void ZFSS_FUN_9()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.SetText(pageObjects.MainPage.Search, "W trakcie weryfikacji");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.RejectBenefit);

            helper.SetText(pageObjects.RejectionPage.RejectionReason, "Odrzeucenie przez test automatyczny");
            helper.Click(pageObjects.RejectionPage.Save);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "Odrzucony");
        }

        [TestCase]
        [Description("Dodanie nowego wniosku o pożyczkę mieszkaniową")]
        public void ZFSS_FUN_10()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.Click(pageObjects.MainPage.AddBenefit);
            helper.Click(pageObjects.MainPage.AddHomeLoanBenefit);

            helper.Click(pageObjects.HomeLoan.GetUserData);
            helper.SetText(pageObjects.HomeLoan.LoanCost, "1000");
            helper.SetText(pageObjects.HomeLoan.LoanPurpose, "Test automatyczny");
            helper.SetText(pageObjects.HomeLoan.Months, "10");

            helper.Click(pageObjects.HomeLoan.CreateBenefit);
            helper.AcceptAlert();
            Assert.IsTrue(pageObjects.MainPage.BenefitNumberFirstRow != null);
        }

        [TestCase]
        [Description("Edycja wniosku o pożyczkę mieszkaniową")]
        public void ZFSS_FUN_11()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Wyświetlenie wniosku o pożyczkę mieszkaniową")]
        public void ZFSS_FUN_12()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Edycja danych konta użytkownika")]
        public void ZFSS_FUN_13()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Usunięcie konta użytkownika")]
        public void ZFSS_FUN_14()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Zablokowanie użytkownika")]
        public void ZFSS_FUN_15()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Odblokowanie użytkownika")]
        public void ZFSS_FUN_16()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Edycja danych aktualnie zalogowanego użytkownika")]
        public void ZFSS_FUN_17()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Wysłanie wiadomości do obsługi klienta")]
        public void ZFSS_FUN_18()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
        }

        [TestCase]
        [Description("Wylogowanie z aplikacji ZFŚS")]
        public void ZFSS_FUN_19()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();

            helper.Click(pageObjects.MainPage.LoggedUser);
            helper.Click(pageObjects.MainPage.Logout);

            helper.Sleep(1);

            Assert.True(helper.IsDisplayed(pageObjects.LoginPage.Login));
        }
    }
}
