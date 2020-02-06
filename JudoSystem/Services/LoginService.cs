using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Helpers;
using JudoSystem.Models;
using Microsoft.EntityFrameworkCore;
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
            User user = db.User.FindByCondition(x => x.Email == userDto.Email).Include(a => a.Role).FirstOrDefault();
            if (user == null)
                throw new Exception("Incorrect email");
            else if (StringHelper.VerifyPassword(user.Password, userDto.Password))
                return user;
            else
                throw new Exception("asd");
        }
    }
}
