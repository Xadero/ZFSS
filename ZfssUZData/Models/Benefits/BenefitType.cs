using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ZfssUZData.Models.Benefits;

namespace ZfssUZData.Models.Submissions
{
    public class BenefitType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Value { get; set; }
    }
}
