using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper db;
        public UserController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this.logger = logger;
            db = repository;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = db.User.FindAll().ToList();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        [ServiceFilter(typeof(ValidateEntityExists<User>))]
        public IActionResult Get(int id)
        {
            User user = HttpContext.Items["entity"] as User;
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        [ServiceFilter(typeof(ValidateForm))]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateForm))]
        [ServiceFilter(typeof(ValidateEntityExists<User>))]
        public void Put(User user)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
