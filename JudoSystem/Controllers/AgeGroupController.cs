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
        static ICategorySql categorySql = new CategorySql();
        static IAgeGroupSql ageGroupSql = new AgeGroupSql();
        // GET: api/AgeGroup
        [HttpGet, Authorize(Roles = "Admin, User")]
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
        [HttpPost, Authorize(Roles = "Admin")]
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
        // GET: api/AgeGroup/5
        [HttpGet("{id}/Category", Name = "getAgeGroupCategories"), Authorize(Roles = "Admin, User")]
        public Response getAgeGroupCategories(int id)
        {
            Response res = new Response();
            try
            {
                List<CategoryDao> newCategory= categorySql.getCategoriesByGroup(id);
                res.success(newCategory);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // PUT: api/AgeGroup/5
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
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
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
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
