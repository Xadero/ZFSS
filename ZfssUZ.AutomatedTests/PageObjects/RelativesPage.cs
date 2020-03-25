using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class RelativesPage
    {
        private readonly IWebDriver driver;
        public RelativesPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Zapisz
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnSave")]
        public IWebElement Save { get; set; }

        /// <summary>
        /// Powrót
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnBack")]
        public IWebElement Back { get; set; }

        /// <summary>
        /// Zamknij okno (x)
        /// </summary>
        [FindsBy(How = How.Id, Using = "closeRelatives")]
        public IWebElement Close { get; set; }

        /// <summary>
        /// Imię i nazwisko
        /// </summary>
        [FindsBy(How = How.Id, Using = "fullName")]
        public IWebElement Fullname { get; set; }

        /// <summary>
        /// Data urodzenia
        /// </summary>
        [FindsBy(How = How.Id, Using = "dateOfBirth")]
        public IWebElement DateOfBirth { get; set; }

        /// <summary>
        /// Stopień pokrewieństwa
        /// </summary>
        [FindsBy(How = How.Id, Using = "degreeOfRelationship")]
        public IWebElement DegreeOfRelationship { get; set; }

        /// <summary>
        /// Uwagi
        /// </summary>
        [FindsBy(How = How.Id, Using = "notes")]
        public IWebElement Notes { get; set; }

        /// <summary>
        /// Dodaj
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnAdd")]
        public IWebElement Add { get; set; }


        /// <summary>
        /// Usuń
        /// </summary>
        [FindsBy(How = How.Id, Using = "deleteRelative")]
        public IWebElement Delete { get; set; }
    }
}
