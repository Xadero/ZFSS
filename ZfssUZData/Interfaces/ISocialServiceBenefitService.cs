using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZData.Models.Benefits;

namespace ZfssUZData.Interfaces
{
    public interface ISocialServiceBenefitService
    {
        void CreateBenefit(SocialServiceBenefit benefit);

        void AddRelatives(List<Relatives> relatives);

        void ChangeBenefitStatus(int id);

        void AcceptBenefit(int id, string acceptingUserId);

        void RejectBenefit(int id, string rejectingUserId, string rejectionReason);
    }
}
