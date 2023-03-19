using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Helpers;
using JudoSystem.Interfaces;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IWebHostEnvironment _env;

        public OrganizationController(IOrganizationService organizationService, IWebHostEnvironment env)
        {
            _organizationService = organizationService;
            _env = env;
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

        [HttpPost("UploadImage")]
        //[ServiceFilter(typeof(ValidateForm))]
        public IActionResult UploadImage([FromForm] IFormFile image)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
            var organization = _organizationService.UpdateImage(userId, image);

            return Ok(organization);
        }
    }
}
