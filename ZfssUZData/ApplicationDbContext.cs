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

        public DbSet<HomeLoanBenefit> HomeLoanBenefits { get; set; }

        public DbSet<SocialServiceBenefit> SocialServiceBenefits { get; set; }

        public DbSet<SocialServiceKind> SocialServiceKinds { get; set; }

        public DbSet<BenefitStatus> BenefitStatuses { get; set; }

        public DbSet<Relatives> Relatives { get; set; }
    }
}
