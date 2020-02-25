using AutoMapper;
using ZfssUZ.Data.Models.Benefits;
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
            CreateMap<Relatives, RelativesModel>();
            CreateMap<RelativesModel, Relatives>();
            CreateMap<SocialServiceBenefit, SocialServiceBenefitModel>();
            CreateMap<BenefitsViewModel, BenefitsView>();
            CreateMap<BenefitsView, BenefitsViewModel>();
        }
    }
}
