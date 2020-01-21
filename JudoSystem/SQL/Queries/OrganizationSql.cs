using Dapper;
using JudoSystem.Models;
using JudoSystem.Models.Dao;
using JudoSystem.SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Queries
{
    public class OrganizationSql : DataAccess, IOrganizationSql
    {
        public List<OrganizationDao> GetOrganizations()
        {
            List<OrganizationDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Organzations";

                ret = db.Query<OrganizationDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public OrganizationDao GetOrganizationByUserId(int userId)
        {
            OrganizationDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Organzations where user_id = @userId";

                ret = db.Query<OrganizationDao>(sql, new { userId }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public OrganizationDao GetOrganization(int id)
        {
            OrganizationDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Organzations where id = @id";

                ret = db.Query<OrganizationDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public int InsertOrganization(OrganizationDao newOrganization)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO Organizations (name, country, city, typeId)
                                        VALUES (@Name, @Country, @City, @TypeId);
                                     SELECT LAST_INSERT_ID();";

                return db.Query<int>(sql, new
                {
                    newOrganization.Name,
                    newOrganization.Country,
                    newOrganization.City,
                    newOrganization.TypeId,
                },
                    commandType: CommandType.Text).Single();
            }
        }
        public void UpdateOrganization(OrganizationDao newOrganization)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE Organzations SET name = @Name, country = @Country,
                                        city = @City, type_id = @typeId WHERE id = @id";
                db.Execute(sql, new
                {
                    newOrganization.Name,
                    newOrganization.Country,
                    newOrganization.City,
                    newOrganization.TypeId,
                    newOrganization.Id,
                },
                    commandType: CommandType.Text);
            }
        }
        public void DeleteOrganization(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM Organzations WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}
