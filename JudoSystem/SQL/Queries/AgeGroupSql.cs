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
    public class AgeGroupSql : DataAccess, IAgeGroupSql
    {
        public List<AgeGroupDao> getAgeGroups()
        {
            List<AgeGroupDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM age_groups";

                ret = db.Query<AgeGroupDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public AgeGroupDao getAgeGroupById(int id)
        {
            AgeGroupDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM age_groups where id = @id";

                ret = db.Query<AgeGroupDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public List<AgeGroupDao> getAgeGroupsByEvent(int eventId)
        {
            List<AgeGroupDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM age_groups where eventID = @eventId";

                ret = db.Query<AgeGroupDao>(sql, new { eventId }, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public void insertAgeGroup(AgeGroupDao newAgeGroup)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO age_groups (Title, Gender, YearsFrom, YearsTo, EventID)
                                        VALUES (@Title, @Gender, @YearsFrom, @YearsTo, @EventID)";

                db.Execute(sql, new
                {
                    newAgeGroup.Title,
                    newAgeGroup.Gender,
                    newAgeGroup.YearsFrom,
                    newAgeGroup.YearsTo,
                    newAgeGroup.EventID
                },
                      commandType: CommandType.Text);
            }
        }
        public void updateAgeGroup(AgeGroupDao newAgeGroup)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE Events SET Title = @Title, Gender = @Gender,
                                        YearsFrom = @YearsFrom, YearsTo = @YearsTo, EventID = @EventID WHERE id = @id";

                db.Execute(sql, new
                {
                    newAgeGroup.Title,
                    newAgeGroup.Gender,
                    newAgeGroup.YearsFrom,
                    newAgeGroup.YearsTo,
                    newAgeGroup.EventID,
                    newAgeGroup.Id,
                },
                    commandType: CommandType.Text);
            }
        }
        public void deleteAgeGroup(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM age_groups WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}

