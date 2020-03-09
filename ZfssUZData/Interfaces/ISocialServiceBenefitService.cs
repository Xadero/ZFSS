using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Interfaces
{
    public interface ISocialServiceBenefitService
    {
        SocialServiceBenefit GetBenefit(int id);

        List<SocialServiceBenefit> GetOwnBenefits(ApplicationUser user);

        List<Relatives> GetRelatives(SocialServiceBenefit id);

        void CreateBenefit(SocialServiceBenefit benefit);

        void AddRelatives(List<Relatives> relatives, SocialServiceBenefit benefit);

        void ChangeBenefitStatus(int id);

        void AcceptBenefit(int id, string acceptingUserId);

        void RejectBenefit(int id, string rejectingUserId, string rejectionReason);

        void DeleteBenefit(int id);

        void UpdateBenefitData(SocialServiceBenefit benefit);

        void UpdateRelatives(List<Relatives> relatives, int benefitId);
    }
}
