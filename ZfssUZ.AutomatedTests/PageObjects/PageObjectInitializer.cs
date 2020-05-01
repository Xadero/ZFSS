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
        public RegisterUser RegisterUser;
        public NewHomeLoanBenefitPage HomeLoan;
        public UserListPage UserList;
        public UserInfoPage UserInfo;
        public RelativesPage Relatives;
        public EditUserPage EditUser;
        public AccountManagementPage AccountManagement;

        private readonly IWebDriver driver;
        public PageObjectInitializer(IWebDriver driver)
        {
            this.driver = driver;
            MainPage = new MainPage(driver);
            LoginPage = new LoginPage(driver);
            ContactPage = new ContactPage(driver);
            SocialService = new NewSocialServiceBenefitPage(driver);
            RegisterUser = new RegisterUser(driver);
            HomeLoan = new NewHomeLoanBenefitPage(driver);
            UserList = new UserListPage(driver);
            UserInfo = new UserInfoPage(driver);
            Relatives = new RelativesPage(driver);
            AccountManagement = new AccountManagementPage(driver);
        }
    }
}
