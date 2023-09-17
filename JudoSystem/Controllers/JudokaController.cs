using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities.Models;
using Enums;
using JudoSystem.Helpers;
using JudoSystem.Interfaces;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NuGet.Protocol.Core.Types;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "Admin, Coach")]
    public class JudokaController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IJudokaService _judokaService;
    
        public JudokaController(IRepositoryWrapper repoWrapper, IJudokaService judokaService)
        { 
            _judokaService = judokaService;
            db = repoWrapper;
        }
        // GET: api/Judoka
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            List<Judoka> judokas = db.Judoka.FindAllFull().ToList();
            return Ok(judokas);
        }

        [HttpGet("ByRank", Name = "GetJudokasByRank")]
        [Authorize]
        public IActionResult GetJudokasByRank(Gender gender)
        {
            List<Judoka> judokas = db.Judoka.FindByConditionFull(x => x.Gender == gender)
                    .Include(x => x.User)
                    .Include(x => x.User)
                        .ThenInclude(x => x.Organization).ToList();


            return Ok(judokas.OrderByDescending(x => x.Points));
        }


        // GET: api/Judoka/5
        [HttpGet("{id}", Name = "GetJudoka")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Judoka judoka = db.Judoka.FindByConditionFull(x => x.Id == id)
                .Include(x => x.User)
                    .ThenInclude(x => x.Organization).FirstOrDefault();

            return Ok(judoka);
        }
        // GET: api/Judoka/5
        [HttpGet("{id}/History", Name = "GetJudokaHistory")]
        [Authorize]
        public IActionResult GetHistory(int id)
        {
            List<CompetitionsResults> results = db.CompetitionsResults.FindByCondition(x => x.JudokaId == id)
                .Include(x => x.WeightCategory)
                    .ThenInclude(x => x.AgeGroup)
                        .ThenInclude(x => x.Competitions).ToList();

            return Ok(results);
        }
        // GET: api/Judoka/5
        [HttpGet("MyJudokas", Name = "MyJudokas")]
        [Authorize(Roles = "Admin, Coach")]
        public IActionResult GetMyJudokas()
        {
            return Ok(_judokaService.GetUserJudokas());
        }

        // POST: api/Judoka
        [HttpPost]
        [Authorize(Roles = "Admin, Coach")]
        public IActionResult Post([FromBody] Judoka judoka)
        {
            var currentUserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            if (judoka.UserId != currentUserId)
            {
                List<User> users = db.User.FindByCondition(x => x.ParentUserId == currentUserId).ToList();

                if (!users.Any())
                    return null;
            }

            judoka.Firstname = StringHelper.ToTitleCase(judoka.Firstname);
            judoka.Lastname = StringHelper.ToTitleCase(judoka.Lastname);
            judoka.Points = 0;

            db.Judoka.Create(judoka);
            db.Save();

            return Ok();
        }

        // PUT: api/Judoka/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Coach")]
        public IActionResult Put(int id, [FromBody] Judoka judoka)
        {
            var currentUserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            if (judoka.UserId != currentUserId)
            {
                List<User> users = db.User.FindByCondition(x => x.ParentUserId == currentUserId).ToList();

                if (!users.Any())
                    return null;
            }

            judoka.Id = id;
            judoka.Firstname = StringHelper.ToTitleCase(judoka.Firstname);
            judoka.Lastname = StringHelper.ToTitleCase(judoka.Lastname);

            db.Judoka.Update(judoka);
            db.Save();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Coach")]
        public IActionResult Delete(int id)
        {
            Judoka judokaToDelete = db.Judoka.FindByCondition(x => id == x.Id).FirstOrDefault();

            if (judokaToDelete != null)
                db.Judoka.Delete(judokaToDelete);
            else
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_NOT_FOUND_CONST, "Sportininkas nerastas"));

            db.Save();

            return Ok();
        }
    }
}
