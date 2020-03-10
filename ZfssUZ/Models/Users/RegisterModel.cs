using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Users
{
    public class RegisterModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "ValidateUsername")]
        public string Username { get; set; }

        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "ValidateFirstname")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "ValidateLastname")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "ValidatePhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "ValidatePassword")]
        [StringLength(100, ErrorMessage = "ValidatePasswordLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "ValidateConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "DateOfBirth")]
        [Required(ErrorMessage = "ValidateDateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "ValidateEmail")]
        public string EmailAddress { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "ValidateAddress")]
        public string Address { get; set; }

        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "ValidatePostCode")]
        public string PostCode { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "ValidateCity")]
        public string City { get; set; }

        [Display(Name = "UserGroup")]
        public UserGroupModel UserGroup { get; set; }

        public IEnumerable<SelectListItem> UserGroupList { get; set; }
    }
}
