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
        IUserSql usersSql = new UserSql();
        public UserDao GetLoggedUser(UserDto userDto)
        {
            UserDao user = usersSql.GetByMail(userDto.Email);
            if (user == null)
                throw new Exception("Incorrect email");
            else if (IsPasswordCorrect(StringHelper.HashPassword(userDto.Password), user))
                return user;
            else
                throw new Exception("Incorrect password");
        }

        private bool IsPasswordCorrect(string password, UserDao user)
        {
            if (password == user.Password)
                return true;
            else
                return false;
        }
    }
}
