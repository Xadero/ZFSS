using Microsoft.AspNetCore.Mvc;
using ZfssUZ.Models.Benefit;
using ZfssUZ.Models.Benefit.HomeLoanBenefit;

namespace ZfssUZ.Controllers
{
    public class AddBenefitController : Controller
    {
        public IActionResult AddSocialServiceBenefit()
        {
            var model = new AddSocialServiceBenefitModel();
            return View(model);
        }

        public IActionResult AddHomeLoanBenefit()
        {
            var model = new AddHomeLoanBenefitModel();
            return View(model);
        }
    }
}
