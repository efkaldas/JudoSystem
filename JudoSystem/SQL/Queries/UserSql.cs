using JudoSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using JudoSystem.SQL.Interfaces;

namespace JudoSystem.SQL.Queries
{
    public class UserSql : DataAccess, IUserSql
    {
        public List<UserDao> getUsers()
        {
            List<UserDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Users";

                ret = db.Query<UserDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public void insertUser(UserDao newUser)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO Users (UserRole, Username, ClubName, FirstName, LastName, Country, City,
                                            Email, Password, DateCreated, DateUpdated)
                                        VALUES (@UserRole, @Username, @ClubName, @FirstName, @LastName, @Country, @City,
                                            @Email, @Password, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)";
                db.Execute(sql, new
                {
                    newUser.UserRole,
                    newUser.Username,
                    newUser.ClubName,
                    newUser.FirstName,
                    newUser.LastName,
                    newUser.Country,
                    newUser.City,
                    newUser.Email,
                    newUser.Password
                },
                    commandType: CommandType.Text);
            }
        }
        public UserDao getByName(string username)
        {
            List<UserDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Users WHERE username = @username";

                ret = db.Query<UserDao>(sql, new { username }, commandType: CommandType.Text).ToList();
            }
            return ret.First();
        }
        public UserDao getUserById(int id)
        {
            UserDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Users where id = @id";

                ret = db.Query<UserDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public void updateUser(UserDao newUser)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE Events SET UserRole = @UserRole, Username = @Username,
                                        ClubName = @ClubName, FirstName = @FirstName, LastName = @LastName,
                                        Country = @Country,  City = @City, Email = @Email,
                                        Password = @Password, WHERE id = @id";
                db.Execute(sql, new
                {
                    newUser.UserRole,
                    newUser.Username,
                    newUser.ClubName,
                    newUser.FirstName,
                    newUser.LastName,
                    newUser.Country,
                    newUser.City,
                    newUser.Email,
                    newUser.Password,
                    newUser.Id,
                },
                    commandType: CommandType.Text);
            }
        }
        public void deleteUser(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM Users WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}