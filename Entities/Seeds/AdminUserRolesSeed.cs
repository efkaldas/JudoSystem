using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Seeds
{
    public static class AdminUserRolesSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                    }
                    );
        }
    }
}
