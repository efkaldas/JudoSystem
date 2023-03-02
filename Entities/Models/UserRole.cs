using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public UserType Type { get; set; }
    }
}
