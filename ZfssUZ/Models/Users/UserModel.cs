using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Users
{
    public class UserModel
    {
        public string Id {get;set;}

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Postcode")]
        public string PostCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "UserGroup")]
        public string UserGroup { get; set; }

        [Display(Name = "IsLocked")]
        public bool IsLocked { get; set; }

        public decimal UserGroupId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
