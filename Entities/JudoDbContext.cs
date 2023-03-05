using Entities.Models;
using Entities.Models.Seeds;
using Entities.Seeds;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class JudoDbContext : DbContext
    {
        public DbSet<DanKyu> DanKyu { get; set; }
        public DbSet<Judoka> Judoka { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<WeightCategory> WeightCategory { get; set; }
        public DbSet<AgeGroup> AgeGroup { get; set; }
        public DbSet<Competitor> Competitor { get; set; }
        public DbSet<CompetitionsJudge> CompetitionsJudge { get; set; }
        public DbSet<CompetitionsResults> CompetitionsResults { get; set; }
        public DbSet<CompetitionsType> CompetitionsType { get; set; }

        public JudoDbContext(DbContextOptions<JudoDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();

            builder.Entity<User>()
                .Property(b => b.Status)
                .HasDefaultValue(UserStatus.NotApproved);

            builder.Entity<User>()
                .Property(b => b.Image)
                .HasDefaultValue("no_user_image.png");

            builder.Entity<Organization>()
                .Property(b => b.Image)
                .HasDefaultValue("no_organization_image.png");

            builder.Entity<UserRole>()
                .HasKey(bc => new { bc.UserId, bc.Type });
            
            builder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);

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
            CompetitionsTypeSeed.Generate(builder);
            UserSeed.Generate(builder);
            AdminUserRolesSeed.Generate(builder);
        }
    }
}
