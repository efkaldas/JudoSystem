using JudoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface IUserSql
    {
        List<UserDao> getUsers();
        void insertUser(UserDao newUser);
        UserDao getByName(string username);
        UserDao getUserById(int id);
        void updateUser(UserDao judoka);
        void deleteUser(int id);
    }
}
