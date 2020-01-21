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
        public int Role { get; set; }
        public int ParentUser { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public int OrganizationId { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
