using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ZfssUZData.Models.Users;

namespace ZfssUZData.Models.Benefits
{
    public class Relatives
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public string RelativeFullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DegreeOfRelationship { get; set; }

        public string Notes { get; set; }

        [ForeignKey("SocialServiceBenefitId")]
        public SocialServiceBenefit SocialServiceBenefits { get; set; }

        [ForeignKey("USerId")]
        public ApplicationUser ApplicationUsers { get; set; }
    }
}
