using JudoSystem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class UserDao
    {
        public static readonly string ADMIN = "Admin";
        public static readonly string USER = "User";

        public int Id { get; set; }
        public int UserRole { get; set; }
        public string Username { get; set; }
        public string ClubName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
