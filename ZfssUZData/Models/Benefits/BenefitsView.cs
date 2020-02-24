using System;
using System.Collections.Generic;
using System.Text;

namespace ZfssUZ.Data.Models.Benefits
{
    public class BenefitsView
    {
        public int Id { get; set; }

        public string BeneficiaryName { get; set; }

        public string BeneficiaryAddress { get; set; }

        public string BeneficiaryPhoneNumber { get; set; }

        public int BenefitStatusId { get; set; }

        public DateTime SubmittingDate { get; set; }

        public int SubmittingUserId { get; set; }

        public DateTime? AcceptingDate { get; set; }

        public int AcceptingUserId { get; set; }

        public DateTime? RejectingDate { get; set; }

        public int RejectingUserId { get; set; }

        public string RejectionReason { get; set; }

        public int BenefitTypeId { get; set; }
    }
}
