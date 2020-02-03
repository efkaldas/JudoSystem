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
            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole
                    {
                        Id = 1,
                        RoleNameEN = "Admin",
                        RoleNameLT = "Administratorius",
                        RoleNameRU = "Администратор"
                    },
                    new UserRole
                    {
                        Id = 2,
                        RoleNameEN = "Moderator",
                        RoleNameLT = "Moderatorius",
                        RoleNameRU = "Модератор"
                    },
                    new UserRole
                    {
                        Id = 3,
                        RoleNameEN = "Coach",
                        RoleNameLT = "Treneris",
                        RoleNameRU = "Тренер"
                    },
                    new UserRole
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
