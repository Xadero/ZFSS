using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class PageObjectInitializer
    {
        public MainPage MainPage;
        public LoginPage LoginPage;
        private readonly IWebDriver driver;
        public PageObjectInitializer(IWebDriver driver)
        {
            this.driver = driver;
            MainPage = new MainPage(driver);
            LoginPage = new LoginPage(driver);
        }
    }
}
