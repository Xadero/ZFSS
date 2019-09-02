using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZfssUZ.Models.Users
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string UserGroup { get; set; }
    }
}
