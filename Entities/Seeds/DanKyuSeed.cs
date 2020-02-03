using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models.Seeds
{
    public static class DanKyuSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanKyu>()
                .HasData(
                    new DanKyu
                    {
                        Id = 1,
                        Grade = 1,
                        Text = "6 KYU"
                    },
                    new DanKyu
                    {
                        Id = 2,
                        Grade = 2,
                        Text = "5 KYU"
                    },
                    new DanKyu
                    {
                        Id = 3,
                        Grade = 3,
                        Text = "4 KYU"
                    },
                    new DanKyu
                    {
                        Id = 4,
                        Grade = 4,
                        Text = "3 KYU"
                    },
                    new DanKyu
                    {
                        Id = 5,
                        Grade = 5,
                        Text = "2 KYU"
                    },
                    new DanKyu
                    {
                        Id = 6,
                        Grade = 5,
                        Text = "1 KYU"
                    },
                    new DanKyu
                    {
                        Id = 7,
                        Grade = 7,
                        Text = "1 DAN"
                    },
                    new DanKyu
                    {
                        Id = 8,
                        Grade = 8,
                        Text = "2 DAN"
                    },
                    new DanKyu
                    {
                        Id = 9,
                        Grade = 9,
                        Text = "3 DAN"
                    },
                    new DanKyu
                    {
                        Id = 10,
                        Grade = 10,
                        Text = "4 DAN"
                    },
                    new DanKyu
                    {
                        Id = 11,
                        Grade = 11,
                        Text = "5 DAN"
                    },
                    new DanKyu
                    {
                        Id = 12,
                        Grade = 12,
                        Text = "6 DAN"
                    },
                    new DanKyu
                    {
                        Id = 13,
                        Grade = 13,
                        Text = "7 DAN"
                    },
                    new DanKyu
                    {
                        Id = 14,
                        Grade = 14,
                        Text = "8 DAN"
                    },
                    new DanKyu
                    {
                        Id = 15,
                        Grade = 15,
                        Text = "9 DAN"
                    },
                    new DanKyu
                    {
                        Id = 16,
                        Grade = 16,
                        Text = "10 DAN"
                    }
                );
        }
    }
}
