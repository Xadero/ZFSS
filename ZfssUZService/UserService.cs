using System.Collections.Generic;
using System.Linq;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Users;

namespace ZfssUZService
{
    public class UserService : IUserService
    {
        private ApplicationDbContext applicationDbContext;
        
        public UserService(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return applicationDbContext.Users;
        }

        public UserGroup GetUserGroupById(decimal id)
        {
            return applicationDbContext.UserGroups.Where(x => x.Id == id).First();
        }
    }
}
