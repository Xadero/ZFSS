using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class UserListPage
    {
        private readonly IWebDriver driver;
        public UserListPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Szukaj
        /// </summary>
        [FindsBy(How = How.Id, Using = "myInput")]
        public IWebElement Search { get; set; }

        /// <summary>
        /// Siatka danych
        /// </summary>
        [FindsBy(How = How.Id, Using = "userIndexTable")]
        public IWebElement Grid { get; set; }

        /// <summary>
        /// Wyświetl
        /// </summary>
        [FindsBy(How = How.Id, Using = "showUserData")]
        public IWebElement Show { get; set; }

        /// <summary>
        /// Edytuj
        /// </summary>
        [FindsBy(How = How.Id, Using = "editUser")]
        public IWebElement Edit { get; set; }

        /// <summary>
        /// Usuń
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[contains(@id, 'deleteUser')]")]
        public IWebElement Delete { get; set; }

        /// <summary>
        /// Zablokuj
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[contains(@id, 'lockUser')]")]
        public IWebElement Lock { get; set; }

        /// <summary>
        /// Odblokuj
        /// </summary>
        [FindsBy(How = How.Id, Using = "unlockUser")]
        public IWebElement Unlock { get; set; }
    }
}
