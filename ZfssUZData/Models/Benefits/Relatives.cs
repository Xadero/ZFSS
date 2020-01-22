using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZfssUZData.Models.Benefits
{
    public class Relatives
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

        [ForeignKey("SocialServiceBenefitId")]
        public SocialServiceBenefit SocialServiceBenefits { get; set; }
    }
}
