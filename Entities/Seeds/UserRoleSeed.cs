using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models.Seeds
{
    public static class UserRoleSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = 1,
                        RoleNameEN = "Admin",
                        RoleNameLT = "Administratorius",
                        RoleNameRU = "Администратор"
                    },
                    new Role
                    {
                        Id = 2,
                        RoleNameEN = "Organization admin",
                        RoleNameLT = "Organizacijos administratorius",
                        RoleNameRU = "Администратор организации"
                    },
                    new Role
                    {
                        Id = 3,
                        RoleNameEN = "Coach",
                        RoleNameLT = "Treneris",
                        RoleNameRU = "Тренер"
                    },
                    new Role
                    {
                        Id = 4,
                        RoleNameEN = "Judge",
                        RoleNameLT = "Teisėjas",
                        RoleNameRU = "Судья"
                    }
                );
        }
    }
}
