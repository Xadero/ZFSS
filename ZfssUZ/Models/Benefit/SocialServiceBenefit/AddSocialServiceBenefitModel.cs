﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserInformation;

namespace ZfssUZ.Models.Benefit
{
    public class AddSocialServiceBenefitModel
    {
        public int Id { get; set; }

        [Required]
        public long BenefitNumber { get; set; }

        public BenefitStatusModel BenefitStatus { get; set; }

        public SocialServiceKindModel SocialServiceKind { get; set; }

        public string OtherSocialServiceKind { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public float AvreageIncome { get; set; }

        public string AdditionInformation { get; set; }

        [Required]
        public DateTime SubmittingDate { get; set; }

        public UserModel SubmittingUser { get; set; }

        public DateTime? AcceptingDate { get; set; }

        public UserModel AcceptingUser { get; set; }

        public DateTime? RejectingDate { get; set; }

        public UserModel RejectingUser { get; set; }

        public BenefitTypeModel BenefitType { get; set; }

        public IEnumerable<SelectListItem> SocialServiceKindList { get; set; }
       
        public IEnumerable<SelectListItem> BenefitTypeList { get; set; }
    }
}