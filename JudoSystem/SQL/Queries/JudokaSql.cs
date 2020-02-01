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
    public class JudokaSql : DataAccess, IJudokaSql
    {
        public List<JudokaDao> GetJudokas()
        {
            List<JudokaDao> ret;
            //using (var db = getConnection())
            //{
            //    const string sql = @"SELECT * FROM Judokas";

            //    ret = db.Query<JudokaDao>(sql, commandType: CommandType.Text).ToList();
            //}
            return null;
        }
        public List<JudokaDao> GetUserJudokas(int userId)
        {
            List<JudokaDao> ret;
            //using (var db = getConnection())
            //{
            //    const string sql = @"SELECT * FROM Judokas where userId = @userId";

            //    ret = db.Query<JudokaDao>(sql, new { userId }, commandType: CommandType.Text).ToList();
            //}
            return null;
        }
        public JudokaDao GetJudokaById(int id)
        {
            JudokaDao ret;
            //using (var db = getConnection())
            //{
            //    const string sql = @"SELECT * FROM Judokas where id = @id";

            //    ret = db.Query<JudokaDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            //}
            return null;
        }
        public void InsertJudoka(JudokaDao judoka)
        {
            //using (var db = getConnection())
            //{
            //    const string sql = @"INSERT INTO Judokas (lastName, firstName, gender, danKyu, BirthYears, userId)
            //                            VALUES (@lastName, @firstName, @gender, @danKyu, @BirthYears, @userId)";

            //    db.Execute(sql, new { judoka.LastName, judoka.FirstName, judoka.Gender, judoka.DanKyu, judoka.BirthYears, judoka.UserId },
            //        commandType: CommandType.Text);
        //    }
        }
        public void UpdateJudoka(JudokaDao judoka)
        {
            //using (var db = getConnection())
            //{
            //    const string sql = @"UPDATE Judokas SET lastName = @lastName, firstName = @firstName,
            //                            gender = @gender, danKyu = @danKyu, BirthYears = @BirthYears, userId = @userId WHERE id = @id";

            //    db.Execute(sql, new { judoka.LastName, judoka.FirstName, judoka.Gender, judoka.DanKyu, judoka.BirthYears, judoka.UserId, judoka.Id },
            //        commandType: CommandType.Text);
           // }
        }
        public void DeleteJudoka(int id)
        {
            //using (var db = getConnection())
            //{
            //    const string sql = @"DELETE FROM Judokas WHERE id = @id";

            //    db.Execute(sql, new { id }, commandType: CommandType.Text);
            //}
        }
    }
}
