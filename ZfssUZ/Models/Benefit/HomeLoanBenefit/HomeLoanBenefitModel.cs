﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZfssUZ.Models.Users;

namespace ZfssUZ.Models.Benefit.HomeLoanBenefit
{
    public class HomeLoanBenefitModel
    {
        public int Id { get; set; }

        public long BenefitNumber { get; set; }

        [Display(Name = "BeneficiaryName")]
        [Required(ErrorMessage = "ValidateBeneficiaryName")]
        public string BeneficiaryName { get; set; }

        [Display(Name = "BeneficiaryAddress")]
        [Required(ErrorMessage = "ValidateBeneficiaryAddress")]
        public string BeneficiaryAddress { get; set; }

        [Display(Name = "BeneficiaryPhoneNumber")]
        [Required(ErrorMessage = "ValidateBeneficiaryPhoneNumber")]
        public string BeneficiaryPhoneNumber { get; set; }

        [Display(Name = "LoanCost")]
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "ValidateLoanCost")]
        public long LoanCost { get; set; }

        [Display(Name = "Instalment")]
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "ValidateInstalment")]
        public string Instalment { get; set; }

        [Display(Name = "Months")]
        [Required(ErrorMessage = "ValidateMonhts")]
        public int Months { get; set; }

        [Display(Name = "LoanPurpose")]
        [Required(ErrorMessage = "ValidateLoanPurpose")]
        public string LoanPurpose { get; set; }

        public BenefitStatusModel BenefitStatus { get; set; }

        [Required]
        public DateTime SubmittingDate { get; set; }

        public UserModel SubmittingUser { get; set; }

        public DateTime? AcceptingDate { get; set; }

        public UserModel AcceptingUser { get; set; }

        public DateTime? RejectingDate { get; set; }

        public UserModel RejectingUser { get; set; }

        public string RejectionReason { get; set; }

        [Display(Name = "BenefitType")]
        public BenefitTypeModel BenefitType { get; set; }

        public IEnumerable<SelectListItem> BenefitTypeList { get; set; }
    }
}
