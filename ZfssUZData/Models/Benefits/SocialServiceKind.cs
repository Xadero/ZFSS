﻿using System.ComponentModel.DataAnnotations;

namespace ZfssUZData.Models.Benefits
{
    public class SocialServiceKind
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
