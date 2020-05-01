using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private PageObjectHelper pageObjectHelper;
        private MainPage mainPage;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
            pageObjectHelper = new PageObjectHelper(driver);
            mainPage = new MainPage(driver);        
        }

        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_Username")]
        public IWebElement Username { get; set; }

        /// <summary>
        /// Hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_Password")]
        public IWebElement Password { get; set; }

        /// <summary>
        //Zapamiętać hasło?
        [FindsBy(How = How.Id, Using = "Input_RememberMe")]
        public IWebElement RememberPassword { get; set; }

        /// <summary>
        /// Pokaż hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "showPassword")]
        public IWebElement ShowPassword { get; set; }

        /// <summary>
        /// Zaloguj
        /// </summary>
        [FindsBy(How = How.Id, Using = "LogInBtn")]
        public IWebElement Login { get; set; }

        /// <summary>
        /// Zapomniałeś hasła?
        /// </summary>
        [FindsBy(How = How.Id, Using = "forgotPassword")]
        public IWebElement ForgotPassword { get; set; }

        public void LogIn()
        {
            if (pageObjectHelper.IsDisplayed(Login))
            {
                pageObjectHelper.SetText(Username, Configuration.LOGIN);
                pageObjectHelper.SetText(Password, Configuration.PASSWORD);
                pageObjectHelper.Click(Login);
                pageObjectHelper.Wait(mainPage.Search);
                if(!pageObjectHelper.IsDisplayed(mainPage.Search))
                    Assert.Fail("Wystąpił błąd logowania!");
            }
        }
    }
}
