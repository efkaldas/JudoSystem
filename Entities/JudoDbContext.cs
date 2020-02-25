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
        public DbSet<Role> Role { get; set; }
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

            builder.Entity<User>()
                .Property(b => b.StatuId)
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
        

                    DanKyuSeed.Generate(builder);
            GenderSeed.Generate(builder);
            OrganizationTypeSeed.Generate(builder);
            UserRoleSeed.Generate(builder);
            UserStatusSeed.Generate(builder);
        }
    }
}
