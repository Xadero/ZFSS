using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class MainPage
    {
        private readonly ChromeDriver driver;

        public MainPage(ChromeDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "myInput")]
        public IWebElement Search { get; set; }

    }
}
