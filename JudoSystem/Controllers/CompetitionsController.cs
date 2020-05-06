using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public CompetitionsController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/Competitions
        [HttpGet]
        public IActionResult Get()
        {
            List<Competitions> competitions = db.Competitions.FindAll().ToList();
            return Ok(competitions);
        }

        // GET: api/Competitions/5
        [HttpGet("{id}", Name = "GetCompetitions")]
        public IActionResult Get(int id)
        {
            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                .Include(x => x.Judges)
                .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                .FirstOrDefault();
            return Ok(competitions);
        }
        // GET: api/Competitions/5
        [HttpGet("{id}/AgeGroups", Name = "GetCompetitionsАgeGroups")]
        public IActionResult GetAgeGroups(int id)
        {
            List<AgeGroup> ageGroups = db.AgeGroup.FindByCondition(x => x.CompetitionsId == id).ToList();
            return Ok(ageGroups);
        }

        // POST: api/Competitions
        [HttpPost]
        public IActionResult Post([FromBody] Competitions competitions)
        {
            competitions.DateCreated = DateTime.Now;
            db.Competitions.Create(competitions);
            db.Save();
            return Ok();
        }

        // PUT: api/Competitions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
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
