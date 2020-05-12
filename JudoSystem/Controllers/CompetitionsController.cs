using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Services;
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

        [HttpGet("{id}/Competitors-list.csv", Name = "GetCompetitorsList")]
        public IActionResult GetCompetitors(int id)
        {
            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                    .Include(x => x.AgeGroups)
                        .ThenInclude(x => x.WeightCategories)
                            .ThenInclude(x => x.Competitors)
                                .ThenInclude(x => x.Judoka)
                                    .ThenInclude(x => x.User)
                                        .ThenInclude(x => x.Organization)
                     .Include(x => x.AgeGroups)
                        .ThenInclude(x => x.WeightCategories)
                            .ThenInclude(x => x.Competitors)
                                .ThenInclude(x => x.Judoka)
                                    .ThenInclude(x => x.Gender).FirstOrDefault();

            CompetitorsListService export = new CompetitorsListService();
            string file = export.Execute(competitions);

            return File(System.IO.File.OpenRead(file), "text/csv");

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
        [HttpGet("{id}/MyCompetitors", Name = "GetMyCompetitors")]
        public IActionResult GetMyCompetitors(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                .Include(x => x.AgeGroups).FirstOrDefault();

            List<int> weightCatoriesIds = db.WeightCategory.FindByCondition(x => competitions.AgeGroups.Where(x => x.Id == id) != null).Select(x => x.Id).ToList();

            List<Judoka> myJudokas = db.Judoka.FindByCondition(x => x.UserId == userId)
                .Include(x => x.WeightCategories)
                    .Include(x => x.WeightCategories)
                        .ToList()

            List<Judoka> competitor = new List<Judoka>();

            foreach (var ageGroup in competitions.AgeGroups)
            {
                competitor.Add(ageGroup.WeightCategories.Select(x => x.Competitors.Where(x => myJudokas.Contains(x.Judoka))
                .Select(x => x.Judoka)).ToList())
            }

            List<Judoka> myCompetitors = Judokas



            return Ok(competitions);
        }
        // GET: api/Competitions/5
        [HttpGet("{id}/AgeGroups", Name = "GetCompetitionsАgeGroups")]
        public IActionResult GetAgeGroups(int id)
        {
            List<AgeGroup> ageGroups = db.AgeGroup.FindByCondition(x => x.CompetitionsId == id).ToList();
            return Ok(ageGroups);
        }
        [HttpPost("{id}/ResultsFile", Name = "ImportResultsFile")]
        public IActionResult ImportResultsFile(int id, [FromHeader]IFormFile file)
        {
            var httpRequest = HttpContext.Request;
            if (httpRequest.Form.Files.Count == 0)
            {
                return null;
            }
            string localFileLocation = Path.GetTempPath() + file.FileName;

            if (System.IO.File.Exists(localFileLocation))
                System.IO.File.Delete(localFileLocation);

            if (file.ContentType.ToString() == "application/pdf")
            {
                using (var fileStream = new FileStream(localFileLocation, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            if (System.IO.File.Exists(localFileLocation))
            {
                return Ok();
            }
            return null;
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
