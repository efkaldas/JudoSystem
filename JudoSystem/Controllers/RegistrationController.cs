using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JudoSystem.Models;
using JudoSystem.Models.Dto;
using JudoSystem.Services;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        static IUserSql userSql = new UserSql();
        // GET: api/Registration
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Registration
        [AllowAnonymous]
        [HttpPost]
        public Response Register([FromBody]UserDao userDao)
        {
            Response response = new Response();
            try
            {
                UserService userService = new UserService();

                userSql.insertUser(userDao);

                response.success(userDao);
            }
            catch (Exception e)
            {
                response.error(e.Message);
            }
            return response;
        }
        // PUT: api/Registration/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
