using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ZfssUZ.Enums;
using ZfssUZ.Models.Benefit.HomeLoanBenefit;
using ZfssUZ.Models.Benefit.SocialServiceBenefit;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZ.Controllers
{
    public class BenefitController : Controller
    {
        private readonly IMapper mapper;
        private IBenefitService benefitService;
        private IHomeLoanBenefitService homeLoanBenefitService;
        private IDictionaryService dictionaryService;
        private UserManager<ApplicationUser> userManager;
        public BenefitController (IBenefitService benefitService, IDictionaryService dictionaryService, IHomeLoanBenefitService homeLoanBenefitService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.benefitService = benefitService;
            this.dictionaryService = dictionaryService;
            this.homeLoanBenefitService = homeLoanBenefitService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddSocialServiceBenefit()
        {
            TempData["BenefitAddError"] = "Error";
            TempData["BenefitAddSuccess"] = "Success";
            var model = new AddSocialServiceBenefitModel()
            {
                BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 2),
                SocialServiceKindList = new SelectList(benefitService.GetSocialServiceKinds(), "Id", "Value")
            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSocialServiceBenefit(AddSocialServiceBenefitModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult AddHomeLoanBenefit()
        {
            TempData["BenefitAddError"] = "Error";
            TempData["BenefitAddSuccess"] = "Success";
            var model = new AddHomeLoanBenefitModel()
            {
                BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 1)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddHomeLoanBenefit(AddHomeLoanBenefitModel model)
        {
            model.BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 1);
            if (!ModelState.IsValid)
                return View(model);

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
                TempData["BenefitAddSuccess"] = newBenefit.BenefitNumber.ToString();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["BenefitAddError"] = ex.Message;
                return View(model);
            }
        }

        public IActionResult ShowClause()
        {
            return PartialView("BenefitsClauseInfo");
        }
    }
}
