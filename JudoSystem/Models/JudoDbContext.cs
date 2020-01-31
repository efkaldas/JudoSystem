using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class JudoDbContext : DbContext
    {
        public JudoDbContext(DbContextOptions<JudoDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<OrganizationType> OrganizationType { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Gender> Gender { get; set; }

    }
}
