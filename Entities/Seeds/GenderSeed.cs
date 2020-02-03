using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models.Seeds
{
    public static class GenderSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasData(
                    new Gender
                    {
                        Id = 1,
                        TextEN = "Male",
                        TextLT = "Vyras",
                        TextRU = "Mужчина"
                    },
                    new Gender
                    {
                        Id = 2,
                        TextEN = "Female",
                        TextLT = "Moteris",
                        TextRU = "Женщина"
                    }
                );
        }
    }
}
