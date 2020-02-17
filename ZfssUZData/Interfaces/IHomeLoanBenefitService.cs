using System;
using System.Collections.Generic;
using System.Text;
using ZfssUZData.Models.Benefits;

namespace ZfssUZData.Interfaces
{
    public interface IHomeLoanBenefitService
    {
        void CreateBenefit(HomeLoanBenefit benefit);
    }
}
