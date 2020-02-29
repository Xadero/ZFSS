using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ZfssUZ.Data.Models.Benefits;
using ZfssUZ.Enums;
using ZfssUZ.Models.Benefit;
using ZfssUZ.Models.Benefit.HomeLoanBenefit;
using ZfssUZ.Models.Benefit.SocialServiceBenefit;
using ZfssUZ.Models.Users;
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
        private ISocialServiceBenefitService socialServiceBenefitService;
        private IDictionaryService dictionaryService;
        private IUserService userService;
        private UserManager<ApplicationUser> userManager;
        private static List<RelativesModel> relativesModel = new List<RelativesModel>();
        public BenefitController (IBenefitService benefitService, IUserService userService, IDictionaryService dictionaryService, IHomeLoanBenefitService homeLoanBenefitService,ISocialServiceBenefitService socialServiceBenefitService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.benefitService = benefitService;
            this.dictionaryService = dictionaryService;
            this.homeLoanBenefitService = homeLoanBenefitService;
            this.socialServiceBenefitService = socialServiceBenefitService;
            this.userService = userService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<BenefitsViewModel> benefitsList;
            var benefits = benefitService.GetBenefits(userManager.GetUserAsync(User).Result).ToList();

            if (benefits.Any())
            {
                benefitsList = benefits.Select(x => new BenefitsViewModel
                {
                    AcceptingDate = x.AcceptingDate,
                    BeneficiaryAddress = x.BeneficiaryAddress,
                    BeneficiaryName = x.BeneficiaryName,
                    BeneficiaryPhoneNumber = x.BeneficiaryPhoneNumber,
                    BenefitNumber = x.BenefitNumber,
                    BenefitStatus = mapper.Map<BenefitStatusModel>(dictionaryService.Get<BenefitStatus>(x.BenefitStatusId)),
                    BenefitType = mapper.Map<BenefitTypeModel>(dictionaryService.Get<BenefitType>(x.BenefitTypeId)),
                    Id = x.Id,
                    RejectingDate = x.RejectingDate,
                    SubmittingDate = x.SubmittingDate,
                    RejectionReason = x.RejectionReason,
                    SubmittingUser = x.SubmittingUserId != null ? mapper.Map<UserModel>(userService.GetUserById(x.SubmittingUserId)) : new UserModel(),
                    AcceptingUser = x.AcceptingUserId != null ? mapper.Map<UserModel>(userService.GetUserById(x.AcceptingUserId)) : new UserModel(),
                    RejectingUser = x.RejectingUserId != null ? mapper.Map<UserModel>(userService.GetUserById(x.RejectingUserId)) : new UserModel(),
                });
            }
            else
            {
                benefitsList = new List<BenefitsViewModel>();
            }

            var model = new BenefitViewListModel()
            {
                BenefitsViewList = benefitsList
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddSocialServiceBenefit()
        {
            TempData["BenefitAddError"] = "Error";
            TempData["BenefitAddSuccess"] = "Success";
            relativesModel.Clear();
            var model = new AddSocialServiceBenefitModel()
            {
                BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 2),
                SocialServiceKindList = new SelectList(benefitService.GetSocialServiceKinds(), "Id", "Value"),
            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSocialServiceBenefit(AddSocialServiceBenefitModel model)
        {
            model.SocialServiceKindList = new SelectList(benefitService.GetSocialServiceKinds(), "Id", "Value");
            model.BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 2);

            if (!ModelState.IsValid)
                return View(model);

            model.Relatives = relativesModel;
            relativesModel.Clear();

            var newBenefit = new SocialServiceBenefit()
            {
                AdditionInformation = model.AdditionInformation,
                BeneficiaryAddress = model.BeneficiaryAddress,
                BeneficiaryName = model.BeneficiaryName,
                BeneficiaryPhoneNumber = model.BeneficiaryPhoneNumber,
                AvreageIncome = model.AverageIncome,
                BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.Passed),
                BenefitType = dictionaryService.Get<BenefitType>((int)eBenefitType.SocialServiceBenefit),
                DateOfEmployment = model.DateOfEmployment,
                OtherSocialServiceKind = model.OtherSocialServiceKind,
                Position = model.Position,
                SocialServiceKind = dictionaryService.Get<SocialServiceKind>(model.SocialServiceKind.Id),
                SubmittingDate = DateTime.Now,
                SubmittingUser = userManager.GetUserAsync(User).Result,
                BenefitNumber = benefitService.GenerateBenefitNumber((int)eBenefitType.SocialServiceBenefit),
                Year = model.Year
            };

            try
            {
                socialServiceBenefitService.CreateBenefit(newBenefit);

                if (model.Relatives.Any())
                {
                    var relatives = mapper.Map<List<RelativesModel>, List<Relatives>>(model.Relatives);
                    relatives.ForEach(x => x.SocialServiceBenefits = newBenefit);
                    socialServiceBenefitService.AddRelatives(relatives);
                }
                   
                TempData["BenefitAddSuccess"] = newBenefit.BenefitNumber.ToString();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["BenefitAddError"] = ex.Message;
                return View(model);
            }
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
                BenefitNumber = benefitService.GenerateBenefitNumber((int)eBenefitType.HomeLoanBenefit)
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

        [HttpGet]
        public IActionResult ShowClause()
        {
            return PartialView("BenefitsClauseInfo");
        }

        [HttpGet]
        public IActionResult AddRelatives(List<RelativesModel> model)
        {
            model.AddRange(relativesModel);
            return PartialView("Relatives", model);
        }

        public virtual JsonResult SaveRelatives(string relatives)
        {
            relativesModel.AddRange(JsonConvert.DeserializeObject<List<RelativesModel>>(relatives));
            return Json(relatives);
        }

        public virtual IActionResult VerifyBenefit(int id, int benefitTypeId)
        {
            try
            {
                if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                    homeLoanBenefitService.VerifyBenefit(id, (int)eBenefitStatus.InVeryfication);
                else
                    socialServiceBenefitService.ChangeBenefitStatus(id);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public virtual IActionResult AcceptBenefit(int id, int benefitTypeId)
        {
            try
            {
                if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                    homeLoanBenefitService.AcceptBenefit(id, userManager.GetUserAsync(User).Result.Id);
                else
                    socialServiceBenefitService.AcceptBenefit(id, userManager.GetUserAsync(User).Result.Id);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public virtual IActionResult OpenRejectionView()
        {
            return PartialView("Reject");
        }

        public virtual IActionResult RejectBenefit(int id, int benefitTypeId, string rejectionReason)
        {
            try
            {
                if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                    homeLoanBenefitService.RejectBenefit(id, userManager.GetUserAsync(User).Result.Id, rejectionReason);
                else
                    socialServiceBenefitService.RejectBenefit(id, userManager.GetUserAsync(User).Result.Id, rejectionReason);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
