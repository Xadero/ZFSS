using System;
using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Benefit.SocialServiceBenefit
{
    public class RelativesModel
    {
        [Required]
        public string RelativeFullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string DegreeOfRelationship { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
