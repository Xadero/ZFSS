using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class NewSocialServiceBenefitPage
    {
        private readonly IWebDriver driver;

        public NewSocialServiceBenefitPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Pobierz dane swojego użytkownika
        /// </summary>
        [FindsBy(How = How.Id, Using = "GetUserData")]
        public IWebElement GetUserData { get; set; }

        /// <summary>
        /// Klauzula ZFŚS
        /// </summary>
        [FindsBy(How = How.Id, Using = "showClause")]
        public IWebElement ShowClause { get; set; }

        /// <summary>
        /// Imię i nazwisko wnioskodawcy
        /// </summary>
        [FindsBy(How = How.Id, Using = "BeneficiaryName")]
        public IWebElement BeneficiaryName { get; set; }

        /// <summary>
        /// Stanowisko
        /// </summary>
        [FindsBy(How = How.Id, Using = "Position")]
        public IWebElement Position { get; set; }

        /// <summary>
        /// Data zatrudnienia
        /// </summary>
        [FindsBy(How = How.Id, Using = "DateOfEmployment")]
        public IWebElement DateOfEmployment { get; set; }

        /// <summary>
        /// Adres zamieszkania wnioskodawcy
        /// </summary>
        [FindsBy(How = How.Id, Using = "BeneficiaryAddress")]
        public IWebElement BeneficiaryAddress { get; set; }

        /// <summary>
        /// Numer telefonu wnioskodawcy
        /// </summary>
        [FindsBy(How = How.Id, Using = "BeneficiaryPhoneNumber")]
        public IWebElement BeneficiaryPhoneNumber { get; set; }

        /// <summary>
        /// Dodaj członków rodziny
        /// </summary>
        [FindsBy(How = How.Id, Using = "addRelatives")]
        public IWebElement AddRelatives { get; set; }

        /// <summary>
        /// Rodzaj świadczenia socjalnego
        /// </summary>
        [FindsBy(How = How.Id, Using = "SocialServiceKind_Id")]
        public IWebElement SocialServiceKind { get; set; }

        /// <summary>
        /// Rok
        /// </summary>
        [FindsBy(How = How.Id, Using = "Year")]
        public IWebElement Year { get; set; }

        /// <summary>
        /// Średnia dochodu netto na osobę
        /// </summary>
        [FindsBy(How = How.Id, Using = "AverageIncome")]
        public IWebElement AverageIncome { get; set; }

        /// <summary>
        /// Informacje dodatkowe
        /// </summary>
        [FindsBy(How = How.Id, Using = "AdditionInformation")]
        public IWebElement AdditionInformation { get; set; }

        /// <summary>
        /// Złóż wniosek
        /// </summary>
        [FindsBy(How = How.Id, Using = "createBenefit")]
        public IWebElement CreateBenefit { get; set; }

        /// <summary>
        /// Powrót do listy wniosków
        /// </summary>
        [FindsBy(How = How.Id, Using = "backToBenefitList")]
        public IWebElement BackToBenefitList { get; set; }

        /// <summary>
        /// Zapisz
        /// </summary>
        [FindsBy(How = How.Id, Using = "saveBenefit")]
        public IWebElement SaveBenefit { get; set; }
    }
}
