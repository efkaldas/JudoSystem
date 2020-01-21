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
        public List<UserDao> GetUsers()
        {
            List<UserDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Users";

                ret = db.Query<UserDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public void InsertUser(UserDao newUser)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO Users (role, parentUser, email, firstname, lastname, phoneNumber,
                                            status, organizationId, password, dateCreated, dateUpdated)
                                        VALUES (@Role, @ParentUser, @Email, @Firstname, @Lastname, @PhoneNumber, @Status,
                                            @OrganizationId, @Password, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)";

                db.Execute(sql, new
                {
                    newUser.Role,
                    newUser.ParentUser,
                    newUser.Email,
                    newUser.Firstname,
                    newUser.Lastname,
                    newUser.PhoneNumber,
                    newUser.Status,
                    newUser.OrganizationId,
                    newUser.Password,
                },
                    commandType: CommandType.Text);
            }
        }
        public UserDao GetByMail(string email)
        {
            UserDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Users WHERE email = @email";

                ret = db.Query<UserDao>(sql, new { email }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public UserDao GetUser(int id)
        {
            UserDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Users where id = @id";

                ret = db.Query<UserDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public void UpdateUser(UserDao newUser)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE Users SET role = @Role, parentUser = @ParentUser,
                                        email = @Email, firstname = @Firstname, lastname = @Lastname,
                                        phoneNumber = @PhoneNumber, status = @Status, organizationId = @OrganizationId,
                                        password = @Password, dateUpdated = CURRENT_TIMESTAMP WHERE id = @id";
                db.Execute(sql, new
                {
                    newUser.Role,
                    newUser.ParentUser,
                    newUser.Email,
                    newUser.Firstname,
                    newUser.Lastname,
                    newUser.PhoneNumber,
                    newUser.Status,
                    newUser.OrganizationId,
                    newUser.Password,
                    newUser.Id,
                },
                    commandType: CommandType.Text);
            }
        }
        public void DeleteUser(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM Users WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}