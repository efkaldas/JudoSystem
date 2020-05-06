using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class UserRole
    {
        public static readonly int COACH = 3;
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
