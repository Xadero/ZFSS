using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZ.AutomatedTests.PageObjects;

namespace ZfssUZ.AutomatedTests.Tests.Business
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
        [Description("Rejestracja i przeprocedowanie wniosku o świadczenie socjalne do statusu 'Zaakceptowany'")]
        public void ZFSS_BIZ_1()
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

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.VerifyBenefit);
            helper.AcceptAlert();

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.AcceptBenefit);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "Zaakceptowany");
        }

        [TestCase]
        [Description("Rejestracja i przeprocedowanie wniosku o świadczenie socjalne do statusu 'Odrzucony'")]
        public void ZFSS_BIZ_2()
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

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.VerifyBenefit);
            helper.AcceptAlert();

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.RejectBenefit);

            helper.SetText(pageObjects.RejectionPage.RejectionReason, "Odrzucenie przez test automatyczny");
            helper.Click(pageObjects.RejectionPage.Save);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "Odrzucony");
        }

        [TestCase]
        [Description("Rejestracja i przeprocedowanie wniosku o pożyczkę mieszkaniową do statusu 'Zaakceptowany'")]
        public void ZFSS_BIZ_3()
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

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.VerifyBenefit);
            helper.AcceptAlert();

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.AcceptBenefit);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "Zaakceptowany");
        }

        [TestCase]
        [Description("Rejestracja i przeprocedowanie wniosku o pożyczkę mieszkaniową do statusu 'Odrzucony'")]
        public void ZFSS_BIZ_4()
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

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.VerifyBenefit);
            helper.AcceptAlert();

            helper.Click(pageObjects.MainPage.FirstRowInGrid);
            helper.Click(pageObjects.MainPage.RejectBenefit);

            helper.SetText(pageObjects.RejectionPage.RejectionReason, "Odrzucenie przez test automatyczny");
            helper.Click(pageObjects.RejectionPage.Save);

            helper.AcceptAlert();

            Assert.IsTrue(pageObjects.MainPage.BenefitStatus.Text == "Odrzucony");
        }
    }
}
