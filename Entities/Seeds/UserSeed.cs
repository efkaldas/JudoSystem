using CryptoHelper;
using Entities.Models;
using Enums;
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
                        OrganizationId = 1,
                        DanKyuId = 1,
                //        Image = "admin_image.png",
                        Email = "judosystem.info@gmail.com",
                        PhoneNumber = "+37060477292",
                        Status = UserStatus.Approved,
                        Password = Crypto.HashPassword("adminJudo1337"),
                        UserRoles = new List<UserRole>(),
                        BirthDate = DateTime.Now,
                        Gender = Gender.Male,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    }
                    ); 
        }
    }
}
