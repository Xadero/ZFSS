using System.Collections.Generic;
using ZfssUZData.Models.Benefits;

namespace ZfssUZData.Interfaces
{
    public interface IBenefitService
    {
        IEnumerable<BenefitType> GetBenefitsTypes();

        IEnumerable<SocialServiceKind> GetSocialServiceKinds();
    }
}
