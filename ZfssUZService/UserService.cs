using System;
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

        public void LockUser(string id)
        {
            applicationDbContext.Users.Where(x => x.Id == id).First().LockoutEnd = new DateTime(2099, 1, 1);
            applicationDbContext.SaveChanges();
        }

        public void UnlockUser(string id)
        {
            applicationDbContext.Users.Where(x => x.Id == id).First().LockoutEnd = null;
            applicationDbContext.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var userToDelete = applicationDbContext.Users.Where(x => x.Id == id).First();
            applicationDbContext.Users.Remove(userToDelete);
            applicationDbContext.SaveChanges();
        }
    }
}
