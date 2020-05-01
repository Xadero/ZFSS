using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class AccountManagementPage
    {
        private readonly IWebDriver driver;

        public AccountManagementPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Zakładka - Profil
        /// </summary>
        [FindsBy(How = How.Id, Using = "profile")]
        public IWebElement Profile { get; set; }

        /// <summary>
        /// Zakładka - Email
        /// </summary>
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement ChangeEmail { get; set; }

        /// <summary>
        /// Zakładka - Hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "change-password")]
        public IWebElement Password { get; set; }

        #region Profil
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement Username { get; set; }

        /// <summary>
        /// Imię
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_FirstName")]
        public IWebElement FirstName { get; set; }

        /// <summary>
        /// Nazwisko
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_LastName")]
        public IWebElement LastName { get; set; }

        /// <summary>
        /// Data urodzenia
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_DateOfBirth")]
        public IWebElement DateOfBirth { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_PhoneNumber")]
        public IWebElement PhoneNumber { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_City")]
        public IWebElement City { get; set; }

        /// <summary>
        /// Adres
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_Address")]
        public IWebElement Address { get; set; }

        /// <summary>
        /// Kod pocztowy
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_PostCode")]
        public IWebElement PostCode { get; set; }

        /// <summary>
        /// Zapisz
        /// </summary>
        [FindsBy(How = How.Id, Using = "update-profile-button")]
        public IWebElement UpdateProfile { get; set; }
        #endregion

        #region Email

        /// <summary>
        /// Email
        /// </summary>
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }

        /// <summary>
        /// Nowy email
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_NewEmail")]
        public IWebElement NewEmail { get; set; }

        /// <summary>
        /// Zaktualizuj email
        /// </summary>
        [FindsBy(How = How.Id, Using = "change-email-button")]
        public IWebElement UpdateEmail { get; set; }
        #endregion

        #region Hasło

        /// <summary>
        /// Aktualne hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_OldPassword")]
        public IWebElement OldPassword { get; set; }

        /// <summary>
        /// Nowe hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_NewPassword")]
        public IWebElement NewPassword { get; set; }

        /// <summary>
        /// Potiwerdź nowe hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "Input_ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }

        /// <summary>
        /// Zaktualizuj hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "updatePassowrd")]
        public IWebElement UpdatePassowrd { get; set; }

        #endregion
    }
}
