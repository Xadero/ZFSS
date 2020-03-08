using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static int benefitId;
        private static string benefitNumber = string.Empty;
        public BenefitController(IBenefitService benefitService, IUserService userService, IDictionaryService dictionaryService, IHomeLoanBenefitService homeLoanBenefitService, ISocialServiceBenefitService socialServiceBenefitService, IMapper mapper, UserManager<ApplicationUser> userManager)
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

            var newBenefit = new SocialServiceBenefit()
            {
                AdditionInformation = model.AdditionInformation,
                BeneficiaryAddress = model.BeneficiaryAddress,
                BeneficiaryName = model.BeneficiaryName,
                BeneficiaryPhoneNumber = model.BeneficiaryPhoneNumber,
                AverageIncome = model.AverageIncome,
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
                relativesModel.Clear();
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
                Instalment = decimal.Parse(model.Instalment.Replace(".", ",")),
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
            catch (Exception ex)
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
            relativesModel.Clear();
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

        public virtual IActionResult Show(int id, int benefitTypeId)
        {
            try
            {
                if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                {
                    var benefit = homeLoanBenefitService.GetBenefit(id);
                    var model = new HomeLoanBenefitModel()
                    {
                        BeneficiaryName = benefit.BeneficiaryName,
                        BeneficiaryAddress = benefit.BeneficiaryAddress,
                        BeneficiaryPhoneNumber = benefit.BeneficiaryPhoneNumber,
                        LoanCost = benefit.LoanCost,
                        LoanPurpose = benefit.LoanPurpose,
                        Months = benefit.Months,
                        Instalment = benefit.Instalment,
                        SubmittingUser = benefit.SubmittingUser != null ? new UserModel { Firstname = benefit.SubmittingUser.FirstName, LastName = benefit.SubmittingUser.LastName } : new UserModel()
                    };
                    return PartialView("ShowHomeLoanBenefit", model);

                }
                else
                {
                    var benefit = socialServiceBenefitService.GetBenefit(id);
                    var relatives = socialServiceBenefitService.GetRelatives(benefit);
                    var model = new SocialServiceBenefitModel()
                    {
                        AcceptingDate = benefit.AcceptingDate,
                        AcceptingUser = benefit.AcceptingUser != null ? new UserModel { Firstname = benefit.SubmittingUser.FirstName, LastName = benefit.SubmittingUser.LastName } : new UserModel(),
                        AdditionInformation = benefit.AdditionInformation,
                        AverageIncome = benefit.AverageIncome,
                        SocialServiceKind = mapper.Map<SocialServiceKindModel>(benefit.SocialServiceKind),
                        OtherSocialServiceKind = benefit.OtherSocialServiceKind,
                        SubmittingUser = new UserModel { Firstname = benefit.SubmittingUser.FirstName, LastName = benefit.SubmittingUser.LastName },
                        SubmittingDate = benefit.SubmittingDate,
                        Year = benefit.Year,
                        BeneficiaryAddress = benefit.BeneficiaryAddress,
                        BeneficiaryName = benefit.BeneficiaryName,
                        BeneficiaryPhoneNumber = benefit.BeneficiaryPhoneNumber,
                        Relatives = mapper.Map<List<Relatives>, List<RelativesModel>>(socialServiceBenefitService.GetRelatives(benefit)),
                        Position = benefit.Position,
                        DateOfEmployment = benefit.DateOfEmployment
                    };
                    return PartialView("ShowSocialServiceBenefit", model);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public virtual IActionResult Delete(int id, int benefitTypeId)
        {
            try
            {
                if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                {
                    homeLoanBenefitService.DeleteBenefit(id);
                    return Json(new { success = true });
                }
                else
                {
                    socialServiceBenefitService.DeleteBenefit(id);
                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public virtual IActionResult Edit(int id, int benefitTypeId)
        {
            TempData["Edit"] = "None";
            benefitId = id;
            try
            {
                if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                {
                    var benefit = homeLoanBenefitService.GetBenefit(id);
                    var model = new HomeLoanBenefitModel()
                    {
                        BeneficiaryName = benefit.BeneficiaryName,
                        BeneficiaryAddress = benefit.BeneficiaryAddress,
                        BeneficiaryPhoneNumber = benefit.BeneficiaryPhoneNumber,
                        BenefitNumber = benefit.BenefitNumber,
                        Id = benefit.Id,
                        Instalment = benefit.Instalment,
                        LoanPurpose = benefit.LoanPurpose,
                        Months = benefit.Months,
                        BenefitType = mapper.Map<BenefitTypeModel>(benefit.BenefitType),
                        LoanCost = benefit.LoanCost,
                        BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 1),

                    };
                    benefitNumber = benefit.BenefitNumber.ToString();
                    return View("EditHomeLoanBenefit", model);
                }
                else
                {
                    var benefit = socialServiceBenefitService.GetBenefit(id);
                    var model = new SocialServiceBenefitModel()
                    {
                        BeneficiaryName = benefit.BeneficiaryName,
                        BenefitNumber = benefit.BenefitNumber,
                        BeneficiaryAddress = benefit.BeneficiaryPhoneNumber,
                        OtherSocialServiceKind = benefit.OtherSocialServiceKind,
                        DateOfEmployment = benefit.DateOfEmployment,
                        AdditionInformation = benefit.AdditionInformation,
                        Position = benefit.Position,
                        Id = benefit.Id,
                        SocialServiceKind = mapper.Map<SocialServiceKindModel>(benefit.SocialServiceKind),
                        SocialServiceKindList = new SelectList(benefitService.GetSocialServiceKinds(), "Id", "Value"),
                        Year = benefit.Year,
                        BenefitType = mapper.Map<BenefitTypeModel>(benefit.BenefitType),
                        BeneficiaryPhoneNumber = benefit.BeneficiaryPhoneNumber,
                        AverageIncome = benefit.AverageIncome,
                        BenefitTypeList = new SelectList(benefitService.GetBenefitsTypes(), "Id", "Value", 2),
                    };

                    model.Relatives = mapper.Map<List<Relatives>, List<RelativesModel>>(socialServiceBenefitService.GetRelatives(benefit));

                    if (model.Relatives.Any())
                    {
                        relativesModel.Clear();
                        relativesModel.AddRange(model.Relatives);
                    }

                    benefitNumber = benefit.BenefitNumber.ToString();
                    return View("EditSocialServiceBenefit", model);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public virtual IActionResult EditHomeLoanBenefit(HomeLoanBenefit model)
        {
            var benefit = new HomeLoanBenefit
            {
                Id = benefitId,
                BeneficiaryAddress = model.BeneficiaryAddress,
                BeneficiaryName = model.BeneficiaryName,
                BeneficiaryPhoneNumber = model.BeneficiaryPhoneNumber,
                LoanCost = model.LoanCost,
                LoanPurpose = model.LoanPurpose,
                Months = model.Months,
                Instalment = model.Instalment,
                BenefitNumber = model.BenefitNumber,
            };

            try
            {
                homeLoanBenefitService.UpdateBenefitData(benefit);
                TempData["Edit"] = benefitNumber;
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Edit"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public virtual IActionResult EditSocialServiceBenefit(SocialServiceBenefitModel model)
        {
            var benefit = new SocialServiceBenefit
            {
                Id = benefitId,
                BeneficiaryAddress = model.BeneficiaryAddress,
                BeneficiaryName = model.BeneficiaryName,
                BeneficiaryPhoneNumber = model.BeneficiaryPhoneNumber,
                DateOfEmployment = model.DateOfEmployment,
                Position = model.Position,
                OtherSocialServiceKind = model.OtherSocialServiceKind,
                SocialServiceKind = dictionaryService.Get<SocialServiceKind>(model.SocialServiceKind.Id),
                AverageIncome = model.AverageIncome,
                AdditionInformation = model.AdditionInformation,
                Year = model.Year,
            };

            try
            {
                socialServiceBenefitService.UpdateBenefitData(benefit);
                var relatives = mapper.Map<List<RelativesModel>, List<Relatives>>(relativesModel);
                if (relatives.Any())
                {
                    socialServiceBenefitService.UpdateRelatives(relatives, benefit);
                    relativesModel.Clear();
                }

                TempData["Edit"] = benefitNumber;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Edit"] = ex.Message;
                return View(model);
            }
        }
    }
}
