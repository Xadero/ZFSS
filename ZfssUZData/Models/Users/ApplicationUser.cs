﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using ZfssUZData.Models.Benefits;

namespace ZfssUZData.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        public string Address { get; set; }
        [ForeignKey("UserGroup")]
        public int UserGroupId { get; set; }
    }
}
