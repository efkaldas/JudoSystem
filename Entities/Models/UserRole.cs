using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Entities.Models
{
    [Index(nameof(UserId), nameof(Type), IsUnique = true)]
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public UserType Type { get; set; }
    }
}
