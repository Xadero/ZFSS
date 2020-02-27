using AutoMapper;
using ZfssUZ.Models.Users;
using ZfssUZData.Models.Users;

namespace ZfssUZ
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserGroup, UserGroupModel>();
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
