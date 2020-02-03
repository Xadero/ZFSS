using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;

namespace ZfssUZService
{
    public class BenefitService : IBenefitService
    {
        private ApplicationDbContext applicationDbContext;

        public BenefitService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<BenefitType> GetBenefitsTypes()
        {
            return applicationDbContext.BenefitType;
        }

        public IEnumerable<SocialServiceKind> GetSocialServiceKinds()
        {
            return applicationDbContext.SocialServiceKind;
        }
    }
}
