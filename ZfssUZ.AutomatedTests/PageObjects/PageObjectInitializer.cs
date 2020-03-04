using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class PageObjectInitializer
    {
        public MainPage MainPage;
        private readonly ChromeDriver driver;
        public PageObjectInitializer(ChromeDriver driver)
        {
            this.driver = driver;
            MainPage = new MainPage(driver);
        }
    }
}
