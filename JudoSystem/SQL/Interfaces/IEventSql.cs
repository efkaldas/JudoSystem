using JudoSystem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface IEventSql
    {
        List<EventDao> getEvents();
        EventDao getEventById(int id);
        void insertEvent(EventDao newEvent);
        void updateEvent(EventDao newEvent);
        void deleteEvent(int id);
    }
}
