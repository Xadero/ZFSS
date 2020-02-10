using System;
using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Benefit.SocialServiceBenefit
{
    public class RelativesModel
    {
        public int Id { get; set; }

        [Required]
        public string RelativeFullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string DegreeOfRelationship { get; set; }

        [Required]
        public string Notes { get; set; }

        public SocialServiceBenefitModel SocialServiceBenefits { get; set; }
    }
}
