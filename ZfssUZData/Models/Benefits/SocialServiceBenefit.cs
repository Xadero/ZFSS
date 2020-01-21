using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ZfssUZData.Models.Submissions;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Models.Benefits
{
    public class SocialServiceBenefit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long BenefitNumber { get; set; }

        [ForeignKey("BenefitStatusId")]
        public BenefitStatus BenefitStatus { get; set; }

        public DateTime SubmittingDate { get; set; }

        [ForeignKey("SubmittingUserId")]
        public ApplicationUser SubmittingUser { get; set; }

        public DateTime? AcceptingDate { get; set; }

        [ForeignKey("AcceptingUserId")]
        public ApplicationUser AcceptingUser { get; set; }

        public DateTime? RejectingDate { get; set; }

        [ForeignKey("RejectingUserId")]
        public ApplicationUser RejectingUser { get; set; }

        [ForeignKey("BenefitTypeId")]
        public BenefitType BenefitType { get; set; }

    }
}
