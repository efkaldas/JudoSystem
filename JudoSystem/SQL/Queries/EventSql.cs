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
    public class EventSql : DataAccess, IEventSql
    {
        public List<EventDao> getEvents()
        {
            List<EventDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Events";

                ret = db.Query<EventDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public EventDao getEventById(int id)
        {
            EventDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM Events where id = @id";

                ret = db.Query<EventDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public void insertEvent(EventDao newEvent)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO Events (eventtype, title, description, entryfee, RegistrationStartDate, RegistrationEndDate, EventStartDate)
                                        VALUES (@eventtype, @title, @description, @entryfee, @RegistrationStartDate, @RegistrationEndDate, @EventStartDate)";

                db.Execute(sql, new
                {
                    newEvent.EventType,
                    newEvent.Title,
                    newEvent.Description,
                    newEvent.EntryFee,
                    newEvent.RegistrationStartDate,
                    newEvent.RegistrationEndDate,
                    newEvent.EventStartDate
                },
                      commandType: CommandType.Text);
            }
        }
        public void updateEvent(EventDao newEvent)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE Events SET EventType = @EventType, Title = @Title,
                                        Description = @Description, EntryFee = @EntryFee, RegistrationStartDate = @RegistrationStartDate,
                                            RegistrationEndDate = @RegistrationEndDate,  EventStartDate = @EventStartDate WHERE id = @id";

                db.Execute(sql, new
                {
                    newEvent.EventType,
                    newEvent.Title,
                    newEvent.Description,
                    newEvent.EntryFee,
                    newEvent.RegistrationStartDate,
                    newEvent.RegistrationEndDate,
                    newEvent.EventStartDate,
                    newEvent.Id
                },
                    commandType: CommandType.Text);
            }
        }
        public void deleteEvent(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM Events WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}