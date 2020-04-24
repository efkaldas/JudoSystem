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
    public class RoleController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper db;
        public RoleController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this.logger = logger;
            db = repository;
        }
        // GET: api/Role
        [HttpGet]
        public IActionResult Get()
        {
            List<Role> roles = db.Role.FindAll().ToList();
            return Ok(roles);
        }
    }
}
