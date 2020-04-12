using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "Coach")]
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
        public IActionResult Get()
        {
            List<Judoka> judokas = db.Judoka.FindAllFull().ToList();
            return Ok(judokas);
        }

        // GET: api/Judoka/5
        [HttpGet("{id}", Name = "GetJudoka")]
        public IActionResult Get(int id)
        {
            Judoka judoka = db.Judoka.FindByConditionFull(x => x.Id == id).FirstOrDefault();
            return Ok(judoka);
        }
        // GET: api/Judoka/5
        [HttpGet("MyJudokas", Name = "MyJudokas")]
        public IActionResult GetMyJudokas()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            List<Judoka> judokas = db.Judoka.FindByConditionFull(x => x.UserId == Convert.ToInt32(userId)).ToList();
            return Ok(judokas);
        }

        // POST: api/Judoka
        [HttpPost]
        public IActionResult Post([FromBody] Judoka judoka)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            judoka.UserId = Convert.ToInt32(userId);

            judoka.Firstname = textInfo.ToTitleCase(judoka.Firstname);
            judoka.Lastname = textInfo.ToTitleCase(judoka.Lastname);

            db.Judoka.Create(judoka);
            db.Save();

            return Ok();
        }

        // PUT: api/Judoka/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Judoka judoka)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            judoka.Id = id;
            judoka.Firstname = textInfo.ToTitleCase(judoka.Firstname);
            judoka.Lastname = textInfo.ToTitleCase(judoka.Lastname);

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            judoka.UserId = Convert.ToInt32(userId);

            db.Judoka.Update(judoka);
            db.Save();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
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
