using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Seeds
{
    public static class CompetitionsTypeSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompetitionsType>()
                .HasData(
                    new CompetitionsType
                    {
                        Id = 1,
                        Title = "National",
                        Points = 20,
                    },
                    new CompetitionsType
                    {
                        Id = 2,
                        Title = "International",
                        Points = 30,
                    });
        }

    }
}

