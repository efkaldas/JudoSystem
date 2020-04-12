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
        [HttpGet("{id}", Name = "GetUser")]
        [ServiceFilter(typeof(ValidateEntityExists<User>))]
        public IActionResult Get(int id)
        {
            User user = HttpContext.Items["entity"] as User;
            return Ok(user);
        }

        [HttpGet("{id}/Judokas", Name = "Get")]
        public IActionResult GetJudokas(int id)
        {
            Judoka judoka = db.Judoka.FindByConditionFull(x => x.Id == id).FirstOrDefault();
            return Ok(judoka);
        }

        // POST: api/User
        [HttpPost]
        [ServiceFilter(typeof(ValidateForm))]
        public IActionResult Post([FromBody] User user)
        {
            db.User.Create(user);
            db.Save();

            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateForm))]
        [ServiceFilter(typeof(ValidateEntityExists<User>))]
        public IActionResult Put(User user)
        {
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
