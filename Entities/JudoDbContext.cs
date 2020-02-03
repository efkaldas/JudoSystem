using Entities.Models;
using Entities.Models.Seeds;
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
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public JudoDbContext(DbContextOptions<JudoDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();

            DanKyuSeed.Generate(builder);
            GenderSeed.Generate(builder);
            OrganizationTypeSeed.Generate(builder);
            UserRoleSeed.Generate(builder);
            UserStatusSeed.Generate(builder);
        }
    }
}
