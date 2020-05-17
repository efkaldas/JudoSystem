using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public OrganizationController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/Organization
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<Organization> organizations = db.Organization.FindAll().Include(x => x.OrganizationType).ToList();
            return Ok(organizations);
        }


        // PUT: api/Organization/5
        [Authorize(Roles = "Admin, Organization admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Organization value)
        {
            db.Organization.Update(value);
            return Ok();
        }
    }
}
