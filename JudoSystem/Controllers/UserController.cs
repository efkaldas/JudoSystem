using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JudoSystem.Models;
using JudoSystem.Models.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly JudoDbContext db;

        public UserController(JudoDbContext context)
        {
            db = context;
        }
        // GET: api/User
        [HttpGet,Authorize]
        public Response Get()
        {
            Response res = new Response();
            try
            { 
                List<User> users = db.User.ToList();
                res.success(users);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] User user)
        {
            Response res = new Response();
            try
            {
                db.Entry(user).State = EntityState.Modified;

                res.success(user);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            Response res = new Response();
            try
            {
              //  db.User.Remove(id);
                res.success("Removed");
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
        private bool UserExists(int id)
        {
            return db.User.Any(e => e.Id == id);
        }
    }
}
