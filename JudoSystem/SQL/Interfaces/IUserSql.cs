using JudoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface IUserSql
    {
        List<UserDao> GetUsers();
        void InsertUser(UserDao newUser);
        UserDao GetByMail(string email);
        UserDao GetUser(int id);
        void UpdateUser(UserDao judoka);
        void DeleteUser(int id);
    }
}
