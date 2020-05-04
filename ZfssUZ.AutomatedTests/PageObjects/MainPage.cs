using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class MainPage
    {
        private readonly IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        #region Górny panel
        /// <summary>
        /// Lista wniosków
        /// </summary>
        [FindsBy(How = How.Id, Using = "benefitList")]
        public IWebElement BenefitList { get; set; }

        /// <summary>
        /// Lista wniosków
        /// </summary>
        [FindsBy(How = How.Id, Using = "contact")]
        public IWebElement Contact { get; set; }

        /// <summary>
        /// Dodaj wniosek
        /// </summary>
        [FindsBy(How = How.Id, Using = "newBenefit")]
        public IWebElement AddBenefit { get; set; }

        /// <summary>
        /// O pożyczkę mieszkaniową
        /// </summary>
        [FindsBy(How = How.Id, Using = "addHomeLoanBenefit")]
        public IWebElement AddHomeLoanBenefit { get; set; }

        /// <summary>
        /// O świadczenie socjalne
        /// </summary>
        [FindsBy(How = How.Id, Using = "addSocialServiceBenefit")]
        public IWebElement AddSocialServiceBenefit { get; set; }

        /// <summary>
        /// Panel administracyjny
        /// </summary>
        [FindsBy(How = How.Id, Using = "administrativePanel")]
        public IWebElement AdministrativePanel { get; set; }

        /// <summary>
        /// Lista użytkowników
        /// </summary>
        [FindsBy(How = How.Id, Using = "userList")]
        public IWebElement UserList { get; set; }

        /// <summary>
        /// Dodaj użytkownika
        /// </summary>
        [FindsBy(How = How.Id, Using = "addUser")]
        public IWebElement AddUser { get; set; }

        /// <summary>
        /// Imię i nazwisko zalogowanego użytkownika
        /// </summary>
        [FindsBy(How = How.Id, Using = "loggedUser")]
        public IWebElement LoggedUser { get; set; }

        /// <summary>
        /// Pokaż profil
        /// </summary>
        [FindsBy(How = How.Id, Using = "showProfile")]
        public IWebElement ShowProfile { get; set; }

        /// <summary>
        /// Wyloguj
        /// </summary>
        [FindsBy(How = How.Id, Using = "logout")]
        public IWebElement Logout { get; set; }

        /// <summary>
        /// Accept Cookies
        /// </summary>
        [FindsBy(How = How.Id, Using = "acceptCookies")]
        public IWebElement AcceptCookies { get; set; }
        #endregion

        /// <summary>
        /// Szukaj
        /// </summary>
        [FindsBy(How = How.Id, Using = "searchBenefit")]
        public IWebElement Search { get; set; }

        /// <summary>
        /// Wyświetl
        /// </summary>
        [FindsBy(How = How.Id, Using = "showBenefit")]
        public IWebElement ShowBenefit { get; set; }

        /// <summary>
        /// Edytuj
        /// </summary>
        [FindsBy(How = How.Id, Using = "editBenefit")]
        public IWebElement EditBenefit { get; set; }

        /// <summary>
        /// Usuń
        /// </summary>
        [FindsBy(How = How.Id, Using = "deleteBenefit")]
        public IWebElement DeleteBenefit { get; set; }

        /// <summary>
        /// Przyjmij do weryfikacji
        /// </summary>
        [FindsBy(How = How.Id, Using = "verifyBenefit")]
        public IWebElement VerifyBenefit { get; set; }

        /// <summary>
        /// Zatwierdź wniosek
        /// </summary>
        [FindsBy(How = How.Id, Using = "acceptBenefit")]
        public IWebElement AcceptBenefit { get; set; }

        /// <summary>
        /// Odrzuć wniosek
        /// </summary>
        [FindsBy(How = How.Id, Using = "rejectBenefit")]
        public IWebElement RejectBenefit { get; set; }

        /// <summary>
        /// Następna strona
        /// </summary>
        [FindsBy(How = How.Id, Using = ".//*[@id='benefitTable_next']/a")]
        public IWebElement NextPage { get; set; }

        /// <summary>
        /// Poprzednia strona
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='benefitTable_previous']/a")]
        public IWebElement PreviousPage { get; set; }

        /// <summary>
        /// Ilość wierszy na stronie
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='benefitTable_length']/label/select")]
        public IWebElement RowsOnPage { get; set; }

        /// <summary>
        /// Pierwszy wiersz w tabeli
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='benefitTable']//tbody//tr[1]")]
        public IWebElement FirstRowInGrid { get; set; }

        /// <summary>
        /// Numer wniosku w wierwszym gridzie w siatce
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='benefitTable']//tbody//tr[1]//td[4]")]
        public IWebElement BenefitNumberFirstRow { get; set; }

        /// <summary>
        /// Status wniosku
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='benefitTable']//tbody//tr[1]//td[9]")]
        public IWebElement BenefitStatus { get; set; }

        /// <summary>
        /// Okno wyświetlenia wniosku
        /// </summary>
        [FindsBy(How = How.Id, Using = "showBenefitModal")]
        public IWebElement BenefitDialog { get; set; }
    }
}
