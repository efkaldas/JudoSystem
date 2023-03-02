using Entities.Models;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Seeds
{
    class OrganizationSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasData(
                    new Organization
                    {
                        Id = 1,
                        ExactName = "My Admin Orgaization",
                        ShortName = "Admin org",
                        Country = "LTU",
                        City = "Vilnius",
                        Address = "Vilniaus g. 18",
                        Image = "no_organization_image.png",
                        Type = OrganizationType.Club,
                    }
                );
        }
    }
}
