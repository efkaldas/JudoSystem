using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Contexts.Seeds
{
    public static class UserStatusSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStatus>()
                .HasData(
                    new UserStatus
                    {
                        Id = 1,
                        StatusNameEN = "Approved",
                        StatusNameLT = "Patvirtintas",
                        StatusNameRU = "Одобренный"
                    },
                    new UserStatus
                    {
                        Id = 2,
                        StatusNameEN = "Not аpproved",
                        StatusNameLT = "Nepatvirtintas",
                        StatusNameRU = "Не одобренный"
                    },
                    new UserStatus
                    {
                        Id = 3,
                        StatusNameEN = "Blocked",
                        StatusNameLT = "Užblokuotas",
                        StatusNameRU = "Заблокирован"
                    }
                );
        }
    }
}
