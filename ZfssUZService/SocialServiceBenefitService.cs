using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZfssUZ.Service.Enums;
using ZfssUZData;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Benefits;

namespace ZfssUZService
{
    public class SocialServiceBenefitService : ISocialServiceBenefitService
    {
        private ApplicationDbContext applicationDbContext;
        private IDictionaryService dictionaryService;
        private IUserService userService;

        public SocialServiceBenefitService(ApplicationDbContext applicationDbContext, IDictionaryService dictionaryService, IUserService userService)
        {
            this.applicationDbContext = applicationDbContext;
            this.dictionaryService = dictionaryService;
            this.userService = userService;
        }

        public SocialServiceBenefit GetBenefit(int id)
        {
            var benefit = applicationDbContext.SocialServiceBenefit.Where(x => x.Id == id)
                .Include(x => x.SocialServiceKind)
                .Include(x => x.SubmittingUser)
                .Include(x => x.AcceptingUser)
                .FirstOrDefault();

            return benefit;
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

        public void ChangeBenefitStatus(int id)
        {
            applicationDbContext.SocialServiceBenefit.Where(x => x.Id == id).FirstOrDefault().BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.InVeryfication);
            applicationDbContext.SaveChanges();
        }

        public void AcceptBenefit(int id, string acceptingUserId)
        {
            var benefitToAccept = applicationDbContext.SocialServiceBenefit.Where(x => x.Id == id).FirstOrDefault();
            if (benefitToAccept != null)
            {
                benefitToAccept.AcceptingDate = DateTime.Now;
                benefitToAccept.BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.Accepted);
                benefitToAccept.AcceptingUser = userService.GetUserById(acceptingUserId);
                applicationDbContext.SaveChanges();
            }
        }

        public void RejectBenefit(int id, string rejectingUserId, string rejectionReason)
        {
            var benefitToReject = applicationDbContext.SocialServiceBenefit.Where(x => x.Id == id).FirstOrDefault();
            if (benefitToReject != null)
            {
                benefitToReject.RejectingDate = DateTime.Now;
                benefitToReject.BenefitStatus = dictionaryService.Get<BenefitStatus>((int)eBenefitStatus.Rejected);
                benefitToReject.RejectingUser = userService.GetUserById(rejectingUserId);
                benefitToReject.RejectionReason = rejectionReason;
                applicationDbContext.SaveChanges();
            }
        }

        public List<Relatives> GetRelatives(SocialServiceBenefit benefit)
        {
            return applicationDbContext.Relatives.Where(x => x.SocialServiceBenefits == benefit).ToList();
        }

        public void DeleteBenefit(int id)
        {
            var benefitToDelete = applicationDbContext.SocialServiceBenefit.Where(x => x.Id == id).First();
            var relativesToDelete = applicationDbContext.Relatives.Where(x => x.SocialServiceBenefits == benefitToDelete).ToList();
            applicationDbContext.Relatives.RemoveRange(relativesToDelete);
            applicationDbContext.SocialServiceBenefit.Remove(benefitToDelete);
            applicationDbContext.SaveChanges();
        }

        public void UpdateBenefitData(SocialServiceBenefit benefit)
        {
            var benefitToUpdate = GetBenefit(benefit.Id);
            benefitToUpdate.BeneficiaryAddress = benefit.BeneficiaryAddress;
            benefitToUpdate.BeneficiaryName = benefit.BeneficiaryName;
            benefitToUpdate.BeneficiaryPhoneNumber = benefit.BeneficiaryPhoneNumber;
            benefitToUpdate.DateOfEmployment = benefit.DateOfEmployment;
            benefitToUpdate.Position = benefit.Position;
            benefitToUpdate.OtherSocialServiceKind = benefit.OtherSocialServiceKind;
            benefitToUpdate.SocialServiceKind = dictionaryService.Get<SocialServiceKind>(benefit.SocialServiceKind.Id);
            benefitToUpdate.AverageIncome = benefit.AverageIncome;
            benefitToUpdate.AdditionInformation = benefit.AdditionInformation;
            benefitToUpdate.Year = benefit.Year;

            applicationDbContext.Entry(benefitToUpdate).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
        }

        public void UpdateRelatives(List<Relatives> relatives)
        {
            throw new NotImplementedException();
        }
    }
}
