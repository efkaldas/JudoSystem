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
    [Authorize(Roles = "Coach")]
    public class CoachController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public CoachController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/Coach
        [HttpGet]
        public IActionResult Get()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
            List<User> coaches = db.User.FindByCondition(x => x.ParentUserId == userId).Include(x => x.DanKyu).Include(x => x.Gender)
                .Include(x => x.Status).ToList();
            return Ok(coaches);
        }

        // GET: api/Coach/5
        [HttpGet("{id}", Name = "GetCoach")]
        public IActionResult Get(int id)
        {
           User coach = db.User.FindByCondition(x => x.Id == id)
                .Include(x => x.Gender)
                .Include(x => x.DanKyu)
                .Include(x => x.Organization)
                .Include(x => x.Judokas)
                    .ThenInclude(x => x.Gender)
                .Include(x => x.Judokas)
                    .ThenInclude(x => x.DanKyu)
                .Include(x => x.ParentUser)
                .Include(x => x.Organization.OrganizationType)
                .FirstOrDefault();

            return Ok(coach);
        }

        // POST: api/Coach
        [HttpPost]
        public IActionResult Post([FromBody] User coach)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
            User user = db.User.FindByCondition(x => x.Id == userId).Include(x => x.Organization).FirstOrDefault();
            coach.OrganizationId = user.Organization.Id;
            coach.ParentUserId = user.Id;
            db.User.Create(coach);
            db.Save();
            return Ok();
        }

        // PUT: api/Coach/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User coach)
        {
            User user = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            user.StatusId = coach.StatusId;
            db.User.Update(user);
            db.Save();
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
