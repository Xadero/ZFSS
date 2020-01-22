using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZfssUZData.Models.Submissions
{
    public class BenefitType
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
