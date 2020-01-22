using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZfssUZData.Models.Submissions;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Models.Benefits
{
    public class HomeLoanBenefit
    {
        public int Id { get; set; }

        [Required]
        public long BenefitNumber { get; set; }

        [Required]
        public long LoanCost { get; set; }

        [Required]
        public int Instalment { get; set; }

        [Required]
        public int Months { get; set; }

        [Required]
        public string LoanPurpose { get; set; }

        [ForeignKey("BenefitStatusId")]        
        public BenefitStatus BenefitStatus { get; set; }

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

        public string RejectionReason { get; set; }

        [ForeignKey("BenefitTypeId")]
        public BenefitType BenefitType { get; set; }





    }
}
