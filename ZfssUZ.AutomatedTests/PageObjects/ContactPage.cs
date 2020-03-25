using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class ContactPage
    {
        private readonly IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Forma kontaktu - E-mail
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='ContactForm' and @value=1]")]
        public IWebElement Email { get; set; }

        /// <summary>
        /// Forma kontaktu - Numer telefonu
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='ContactForm' and @value=2]")]
        public IWebElement Phone { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [FindsBy(How = How.Id, Using = "EmailAddress")]
        public IWebElement EmailAddress { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        public IWebElement PhoneNumber { get; set; }

        /// <summary>
        /// Treść wiadomości
        /// </summary>
        [FindsBy(How = How.Id, Using = "MessageContent")]
        public IWebElement MessageContent { get; set; }

        /// <summary>
        /// Wyślij
        /// </summary>
        [FindsBy(How = How.Id, Using = "sendMessage")]
        public IWebElement SendMessage { get; set; }

        /// <summary>
        /// Powrót
        /// </summary>
        [FindsBy(How = How.Id, Using = "backToBenefitList")]
        public IWebElement Back { get; set; }
    }
}
