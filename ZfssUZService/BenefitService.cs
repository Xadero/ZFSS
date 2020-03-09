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

        private ISocialServiceBenefitService socialServiceBenefitService;
        private IHomeLoanBenefitService homeLoanBenefitService;

        public BenefitService(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, ISocialServiceBenefitService socialServiceBenefitService, IHomeLoanBenefitService homeLoanBenefitService)
        {
            this.applicationDbContext = applicationDbContext;
            this.socialServiceBenefitService = socialServiceBenefitService;
            this.homeLoanBenefitService = homeLoanBenefitService;
        }

        public IEnumerable<BenefitType> GetBenefitsTypes()
        {
            return applicationDbContext.BenefitType;
        }

        public IEnumerable<BenefitsView> GetBenefits(ApplicationUser user)
        {
            if (user.UserGroupId != (int)eUserGroup.UzEmpoloyee)
            {
                return applicationDbContext.BenefitsView.ToList();
            }
            else
            {
                return applicationDbContext.BenefitsView.Where(x => x.SubmittingUserId == user.Id).ToList();
            }
        }

        public IEnumerable<SocialServiceKind> GetSocialServiceKinds()
        {
            return applicationDbContext.SocialServiceKind;
        }

        public long GetBenefitNumber(int benefitId, int benefitTypeId)
        {
            if (benefitTypeId == (int)eBenefitType.HomeLoanBenefit)
                return applicationDbContext.HomeLoanBenefit.Where(x => x.Id == benefitId).First().BenefitNumber;
            else
                return applicationDbContext.SocialServiceBenefit.Where(x => x.Id == benefitId).First().BenefitNumber;

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

        public void DeleteUserBenefits(string userId)
        {
            var user = applicationDbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (user != null)
            {
                var homeLoanBenfits = homeLoanBenefitService.GetOwnBenefits(user);

                if (homeLoanBenfits.Any())
                {
                    foreach (var benefit in homeLoanBenfits)
                    {
                        homeLoanBenefitService.DeleteBenefit(benefit.Id);
                    }
                }

                var socialServiceBenefits = socialServiceBenefitService.GetOwnBenefits(user);

                if (socialServiceBenefits.Any())
                {
                    foreach (var benefit in socialServiceBenefits)
                    {
                        socialServiceBenefitService.DeleteBenefit(benefit.Id);
                    }
                }
            }
        }
    }
}
