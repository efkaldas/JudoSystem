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
    }
}
