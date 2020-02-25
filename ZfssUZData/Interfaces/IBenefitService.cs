using System.Collections.Generic;
using ZfssUZ.Data.Models.Benefits;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Interfaces
{
    public interface IBenefitService
    {
        IEnumerable<BenefitType> GetBenefitsTypes();

        IEnumerable<SocialServiceKind> GetSocialServiceKinds();

        long GenerateBenefitNumber(int benefitType);

        IEnumerable<BenefitsView> GetBenefits(ApplicationUser user);
    }
}
