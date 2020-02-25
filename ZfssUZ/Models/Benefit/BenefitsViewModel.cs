using System;

namespace ZfssUZ.Models.Benefit
{
    public class BenefitsViewModel
    {
        public int Id { get; set; }

        public long BenefitNumber { get; set; }

        public DateTime SubmittingDate { get; set; }

        public string SubmittingUserId { get; set; }

        public int BenefitTypeId { get; set; }

        public string BeneficiaryAddress { get; set; }

        public string BeneficiaryName { get; set; }

        public string BeneficiaryPhoneNumber { get; set; }

        public int BenefitStatusId { get; set; }

        public DateTime? AcceptingDate { get; set; }

        public string AcceptingUserId { get; set; }

        public DateTime? RejectingDate { get; set; }

        public string RejectingUserId { get; set; }

        public string RejectionReason { get; set; }
    }
}
