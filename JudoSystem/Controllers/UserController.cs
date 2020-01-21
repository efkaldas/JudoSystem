using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JudoSystem.Models;
using JudoSystem.SQL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        UserSql userSql = new UserSql();
        // GET: api/User
        [HttpGet,Authorize]
        public Response Get()
        {
            Response res = new Response();
            try
            {
                List<UserDao> users = new List<UserDao>();
                users = userSql.GetUsers();
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
        public Response Put(int id, [FromBody] UserDao user)
        {
            Response res = new Response();
            try
            {
                user.Id = id;
                userSql.UpdateUser(user);
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
                userSql.DeleteUser(id);
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
