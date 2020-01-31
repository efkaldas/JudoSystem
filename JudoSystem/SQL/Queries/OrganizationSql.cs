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
            //using (var db = getConnection())
            //{
            //    const string sql = @"SELECT * FROM Organzation";

            //    ret = db.Query<OrganizationDao>(sql, commandType: CommandType.Text).ToList();
            //}
            return null;
        }
        public OrganizationDao GetOrganizationByUserId(int userId)
        {
            OrganizationDao ret;
            //using (var db = getConnection())
            //{
            //    const string sql = @"SELECT * FROM Organzation where user_id = @userId";

            //    ret = db.Query<OrganizationDao>(sql, new { userId }, commandType: CommandType.Text).FirstOrDefault();
            //}
            return null;
        }
        public OrganizationDao GetOrganization(int id)
        {
            OrganizationDao ret;
            //using (var db = getConnection())
            //{
            //    const string sql = @"SELECT * FROM Organzation where id = @id";

            //    ret = db.Query<OrganizationDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            //}
            return null;
        }
        public int InsertOrganization(OrganizationDao newOrganization)
        {
            //using (var db = getConnection())
            //{
            //    const string sql = @"INSERT INTO Organization (name, country, city, typeId)
            //                            VALUES (@Name, @Country, @City, @TypeId);
            //                         SELECT LAST_INSERT_ID();";

            //    return db.Query<int>(sql, new
            //    {
            //        newOrganization.Name,
            //        newOrganization.Country,
            //        newOrganization.City,
            //        newOrganization.TypeId,
            //    },
            //        commandType: CommandType.Text).Single();
            //}
            return 0;
        }
        public void UpdateOrganization(OrganizationDao newOrganization)
        {
            //using (var db = getConnection())
            //{
            //    const string sql = @"UPDATE Organzation SET name = @Name, country = @Country,
            //                            city = @City, type_id = @typeId WHERE id = @id";
            //    db.Execute(sql, new
            //    {
            //        newOrganization.Name,
            //        newOrganization.Country,
            //        newOrganization.City,
            //        newOrganization.TypeId,
            //        newOrganization.Id,
            //    },
            //        commandType: CommandType.Text);
            //}
        }
        public void DeleteOrganization(int id)
        {
            //using (var db = getConnection())
            //{
            //    const string sql = @"DELETE FROM Organzation WHERE id = @id";

            //    db.Execute(sql, new { id }, commandType: CommandType.Text);
            //}
        }
    }
}
