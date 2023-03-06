using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Interfaces;
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
        private IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        // GET: api/Organization
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_organizationService.Get());
        }

        // PUT: api/Organization/5
        [Authorize(Roles = "Admin, OrganizationAdmin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Organization organization)
        {
            _organizationService.Update(organization);
            return Ok();
        }
    }
}
