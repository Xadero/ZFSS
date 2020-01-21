using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Submissions;
using ZfssUZData.Models.Users;

namespace ZfssUZData
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        public new DbSet<ApplicationUser> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<BenefitType> BenefitType { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //builder.Entity<HomeLoanBenefit>().HasKey(x => x.UserId);
        //    //builder.Entity<HomeLoanBenefit>().HasKey(x => x.RejectingUserId);
        //    //builder.Entity<HomeLoanBenefit>().HasKey(x => x.AcceptingUserId);
        //    //builder.Entity<HomeLoanBenefit>().HasOne(x => x.User).WithMany(x => x.HomeLoanBenefits);

        //    builder.

        //    builder.Entity<HomeLoanBenefit>().HasOne(x => x.User).WithMany().HasForeignKey(nameof(HomeLoanBenefit.UserId)).IsRequired();
        //    builder.Entity<HomeLoanBenefit>().HasOne(x => x.AcceptingUser).WithMany().HasForeignKey(nameof(HomeLoanBenefit.AcceptingUserId)).IsRequired(false);
        //    builder.Entity<HomeLoanBenefit>().HasOne(x => x.RejectingUser).WithMany().HasForeignKey(nameof(HomeLoanBenefit.RejectingUserId)).IsRequired(false);

        //    builder.Entity<SocialServiceBenefit>().HasOne(x => x.User).WithMany().HasForeignKey(nameof(SocialServiceBenefit.UserId)).IsRequired();
        //    builder.Entity<SocialServiceBenefit>().HasOne(x => x.AcceptingUser).WithMany().HasForeignKey(nameof(SocialServiceBenefit.AcceptingUserId)).IsRequired(false);
        //    builder.Entity<SocialServiceBenefit>().HasOne(x => x.RejectingUser).WithMany().HasForeignKey(nameof(SocialServiceBenefit.RejectingUserId)).IsRequired(false);
        //}
    }
}
