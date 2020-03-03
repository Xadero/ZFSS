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
        public string BeneficiaryName { get; set; }

        public string BeneficiaryAddress { get; set; }

        public string BeneficiaryPhoneNumber { get; set; }

        [Required]
        public long LoanCost { get; set; }

        [Required]
        public decimal Instalment { get; set; }

        [Required]
        public int Months { get; set; }

        [Required]
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

        public BenefitTypeModel BenefitType { get; set; }

        public IEnumerable<SelectListItem> BenefitTypeList { get; set; }
    }
}
