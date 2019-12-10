using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JudoSystem.Models;
using JudoSystem.Models.Dao;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        static IEventSql eventSql = new EventSql();
        static IAgeGroupSql ageGroupSql = new AgeGroupSql();
        // GET: api/Event
        [HttpGet, Authorize(Roles = "User")]
        public Response getEventList()
        {
            Response res = new Response();
            try
            {
                List<EventDao> events = new List<EventDao>();
                events = eventSql.getEvents();
                res.success(events);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "getEvent"), Authorize]
        public Response getEvent(int id)
        {
            Response res = new Response();
            try
            {
                EventDao newEvent = eventSql.getEventById(id);
                res.success(newEvent);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
        // GET: api/Event/5
        [HttpGet("{id}/AgeGroup", Name = "getEventAgeGroup"), Authorize(Roles = "Admin, User")]
        public Response getEventAgeGroup(int id)
        {
            Response res = new Response();
            try
            {
                List<AgeGroupDao> newEvent = ageGroupSql.getAgeGroupsByEvent(id);
                res.success(newEvent);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // POST: api/Event
        [HttpPost, Authorize(Roles = "Admin")]
        public Response createEvent([FromBody] EventDao newEvent)
        {
            Response res = new Response();
            try
            {
                eventSql.insertEvent(newEvent);
                res.success(newEvent);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // PUT: api/Event/5
        [HttpPut("{id}"), Authorize]
        public Response updateEvent(int id, [FromBody] EventDao newEvent)
        {
            Response res = new Response();
            try
            {
                newEvent.Id = id;
                eventSql.updateEvent(newEvent);
                res.success(newEvent);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"), Authorize]
        public Response deleteEvent(int id)
        {
            Response res = new Response();
            try
            {
                eventSql.deleteEvent(id);
                res.success("Removed");
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
    }
}
