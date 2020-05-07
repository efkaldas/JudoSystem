using Entities.Models;
using Entities.Models.Seeds;
using Entities.Seeds;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class JudoDbContext : DbContext
    {
        public DbSet<DanKyu> DanKyu { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Judoka> Judoka { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationType> OrganizationType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<WeightCategory> WeightCategory { get; set; }
        public DbSet<AgeGroup> AgeGroup { get; set; }
        public DbSet<Competitor> Competitor { get; set; }
        public DbSet<CompetitionsJudge> CompetitionsJudge { get; set; }
        public DbSet<CompetitionsResults> CompetitionsResults { get; set; }
        public DbSet<CompetitionsType> CompetitionsType { get; set; }
        public DbSet<JudokaRank> JudokaRank { get; set; }

        public JudoDbContext(DbContextOptions<JudoDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();

            builder.Entity<User>()
                .Property(b => b.StatusId)
                .HasDefaultValue(2);

            builder.Entity<UserRole>()
                .HasKey(bc => new { bc.UserId, bc.RoleId });
            
            builder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);
           
            builder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.RoleId);

            builder.Entity<Competitor>()
                .HasKey(bc => new { bc.WeightCategoryId, bc.JudokaId });

            builder.Entity<Competitor>()
                .HasOne(bc => bc.WeightCategory)
                .WithMany(b => b.Competitors)
                .HasForeignKey(bc => bc.WeightCategoryId);

            builder.Entity<Competitor>()
                .HasOne(bc => bc.Judoka)
                .WithMany(b => b.WeightCategories)
                .HasForeignKey(bc => bc.JudokaId);


            DanKyuSeed.Generate(builder);
            GenderSeed.Generate(builder);
            OrganizationTypeSeed.Generate(builder);
            UserRoleSeed.Generate(builder);
            UserStatusSeed.Generate(builder);
            CompetitionsTypeSeed.Generate(builder);
            UserSeed.Generate(builder);
            AdminUserRolesSeed.Generate(builder);
        }
    }
}
