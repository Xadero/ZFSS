using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class BenefitClausePage
    {
        private readonly IWebDriver driver;

        public BenefitClausePage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "closeClause")]
        public IWebElement CloseClause { get; set; }
    }
}
