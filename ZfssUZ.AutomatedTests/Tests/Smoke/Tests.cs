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

        [TestCase(Description = "Wyświetlenie formularza 'Logowanie'")]
        public void ZFSS_DYM_1()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.LoginPage.Username) && helper.IsDisplayed(pageObjects.LoginPage.Username));
            assertions.Add(helper.IsDisplayed(pageObjects.LoginPage.Password) && helper.IsDisplayed(pageObjects.LoginPage.Password));
            assertions.Add(helper.IsDisplayed(pageObjects.LoginPage.Login) && helper.IsDisplayed(pageObjects.LoginPage.Login));
            Assert.True(assertions.TrueForAll(a => a == true));
        }

        [TestCase(Description = "Wyśeitlenie formularza 'Lista wniosków'")]
        public void ZFSS_DYM_2()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.MainPage.ShowBenefit) && helper.IsDisplayed(pageObjects.MainPage.ShowBenefit));
            assertions.Add(helper.IsDisplayed(pageObjects.MainPage.Search) && helper.IsDisplayed(pageObjects.MainPage.Search));
            Assert.True(assertions.TrueForAll(a => a == true));
        }

        [TestCase(Description = "Wyśeitlenie formularza 'Nowy wniosek o świadczenie socjalne'")]
        public void ZFSS_DYM_3()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AddBenefit);
            helper.Click(pageObjects.MainPage.AddSocialServiceBenefit);
            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.BeneficiaryName) && helper.IsDisplayed(pageObjects.SocialService.BeneficiaryName));
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.Position) && helper.IsDisplayed(pageObjects.SocialService.Position));
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.CreateBenefit) && helper.IsDisplayed(pageObjects.SocialService.CreateBenefit));
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.BackToBenefitList) && helper.IsDisplayed(pageObjects.SocialService.BackToBenefitList));
            Assert.True(assertions.TrueForAll(a => a == true));
        }

        [TestCase(Description = "Wyśeitlenie formularza 'Rejestracja użytkownika'")]
        public void ZFSS_DYM_4()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AdministrativePanel);
            helper.Click(pageObjects.MainPage.AddUser);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.RegisterUser.Username) && helper.IsDisplayed(pageObjects.RegisterUser.Username));
            assertions.Add(helper.IsDisplayed(pageObjects.RegisterUser.UserGroup) && helper.IsDisplayed(pageObjects.RegisterUser.UserGroup));
            assertions.Add(helper.IsDisplayed(pageObjects.RegisterUser.PostCode) && helper.IsDisplayed(pageObjects.RegisterUser.PostCode));
            assertions.Add(helper.IsDisplayed(pageObjects.RegisterUser.Save) && helper.IsDisplayed(pageObjects.RegisterUser.Save));
            Assert.True(assertions.TrueForAll(a => a == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Kontakt z obsługą klienta ZFŚS'")]
        public void ZFSS_DYM_5()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.Contact);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.ContactPage.Back) && helper.IsEnabled(pageObjects.ContactPage.Back));
            assertions.Add(helper.IsDisplayed(pageObjects.ContactPage.SendMessage) && helper.IsEnabled(pageObjects.ContactPage.SendMessage));
            assertions.Add(helper.IsDisplayed(pageObjects.ContactPage.EmailAddress) && helper.IsEnabled(pageObjects.ContactPage.EmailAddress));
            assertions.Add(helper.IsDisplayed(pageObjects.ContactPage.MessageContent) && helper.IsEnabled(pageObjects.ContactPage.MessageContent));

            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Członkowie rodziny'")]
        public void ZFSS_DYM_6()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AddBenefit);
            helper.Click(pageObjects.MainPage.AddSocialServiceBenefit);
            helper.Click(pageObjects.SocialService.AddRelatives);
            Thread.Sleep(2000);
            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.Relatives.DegreeOfRelationship) && helper.IsEnabled(pageObjects.Relatives.DegreeOfRelationship));
            assertions.Add(helper.IsDisplayed(pageObjects.Relatives.DateOfBirth) && helper.IsEnabled(pageObjects.Relatives.DateOfBirth));

            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Nowy wniosek o pożyczkę mieszkaniową'")]
        public void ZFSS_DYM_7()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AddBenefit);
            helper.Click(pageObjects.MainPage.AddHomeLoanBenefit);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.BeneficiaryName) && helper.IsEnabled(pageObjects.HomeLoan.BeneficiaryName));
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.LoanPurpose) && helper.IsEnabled(pageObjects.HomeLoan.LoanPurpose));
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.CreateBenefit) && helper.IsEnabled(pageObjects.HomeLoan.CreateBenefit));
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.BackToBenefitList) && helper.IsEnabled(pageObjects.HomeLoan.BackToBenefitList));

            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Lista użytkowników")]
        public void ZFSS_DYM_8()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AdministrativePanel);
            helper.Click(pageObjects.MainPage.UserList);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.UserList.Search) && helper.IsEnabled(pageObjects.UserList.Search));
            assertions.Add(helper.IsDisplayed(pageObjects.UserList.Grid) && helper.IsEnabled(pageObjects.UserList.Grid));
            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Informacje o użytkowniku")]
        public void ZFSS_DYM_9()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AdministrativePanel);
            helper.Click(pageObjects.MainPage.UserList);
            helper.SetText(pageObjects.UserList.Search, Configuration.LOGIN);
            helper.Click(pageObjects.UserList.Show);
            Thread.Sleep(2000);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.UserInfo.Username) && !helper.IsEnabled(pageObjects.UserInfo.Username));
            assertions.Add(helper.IsDisplayed(pageObjects.UserInfo.Firstname) && !helper.IsEnabled(pageObjects.UserInfo.Firstname));
            assertions.Add(helper.IsDisplayed(pageObjects.UserInfo.Address) && !helper.IsEnabled(pageObjects.UserInfo.Address));
            assertions.Add(helper.IsDisplayed(pageObjects.UserInfo.PhoneNumber) && !helper.IsEnabled(pageObjects.UserInfo.PhoneNumber));
            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Edycja użytkownika'")]
        public void ZFSS_DYM_10()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.AdministrativePanel);
            helper.Click(pageObjects.MainPage.UserList);
            helper.SetText(pageObjects.UserList.Search, Configuration.LOGIN);
            helper.Click(pageObjects.UserList.Edit);
            Thread.Sleep(2000);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.EditUser.Username) && helper.IsEnabled(pageObjects.EditUser.Username));
            assertions.Add(helper.IsDisplayed(pageObjects.EditUser.PostCode) && helper.IsEnabled(pageObjects.EditUser.PostCode));
            assertions.Add(helper.IsDisplayed(pageObjects.EditUser.UserGroup) && helper.IsEnabled(pageObjects.EditUser.UserGroup));
            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie górnego panelu aplikacji")]
        public void ZFSS_DYM_11()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.MainPage.AdministrativePanel) && helper.IsEnabled(pageObjects.MainPage.AdministrativePanel));
            assertions.Add(helper.IsDisplayed(pageObjects.MainPage.AddBenefit) && helper.IsEnabled(pageObjects.MainPage.AddBenefit));
            assertions.Add(helper.IsDisplayed(pageObjects.MainPage.Contact) && helper.IsEnabled(pageObjects.MainPage.Contact));
            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Edycja wniosku o świadczenie socjalne'")]
        public void ZFSS_DYM_12()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.SetText(pageObjects.MainPage.Search, "Wniosek o świadczenie socjalne przekazany");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.EditBenefit);
            var assertions = new List<bool>();
            
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.BeneficiaryName) && helper.IsEnabled(pageObjects.SocialService.BeneficiaryName));
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.Position) && helper.IsEnabled(pageObjects.SocialService.Position));
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.SaveBenefit) && helper.IsEnabled(pageObjects.SocialService.SaveBenefit));
            assertions.Add(helper.IsDisplayed(pageObjects.SocialService.BackToBenefitList) && helper.IsEnabled(pageObjects.SocialService.BackToBenefitList));
            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Edycja wniosku o pożyczkę mieszkaniową'")]
        public void ZFSS_DYM_13()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.SetText(pageObjects.MainPage.Search, "Wniosek o pożyczkę mieszkaniową przekazany");
            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.EditBenefit);
            var assertions = new List<bool>();

            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.BeneficiaryName) && helper.IsEnabled(pageObjects.HomeLoan.BeneficiaryName));
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.LoanPurpose) && helper.IsEnabled(pageObjects.HomeLoan.LoanPurpose));
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.SaveBenefit) && helper.IsEnabled(pageObjects.HomeLoan.SaveBenefit));
            assertions.Add(helper.IsDisplayed(pageObjects.HomeLoan.BackToBenefitList) && helper.IsEnabled(pageObjects.HomeLoan.BackToBenefitList));
            Assert.True(assertions.TrueForAll(x => x == true));
        }

        [TestCase(Description = "Wyświetlenie formularza 'Zarządzanie kontem")]
        public void ZFSS_DYM_14()
        {
            driver.Navigate().GoToUrl(Configuration.URL);
            pageObjects.LoginPage.LogIn();
            helper.Click(pageObjects.MainPage.LoggedUser);
            helper.Click(pageObjects.MainPage.ShowProfile);

            var assertions = new List<bool>();
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.Username) && !helper.IsEnabled(pageObjects.AccountManagement.Username));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.FirstName) && !helper.IsEnabled(pageObjects.AccountManagement.FirstName));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.PhoneNumber) && helper.IsEnabled(pageObjects.AccountManagement.PhoneNumber));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.UpdateProfile) && helper.IsEnabled(pageObjects.AccountManagement.UpdateProfile));

            helper.Click(pageObjects.AccountManagement.ChangeEmail);
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.Email) && !helper.IsEnabled(pageObjects.AccountManagement.Email));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.NewEmail) && helper.IsEnabled(pageObjects.AccountManagement.NewEmail));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.UpdateEmail) && helper.IsEnabled(pageObjects.AccountManagement.UpdateEmail));

            helper.Click(pageObjects.AccountManagement.Password);
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.OldPassword) && helper.IsEnabled(pageObjects.AccountManagement.OldPassword));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.NewPassword) && helper.IsEnabled(pageObjects.AccountManagement.NewPassword));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.ConfirmPassword) && helper.IsEnabled(pageObjects.AccountManagement.ConfirmPassword));
            assertions.Add(helper.IsDisplayed(pageObjects.AccountManagement.UpdatePassowrd) && helper.IsEnabled(pageObjects.AccountManagement.UpdatePassowrd));
            Assert.True(assertions.TrueForAll(x => x == true));
        }
    }
}
