using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class ForgotPasswordPage
    {
        private readonly IWebDriver driver;

        public ForgotPasswordPage(IWebDriver driver)
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
        /// E-mail
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_Email")]
        public IWebElement Email { get; set; }

        /// <summary>
        /// Przypomnij hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "remindPassword")]
        public IWebElement RemindPassword { get; set; }

        /// <summary>
        /// Wróć do logowania
        /// </summary>
        [FindsBy(How = How.Id, Using = "backToLogin")]
        public IWebElement BackToLogin { get; set; }
    }
}
