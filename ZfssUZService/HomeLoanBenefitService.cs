using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
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
            applicationDbContext.HomeLoanBenefit.Add(benefit).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            applicationDbContext.SaveChanges();
        }

        public long GenerateBenefitNumber()
        {
            long maxNumber = 0;
            try
            {
                maxNumber = applicationDbContext.HomeLoanBenefit.MaxAsync(x => x.BenefitNumber).Result;
            }
            catch (Exception)
            {
                maxNumber = 0;
            }

            long benefitNumber = 0;
            if (maxNumber > 0)
            {
                if (DateTime.Today.Year > int.Parse(maxNumber.ToString().Substring(0, 4)))
                    applicationDbContext.Database.ExecuteSqlRaw("DROP SEQUENCE");

                var result = new SqlParameter("@result", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                applicationDbContext.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR SEQ_HomeLoanNumber)", result);
                benefitNumber = long.Parse(DateTime.Today.Year.ToString() + "01" + string.Format("{0:00000}", result.Value));
            }
            else
            {
                var result = new SqlParameter("@result", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                applicationDbContext.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR SEQ_HomeLoanNumber)", result);
                benefitNumber = long.Parse(DateTime.Today.Year.ToString() + "01" + string.Format("{0:00000}", result.Value));
            }

            return benefitNumber;
        }
    }
}
