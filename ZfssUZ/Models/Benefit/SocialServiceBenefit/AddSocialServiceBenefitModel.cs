using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Benefit.SocialServiceBenefit
{
    public class AddSocialServiceBenefitModel
    {
        [Display(Name = "BeneficiaryName")]
        [Required(ErrorMessage = "ValidateBeneficiaryName")]
        public string BeneficiaryName { get; set; }

        [Display(Name = "BeneficiaryAddress")]
        [Required(ErrorMessage = "ValidateBeneficiaryAddress")]
        public string BeneficiaryAddress { get; set; }

        [Display(Name = "BeneficiaryPhoneNumber")]
        [Required(ErrorMessage = "ValidateBeneficiaryPhoneNumber")]
        public string BeneficiaryPhoneNumber { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "ValidatePosition")]
        public string Position { get; set; }

        [Display(Name = "DateOfEmployment")]
        [Required(ErrorMessage = "ValidateDateOfEmployment")]
        public DateTime DateOfEmployment { get; set; }

        [Display(Name = "SocialServiceKind")]
        [Required(ErrorMessage = "ValidateOtherSocialServiceKind")]
        public SocialServiceKindModel SocialServiceKind { get; set; }

        public IEnumerable<SelectListItem> SocialServiceKindList { get; set; }

        [Display(Name = "OtherSocialServiceKind")]
        public string OtherSocialServiceKind { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "ValidateYear")]
        public int Year { get; set; }

        [Display(Name = "AverageIncome")]
        [Required(ErrorMessage = "ValidateAverageIncome")]
        public decimal AverageIncome { get; set; }

        [Display(Name = "AdditionInformation")]
        [Required(ErrorMessage = "ValidateAdditionInformation")]
        public string AdditionInformation { get; set; }

        [Display(Name = "BenefitType")]
        [Required(ErrorMessage = "ValidateBenefitType")]
        public BenefitTypeModel BenefitType { get; set; }

        public IEnumerable<SelectListItem> BenefitTypeList { get; set; }

        public List<RelativesModel> Realives { get; set; }
    }
}
