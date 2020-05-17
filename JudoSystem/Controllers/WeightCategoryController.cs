using System;
using System.Collections.Generic;
using System.IO;
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
    public class WeightCategoryController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public WeightCategoryController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }


        [HttpGet("{id}/Competitors", Name = "GetCompetitors")]
        public IActionResult GetCompetitors(int id)
        {
            WeightCategory weightCategory = db.WeightCategory.FindByCondition(x => x.Id == id)
                .Include(x => x.Competitors)
                    .ThenInclude(x => x.Judoka)
                        .ThenInclude(x => x.DanKyu)
                .Include(x => x.Competitors)
                    .ThenInclude(x => x.Judoka)
                        .ThenInclude(x => x.Gender)
                .Include(x => x.Competitors)
                    .ThenInclude(x => x.Judoka)
                        .ThenInclude(x => x.User)
                            .ThenInclude(x => x.Organization)
                    .FirstOrDefault();

            List<Judoka> competitors = new List<Judoka>();

            foreach (var competitor in weightCategory.Competitors)
            {
                competitors.Add(competitor.Judoka);
            }


            return Ok(competitors);
        }
        [HttpGet("{id}/Results", Name = "GetWeightResults")]
        public IActionResult GetResults(int id)
        {
            List<CompetitionsResults> categoryResults = db.CompetitionsResults.FindByCondition(x => x.WeightCategoryId == id)
                .Include(x => x.Judoka)
                    .ThenInclude(x => x.Gender)
                .Include(x => x.Judoka)
                    .ThenInclude(x => x.DanKyu)
                .Include(x => x.Judoka)
                    .ThenInclude(x => x.User)
                        .ThenInclude(x => x.Organization).ToList();

            return Ok(categoryResults.OrderBy(x => x.Place));
        }
        [Authorize(Roles = "Admin, Coach")]
        [HttpPost("{id}/Competitors", Name = "InsertCompetitors")]
        public IActionResult PostCompetitors(int id, [FromBody]Judoka competitor)
        {
            WeightCategory weightCategory = db.WeightCategory.FindByCondition(x => x.Id == id).FirstOrDefault();
            Judoka judoka = db.Judoka.FindByCondition(x => x.Id == competitor.Id).FirstOrDefault();

            weightCategory.Competitors = new List<Competitor>();

            weightCategory.Competitors.Add(new Competitor { WeightCategory = weightCategory, Judoka = judoka });

            db.WeightCategory.Update(weightCategory);
            db.Save();
            return Ok();
        }
        [Authorize(Roles = "Admin, Coach")]
        [HttpPut("{id}/Competitors", Name = "DeleteCompetitors")]
        public IActionResult DeleteCompetitors(int id, [FromBody]Judoka competitor)
        {
            WeightCategory weightCategory = db.WeightCategory.FindByCondition(x => x.Id == id).Include(x => x.Competitors).FirstOrDefault();

            db.Competitor.Delete(weightCategory.Competitors.Where(x => x.JudokaId == competitor.Id).FirstOrDefault());
            db.Save();
            return Ok();
        }
        [Authorize(Roles = "Admin, Coach")]
        [HttpDelete("{id}/Competitors", Name = "DeleteCompetitors")]
        public IActionResult DeleteCompetitors(int judokaId)
        {
            return Ok();
        }


    }
}
