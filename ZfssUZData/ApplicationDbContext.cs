using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZfssUZ.Data.Models.Benefits;
using ZfssUZData.Models.Benefits;
using ZfssUZData.Models.Users;

namespace ZfssUZData
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public new DbSet<ApplicationUser> Users { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }

        public DbSet<BenefitType> BenefitType { get; set; }

        public DbSet<HomeLoanBenefit> HomeLoanBenefit { get; set; }

        public DbSet<SocialServiceBenefit> SocialServiceBenefit { get; set; }

        public DbSet<SocialServiceKind> SocialServiceKind { get; set; }

        public DbSet<BenefitStatus> BenefitStatus { get; set; }

        public DbSet<Relatives> Relatives { get; set; }

        public DbSet<BenefitsView> BenefitsView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasSequence("SEQ_SocialServiceNumber").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence("SEQ_HomeLoanNumber").StartsAt(1).IncrementsBy(1);
            modelBuilder.Entity<BenefitsView>().ToView("BenefitsView").HasNoKey();
        }
    }
}
