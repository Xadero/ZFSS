using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
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
    }
}
