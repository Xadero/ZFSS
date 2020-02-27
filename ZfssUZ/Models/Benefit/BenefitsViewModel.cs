using System;
using ZfssUZ.Models.Users;

namespace ZfssUZ.Models.Benefit
{
    public class BenefitsViewModel
    {
        public int Id { get; set; }

        public long BenefitNumber { get; set; }

        public DateTime SubmittingDate { get; set; }

        public UserModel SubmittingUser { get; set; }

        public BenefitTypeModel BenefitType { get; set; }

        public string BeneficiaryAddress { get; set; }

        public string BeneficiaryName { get; set; }

        public string BeneficiaryPhoneNumber { get; set; }

        public BenefitStatusModel BenefitStatus { get; set; }

        public DateTime? AcceptingDate { get; set; }

        public UserModel AcceptingUser { get; set; }

        public DateTime? RejectingDate { get; set; }

        public UserModel RejectingUser { get; set; }

        public string RejectionReason { get; set; }
    }
}
