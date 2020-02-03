using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Contexts.Seeds
{
    public static class OrganizationTypeSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationType>()
                .HasData(
                    new OrganizationType
                    {
                        Id = 1,
                        TypeNameEN = "Club",
                        TypeNameLT = "Klubas",
                        TypeNameRU = "Клуб"
                    },
                    new OrganizationType
                    {
                        Id = 2,
                        TypeNameEN = "Sports Center",
                        TypeNameLT = "Sporto Centras",
                        TypeNameRU = "Спортивный Центр"
                    },
                    new OrganizationType
                    {
                        Id = 3,
                        TypeNameEN = "Judges Association",
                        TypeNameLT = "Teisėjų Asociacija",
                        TypeNameRU = "Ассоциация Судей"
                    }
                );
        }
    }
}
