using System;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ZfssUZ.Enums;
using ZfssUZ.Helper;
using ZfssUZ.Models;
using ZfssUZ.Models.Home;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Users;

namespace ZfssUZ.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var model = new ContactModel
            {
                ContactForm = (int)eMessageType.EmailAddress
            };

            TempData["IsSent"] = false;

            return View(model);
        }

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = userManager.GetUserAsync(User).Result;
            var contact = model.ContactForm == (int)eMessageType.EmailAddress ? model.EmailAddress : model.PhoneNumber.ToString();
            EmailSender.SendEmail(contact, user.FirstName, user.LastName, model.MessageContent, model.ContactForm);
            TempData["IsSent"] = true;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
