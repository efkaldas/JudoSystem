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
        public List<JudokaDao> getJudokas()
        {
            List<JudokaDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Judokas";

                ret = db.Query<JudokaDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public JudokaDao getJudokaById(int id)
        {
            JudokaDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Judokas where id = @id";

                ret = db.Query<JudokaDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public void insertJudoka(JudokaDao judoka)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO Judokas (lastName, firstName, gender, danKyu, BirthYears, userId)
                                        VALUES (@lastName, @firstName, @gender, @danKyu, @BirthYears, @userId)";

                db.Execute(sql, new { judoka.LastName, judoka.FirstName, judoka.Gender, judoka.DanKyu, judoka.BirthYears, judoka.UserId },
                    commandType: CommandType.Text);
            }
        }
        public void updateJudoka(JudokaDao judoka)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE Judokas SET lastName = @lastName, firstName = @firstName,
                                        gender = @gender, danKyu = @danKyu, BirthYears = @BirthYears, userId = @userId WHERE id = @id";

                db.Execute(sql, new { judoka.LastName, judoka.FirstName, judoka.Gender, judoka.DanKyu, judoka.BirthYears, judoka.UserId, judoka.Id },
                    commandType: CommandType.Text);
            }
        }
        public void deleteJudoka(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM Judokas WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}
