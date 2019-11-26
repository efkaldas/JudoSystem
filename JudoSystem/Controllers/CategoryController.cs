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
    public class CategoryController : ControllerBase
    {
        static ICategorySql categorySql = new CategorySql();
        // GET: api/Category
        [HttpGet, Authorize]
        public Response getCategoryList()
        {
            Response res = new Response();
            try
            {
                List<CategoryDao> events = new List<CategoryDao>();
                events = categorySql.getCategories();
                res.success(events);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "getCategory"), Authorize]
        public Response getCategory(int id)
        {
            Response res = new Response();
            try
            {
                CategoryDao newCategory = categorySql.getCategoryById(id);
                res.success(newCategory);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // POST: api/Category
        [HttpPost, Authorize]
        public Response createCategory([FromBody] CategoryDao newCategory)
        {
            Response res = new Response();
            try
            {
                categorySql.insertCategory(newCategory);
                res.success(newCategory);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // PUT: api/Category/5
        [HttpPut("{id}"), Authorize]
        public Response updateCategory(int id, [FromBody] CategoryDao newCategory)
        {
            Response res = new Response();
            try
            {
                newCategory.Id = id;
                categorySql.updateCategory(newCategory);
                res.success(newCategory);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"), Authorize]
        public Response deleteCategory(int id)
        {
            Response res = new Response();
            try
            {
                categorySql.deleteCategory(id);
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
