using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class PageObjectInitializer
    {
        public MainPage MainPage;
        public LoginPage LoginPage;
        public ContactPage ContactPage;
        public NewSocialServiceBenefitPage SocialService;
        public NewHomeLoanBenefitPage HomeLoan;
        public RelativesPage Relatives;
        public UserList UserList;
        public UserInfo UserInfo;
        public EditUser EditUser;
        public RegisterUser RegisterUser;

        private readonly IWebDriver driver;
        public PageObjectInitializer(IWebDriver driver)
        {
            this.driver = driver;
            MainPage = new MainPage(driver);
            LoginPage = new LoginPage(driver);
            ContactPage = new ContactPage(driver);
            SocialService = new NewSocialServiceBenefitPage(driver);
            HomeLoan = new NewHomeLoanBenefitPage(driver);
            Relatives = new RelativesPage(driver);
            UserList = new UserList(driver);
            UserInfo = new UserInfo(driver);
            EditUser = new EditUser(driver);
            RegisterUser = new RegisterUser(driver);
        }
    }
}
