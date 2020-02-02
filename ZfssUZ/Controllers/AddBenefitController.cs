using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using ZfssUZ.Enums;
using ZfssUZ.Models.Benefit;
using ZfssUZ.Models.Benefit.HomeLoanBenefit;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZ.Controllers
{
    public class AddBenefitController : Controller
    {
        private readonly IMapper mapper;
        private IBenefitService benefitService;
        private IHomeLoanBenefitService homeLoanBenefitService;
        private IDictionaryService dictionaryService;
        private UserManager<ApplicationUser> userManager;
        public AddBenefitController (IBenefitService benefitService, IDictionaryService dictionaryService, IHomeLoanBenefitService homeLoanBenefitService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.benefitService = benefitService;
            this.dictionaryService = dictionaryService;
            this.homeLoanBenefitService = homeLoanBenefitService;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public IActionResult AddSocialServiceBenefit()
        {
            var model = new AddSocialServiceBenefitModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddHomeLoanBenefit()
        {
            var model = new AddHomeLoanBenefitModel()
            {
                BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 1)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddHomeLoanBenefit(AddHomeLoanBenefitModel model)
        {
            model.BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 1);
            var newBenefit = new HomeLoanBenefit()
            {
                BeneficiaryName = model.BeneficiaryName,
                BeneficiaryAddress = model.BeneficiaryAddress,
                BeneficiaryPhoneNumber = model.BeneficiaryPhoneNumber,
                BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.Passed),
                BenefitType = dictionaryService.Get<BenefitType>((int)eBenefitType.HomeLoanBenefit),
                LoanCost = model.LoanCost,
                Instalment = model.Instalment,
                LoanPurpose = model.LoanPurpose,
                Months = model.Months,
                SubmittingDate = DateTime.Now,
                SubmittingUser = userManager.GetUserAsync(User).Result,
                BenefitNumber = homeLoanBenefitService.GenerateBenefitNumber()
            };

            try
            {
                homeLoanBenefitService.CreateBenefit(newBenefit);
                return Json(new { success = true });
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }
    }
}
