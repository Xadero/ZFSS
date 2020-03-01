using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ZfssUZ.Service.Enums;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;

namespace ZfssUZService
{
    public class HomeLoanBenefitService : IHomeLoanBenefitService
    {
        private ApplicationDbContext applicationDbContext;
        private IDictionaryService dictionaryService;
        private IUserService userService;

        public HomeLoanBenefitService(ApplicationDbContext applicationDbContext, IDictionaryService dictionaryService, IUserService userService)
        {
            this.applicationDbContext = applicationDbContext;
            this.dictionaryService = dictionaryService;
            this.userService = userService;
        }

        public HomeLoanBenefit GetBenefit(int id)
        {
            return applicationDbContext.HomeLoanBenefit.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AcceptBenefit(int id, string acceptingUserId)
        {
            var benefitToAccept = applicationDbContext.HomeLoanBenefit.Where(x => x.Id == id).FirstOrDefault();
            if(benefitToAccept != null)
            {
                benefitToAccept.AcceptingDate = DateTime.Now;
                benefitToAccept.BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.Accepted);
                benefitToAccept.AcceptingUser = userService.GetUserById(acceptingUserId);
                applicationDbContext.SaveChanges();
            }
        }

        public void VerifyBenefit(int id, int benefitStatusId)
        {
            applicationDbContext.HomeLoanBenefit.Where(x => x.Id == id).FirstOrDefault().BenefitStatus = dictionaryService.Get<BenefitStatus>(benefitStatusId);
            applicationDbContext.SaveChanges();
        }

        public void CreateBenefit(HomeLoanBenefit benefit)
        {
            applicationDbContext.HomeLoanBenefit.Add(benefit).State = EntityState.Added;
            applicationDbContext.SaveChanges();
        }

        public void RejectBenefit(int id, string rejectingUserId, string rejectionReason)
        {
            var benefitToReject = applicationDbContext.HomeLoanBenefit.Where(x => x.Id == id).FirstOrDefault();
            if (benefitToReject != null)
            {
                benefitToReject.RejectingDate = DateTime.Now;
                benefitToReject.BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.Rejected);
                benefitToReject.RejectingUser = userService.GetUserById(rejectingUserId);
                benefitToReject.RejectionReason = rejectionReason;
                applicationDbContext.SaveChanges();
            }
        }
    }
}
