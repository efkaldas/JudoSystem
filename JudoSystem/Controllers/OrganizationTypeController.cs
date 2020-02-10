using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationTypeController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper db;
        public OrganizationTypeController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this.logger = logger;
            db = repository;
        }

        // GET: api/OrganizationType
        [HttpGet]
        public IActionResult Get()
        {
            List<OrganizationType> users = db.OrganizationType.FindAll().ToList();
            return Ok(users);
        }

        //// GET: api/OrganizationType/5
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(int id)
        //{
        //    return Ok("value");
        //}

        // POST: api/OrganizationType
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OrganizationType/5
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
