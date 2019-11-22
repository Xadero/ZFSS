using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Interfaces
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAllUsers();

        UserGroup GetUserGroupById(decimal id);

        void LockUser(string id);

        void UnlockUser(string id);

        void DeleteUser(string id);

        ApplicationUser GetUserById(string id);
    }
}
