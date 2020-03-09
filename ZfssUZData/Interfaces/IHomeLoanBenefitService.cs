using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Interfaces
{
    public interface IHomeLoanBenefitService
    {
        HomeLoanBenefit GetBenefit(int id);

        List<HomeLoanBenefit> GetOwnBenefits(ApplicationUser user);
        void CreateBenefit(HomeLoanBenefit benefit);

        void VerifyBenefit(int id, int benefitStatusId);

        void AcceptBenefit(int id, string acceptingUserId);

        void RejectBenefit(int id, string rejectingUserId, string rejectionReason);

        void DeleteBenefit(int id);

        void UpdateBenefitData(HomeLoanBenefit benefit);
    }
}
