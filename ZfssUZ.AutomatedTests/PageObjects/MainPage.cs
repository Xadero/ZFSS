using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class MainPage
    {
        private readonly ChromeDriver driver;

        public MainPage(ChromeDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
        }

        public IWebElement Delete => driver.FindElement(By.XPath(""));

    }
}
