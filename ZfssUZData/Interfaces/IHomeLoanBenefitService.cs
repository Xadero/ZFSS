using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZData.Models.Benefits;

namespace ZfssUZData.Interfaces
{
    public interface IHomeLoanBenefitService
    {
        void CreateBenefit(HomeLoanBenefit benefit);

        void VerifyBenefit(int id, int benefitStatusId);

        void AcceptBenefit(int id, string acceptingUserId);

        void RejectBenefit(int id, string rejectingUserId, string rejectionReason);
    }
}
