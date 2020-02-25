using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZfssUZ.Data.Models.Benefits;
using ZfssUZ.Service.Enums;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZService
{
    public class BenefitService : IBenefitService
    {
        private ApplicationDbContext applicationDbContext;

        public BenefitService(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<BenefitType> GetBenefitsTypes()
        {
            return applicationDbContext.BenefitType;
        }

        public IEnumerable<BenefitsView> GetBenefits(ApplicationUser user)
        {
            if (user.UserGroupId == (int)eUserGroup.Administration)
            {
                return applicationDbContext.BenefitsView.ToList();
            }
            else
            {
                return applicationDbContext.BenefitsView.Where(x => x.SubmittingUserId.ToString() == user.Id).ToList();
            }
        }

        public IEnumerable<SocialServiceKind> GetSocialServiceKinds()
        {
            return applicationDbContext.SocialServiceKind;
        }

        public long GenerateBenefitNumber(int benefitType)
        {
            long maxNumber = 0;
            try
            {
                if (benefitType == (int)eBenefitType.HomeLoanBenefit)
                    maxNumber = applicationDbContext.HomeLoanBenefit.MaxAsync(x => x.BenefitNumber).Result;
                else
                    maxNumber = applicationDbContext.SocialServiceBenefit.MaxAsync(x => x.BenefitNumber).Result;
            }
            catch (Exception)
            {
                maxNumber = 0;
            }

            long benefitNumber = 0;
            if (maxNumber > 0)
            {
                if (DateTime.Today.Year > int.Parse(maxNumber.ToString().Substring(0, 4)))
                {
                    if (benefitType == (int)eBenefitType.HomeLoanBenefit)
                    {
                        applicationDbContext.Database.ExecuteSqlRaw("DROP SEQUENCE SEQ_HomeLoanNumber");
                        applicationDbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE SEQ_HomeLoanNumber START WITH 1 INCREMENT BY 1 ");
                    }
                    else
                    {
                        applicationDbContext.Database.ExecuteSqlRaw("DROP SEQUENCE SEQ_SocialServiceNumber");
                        applicationDbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE SEQ_SocialServiceNumber START WITH 1 INCREMENT BY 1 ");
                    }
                }
                    

                var result = new SqlParameter("@result", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                if (benefitType == (int)eBenefitType.HomeLoanBenefit)
                {
                    applicationDbContext.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR SEQ_HomeLoanNumber)", result);
                    benefitNumber = long.Parse(DateTime.Today.Year.ToString() + string.Format("{0:00}", benefitType) + string.Format("{0:00000}", result.Value));
                }
                else
                {
                    applicationDbContext.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR SEQ_SocialServiceNumber)", result);
                    benefitNumber = long.Parse(DateTime.Today.Year.ToString() + string.Format("{0:00}", benefitType) + string.Format("{0:00000}", result.Value));
                }
            }
            else
            {
                var result = new SqlParameter("@result", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                if (benefitType == (int)eBenefitType.HomeLoanBenefit)
                {
                    applicationDbContext.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR SEQ_HomeLoanNumber)", result);
                    benefitNumber = long.Parse(DateTime.Today.Year.ToString() + string.Format("{0:00}", benefitType) + string.Format("{0:00000}", result.Value));
                }
                else
                {
                    applicationDbContext.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR SEQ_SocialServiceNumber)", result);
                    benefitNumber = long.Parse(DateTime.Today.Year.ToString() + string.Format("{0:00}", benefitType) + string.Format("{0:00000}", result.Value));
                }
            }

            return benefitNumber;
        }
    }
}
