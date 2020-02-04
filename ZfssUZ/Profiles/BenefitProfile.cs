using AutoMapper;
using ZfssUZ.Models.Benefit;
using ZfssUZ.Models.Benefit.SocialServiceBenefit;
using ZfssUZData.Models.Benefits;

namespace ZfssUZ.Profiles
{
    public class BenefitProfile : Profile
    {
        public BenefitProfile()
        {
            CreateMap<BenefitStatus, BenefitStatusModel>();
            CreateMap<BenefitType, BenefitTypeModel>();
            CreateMap<SocialServiceKind, SocialServiceKindModel>();
        }
    }
}
