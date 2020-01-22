using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZfssUZData.Models.Benefits
{
    public class BenefitStatus
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
