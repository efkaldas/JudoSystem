using JudoSystem.Helpers;
using JudoSystem.Models;
using JudoSystem.Models.Dto;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class LoginService
    {
        public User GetLoggedUser(UserDto userDto, JudoDbContext db)
        {
            User user = db.User.ToList().Find(x => x.Email == userDto.Email);
            if (user == null)
                throw new Exception("Incorrect email");
            else if (IsPasswordCorrect(StringHelper.HashPassword(userDto.Password), user))
                return user;
            else
                throw new Exception("Incorrect password");
        }

        private bool IsPasswordCorrect(string password, User user)
        {
            if (password == user.Password)
                return true;
            else
                return false;
        }
    }
}
