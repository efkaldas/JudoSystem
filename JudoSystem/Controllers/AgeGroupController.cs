using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class AgeGroupController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public AgeGroupController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }

        // GET: api/AgeGroup/5
        [HttpGet("{id}/Judokas", Name = "GetAgeGroupUserJudokas")]
        [Authorize(Roles = "Admin, coach")]
        public IActionResult GetAgeGroupUserJudokas(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
            AgeGroup ageGroup = db.AgeGroup.FindByCondition(x => x.Id == id).FirstOrDefault();

            List<Judoka> judokas = db.Judoka.FindByCondition(x => x.UserId == userId
            && x.Gender== ageGroup.Gender && x.BirthYears <= ageGroup.YearsTo && x.BirthYears >= ageGroup.YearsFrom
            && x.DanKyuId <= ageGroup.DanKyuTo && x.DanKyuId >= ageGroup.DanKyuFrom)
                .Include(x => x.DanKyu)
                .Include(x => x.WeightCategories)
                    .ThenInclude(x => x.WeightCategory)
                .ToList();

            foreach (var judoka in judokas)
            {
                judoka.WeightCategories = judoka.WeightCategories.Where(x => x.WeightCategory.AgeGroupId == id).ToList();
            }

            return Ok(judokas);
        }

        [HttpGet("{id}/WeightCategories", Name = "GetWeightCategories")]
        public IActionResult GetWeightCategories(int id)
        {
            List<WeightCategory> weightCategories = db.WeightCategory.FindByCondition(x => x.AgeGroupId == id).ToList();

            return Ok(weightCategories);
        }

        // POST: api/AgeGroup
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] AgeGroup ageGroup)
        {
            db.AgeGroup.Create(ageGroup);
            db.Save();
            return Ok();
        }

        // PUT: api/AgeGroup/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody] AgeGroup ageGroup)
        {
            AgeGroup ageGroupDB = db.AgeGroup.FindByCondition(x => x.Id == id).FirstOrDefault();
            db.AgeGroup.Update(ageGroup);
        }
        [Authorize(Roles = "Admin")]

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AgeGroup ageGroup = db.AgeGroup.FindByCondition(x => x.Id == id).FirstOrDefault();
            db.AgeGroup.Delete(ageGroup);
            db.Save();
        }
    }
}
