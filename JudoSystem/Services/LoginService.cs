using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Helpers;
using JudoSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class LoginService
    {
        public User GetLoggedUser(UserDto userDto, IRepositoryWrapper db)
        {
            User user = db.User.FindByCondition(x => x.Email == userDto.Email).FirstOrDefault();
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
