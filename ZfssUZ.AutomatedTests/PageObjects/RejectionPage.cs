using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class RejectionPage
    {
        private readonly IWebDriver driver;

        public RejectionPage (IWebDriver driver)
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
        /// Przyczyna odrzucenia
        /// </summary>
        [FindsBy(How = How.Id, Using = "rejectionReason")]
        public IWebElement RejectionReason { get; set; }
    }
}
