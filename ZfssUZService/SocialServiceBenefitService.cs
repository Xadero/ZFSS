using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;

namespace ZfssUZService
{
    public class SocialServiceBenefitService : ISocialServiceBenefitService
    {
        private ApplicationDbContext applicationDbContext;

        public SocialServiceBenefitService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void CreateBenefit(SocialServiceBenefit benefit)
        {
            applicationDbContext.SocialServiceBenefit.Add(benefit).State = EntityState.Added;
            applicationDbContext.SaveChanges();
        }

        public void AddRelatives(List<Relatives> relatives)
        {
            applicationDbContext.Relatives.AddRange(relatives);
            applicationDbContext.SaveChanges();
        }
    }
}
