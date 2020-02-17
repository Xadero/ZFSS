using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using ZfssUZ.Service.Enums;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;

namespace ZfssUZService
{
    public class HomeLoanBenefitService : IHomeLoanBenefitService
    {
        private ApplicationDbContext applicationDbContext;

        public HomeLoanBenefitService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void CreateBenefit(HomeLoanBenefit benefit)
        {
            applicationDbContext.HomeLoanBenefit.Add(benefit).State = EntityState.Added;
            applicationDbContext.SaveChanges();
        }
    }
}
