using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZfssUZ.Models.Benefit.SocialServiceBenefit;
using ZfssUZ.Models.Users;

namespace ZfssUZ.Models.Benefit.SocialServiceBenefit
{
    public class SocialServiceBenefitModel
    {
        public int Id { get; set; }

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

        [Required]
        public long BenefitNumber { get; set; }

        public BenefitStatusModel BenefitStatus { get; set; }

        [Display(Name = "SocialServiceKind")]
        public SocialServiceKindModel SocialServiceKind { get; set; }

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

        [Required]
        public DateTime SubmittingDate { get; set; }

        public UserModel SubmittingUser { get; set; }

        public DateTime? AcceptingDate { get; set; }

        public UserModel AcceptingUser { get; set; }

        public DateTime? RejectingDate { get; set; }

        public UserModel RejectingUser { get; set; }

        [Display(Name = "BenefitType")]
        public BenefitTypeModel BenefitType { get; set; }

        public IEnumerable<SelectListItem> BenefitTypeList { get; set; }

        public IEnumerable<SelectListItem> SocialServiceKindList { get; set; }

        [Display(Name = "Relatives")]
        public List<RelativesModel> Relatives { get; set; }
    }
}
