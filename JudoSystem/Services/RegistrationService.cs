﻿using JudoSystem.Models;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class RegistrationService
    {
        private const string MESSAGE_EMAIL_EXIST = "This email allready exists";

        IUserSql userSql = new UserSql();
        public bool IsFormValid(User user, JudoDbContext db)
        {
            List<User> allUsers = db.User.ToList();

            if (allUsers.Find(x => x.Email == user.Email) != null)
                throw new Exception(MESSAGE_EMAIL_EXIST);
            else
                return true;
        }
    }
}
