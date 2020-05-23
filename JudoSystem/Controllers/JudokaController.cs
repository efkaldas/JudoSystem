using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "Admin, Coach")]
    public class JudokaController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public JudokaController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
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
        public IActionResult GetJudokasByRank(int genderId)
        {
            List<Judoka> judokas = db.Judoka.FindByConditionFull(x => x.GenderId == genderId)
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
                    .ThenInclude(x => x.Organization)
                        .ThenInclude(x => x.OrganizationType).FirstOrDefault();

            return Ok(judoka);
        }
        // GET: api/Judoka/5
        [HttpGet("MyJudokas", Name = "MyJudokas")]
        [Authorize(Roles = "Admin, Coach")]
        public IActionResult GetMyJudokas()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            List<Judoka> judokas = db.Judoka.FindByConditionFull(x => x.UserId == Convert.ToInt32(userId)).ToList();
            return Ok(judokas);
        }

        // POST: api/Judoka
        [HttpPost]
        [Authorize(Roles = "Admin, Coach")]
        public IActionResult Post([FromBody] Judoka judoka)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            judoka.UserId = Convert.ToInt32(userId);

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
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            judoka.Id = id;
            judoka.Firstname = StringHelper.ToTitleCase(judoka.Firstname);
            judoka.Lastname = StringHelper.ToTitleCase(judoka.Lastname);

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            judoka.UserId = Convert.ToInt32(userId);

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
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_NOT_FOUND_CONST, "Judoka not Found"));

            db.Save();

            return Ok();
        }
    }
}
