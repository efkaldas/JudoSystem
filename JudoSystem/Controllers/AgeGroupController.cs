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
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class AgeGroupController : ControllerBase
    {
        static IAgeGroupSql ageGroupSql = new AgeGroupSql();
        // GET: api/AgeGroup
        [HttpGet]
        public Response getAgeGroupList()
        {
            Response res = new Response();
            try
            {
                List<AgeGroupDao> ageGroups = new List<AgeGroupDao>();
                ageGroups = ageGroupSql.getAgeGroups();
                res.success(ageGroups);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        //// GET: api/AgeGroup/5
        [HttpGet("{id}", Name = "getAgeGroups"), Authorize]
        public Response getAgeGroups(int id)
        {
            Response res = new Response();
            try
            {
                AgeGroupDao newAgeGroup = ageGroupSql.getAgeGroupById(id);
                res.success(newAgeGroup);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
        // POST: api/AgeGroup
        [HttpPost, Authorize]
        public Response insertAgeGroup([FromBody] AgeGroupDao newAgeGroup)
        {
            Response res = new Response();
            try
            {
                ageGroupSql.insertAgeGroup(newAgeGroup);
                res.success(newAgeGroup);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // PUT: api/AgeGroup/5
        [HttpPut("{id}"), Authorize]
        public Response updateAgeGroup(int id, [FromBody] AgeGroupDao newAgeGroup)
        {
            Response res = new Response();
            try
            {
                newAgeGroup.Id = id;
                ageGroupSql.updateAgeGroup(newAgeGroup);
                res.success(newAgeGroup);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"), Authorize]
        public Response deleteAgeGroup(int id)
        {
            Response res = new Response();
            try
            {
                ageGroupSql.deleteAgeGroup(id);
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
