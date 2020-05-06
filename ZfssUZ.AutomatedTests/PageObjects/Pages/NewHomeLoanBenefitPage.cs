using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class NewHomeLoanBenefitPage
    {
        private readonly IWebDriver driver;
        public NewHomeLoanBenefitPage(IWebDriver driver)
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
        /// Kwota pożyczki
        /// </summary>
        [FindsBy(How = How.Id, Using = "LoanCost")]
        public IWebElement LoanCost { get; set; }

        /// <summary>
        /// Cel pożyczki
        /// </summary>
        [FindsBy(How = How.Id, Using = "LoanPurpose")]
        public IWebElement LoanPurpose { get; set; }

        /// <summary>
        /// Liczba miesięcy
        /// </summary>
        [FindsBy(How = How.Id, Using = "Months")]
        public IWebElement Months { get; set; }

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
