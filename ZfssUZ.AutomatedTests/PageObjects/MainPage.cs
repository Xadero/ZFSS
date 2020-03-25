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

    }
}
