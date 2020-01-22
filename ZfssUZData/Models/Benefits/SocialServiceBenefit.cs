using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZfssUZData.Models.Submissions;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Models.Benefits
{
    public class SocialServiceBenefit
    {
        public int Id { get; set; }

        [Required]
        public long BenefitNumber { get; set; }

        [ForeignKey("BenefitStatusId")]
        public BenefitStatus BenefitStatus { get; set; }

        [ForeignKey("SocialServiceKindId")]
        public SocialServiceKind SocialServiceKind { get; set; }

        public string OtherSocialServiceKind { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public float AvreageIncome { get; set; }

        public string AdditionInformation { get; set; }

        [Required]
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
