using CryptoHelper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Seeds
{
    public static class UserSeed
    {
        public static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Firstname = "Evaldas",
                        ParentUserId = null,
                        Lastname = "Kušlevič",
                        OrganizationId = null,
                        DanKyuId = null,
                        Image = "Admin_Image",
                        Email = "judosystem.info@gmail.com",
                        PhoneNumber = "+37060477292",
                        StatusId = UserStatus.STATUS_APPROVED,
                        Password = Crypto.HashPassword("adminJudo1337"),
                        UserRoles = new List<UserRole>(),
                        BirthDate = DateTime.Now,
                        GenderId = 1,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    }
                    ); 
        }
    }
}
