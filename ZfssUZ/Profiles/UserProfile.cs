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
        }
    }
}
