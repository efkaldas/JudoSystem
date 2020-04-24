using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsTypeController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public CompetitionsTypeController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/CompetitionsType
        [HttpGet]
        public IActionResult Get()
        {
            List<CompetitionsType> competitionsType = db.CompetitionsType.FindAll().ToList();
            return Ok(competitionsType);
        }
    }
}
