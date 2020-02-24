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
            List<OrganizationType> organizationTypes = db.OrganizationType.FindAll().ToList();
            return Ok(organizationTypes);
        }

        // GET: api/OrganizationType/5
        [HttpGet("{id}", Name = "GetOrganizationType")]
        public IActionResult Get(int id)
        {
            List<OrganizationType> organizationType = db.OrganizationType.FindByCondition(x => x.Id == id).ToList();
            return Ok(organizationType);
        }

        // POST: api/OrganizationType
        [HttpPost]
        public IActionResult Post([FromBody] OrganizationType organizationType)
        {
            db.OrganizationType.Create(organizationType);
            db.Save();
            return Ok(organizationType);
        }

        // PUT: api/OrganizationType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrganizationType organizationType)
        {
            db.OrganizationType.Update(organizationType);
            db.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.OrganizationType.Delete(db.OrganizationType.FindByCondition(x => x.Id == id).FirstOrDefault());
            db.Save();
        }
    }
}
