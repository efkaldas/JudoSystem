using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class JudgeController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public JudgeController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/Judge
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = db.User.FindAll()
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .Include(x => x.DanKyu)
                .Include(x => x.Status).ToList();

            List<User> coaches = users.Where(x => x.UserRoles.Where(x => x.RoleId == Role.JUDGE) != null).ToList();

            return Ok(coaches);
        }


        // PUT: api/Judge/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }
        [HttpGet("My", Name = "GetMyJudge")]
        public IActionResult GetMy()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            List<User> users = db.User.FindByCondition(x => x.ParentUserId == userId)
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .Include(x => x.DanKyu)
                .Include(x => x.Status).ToList();

            List<User> judges = users.Where(x => x.UserRoles.Where(x => x.RoleId == Role.JUDGE) != null).ToList();

            return Ok(judges);
        }

        [HttpGet("{id}", Name = "GetJudge")]
        public IActionResult GetJudge(int id)
        {
            User judge = db.User.FindByCondition(x => x.Id == id)
                 .Include(x => x.DanKyu)
                 .Include(x => x.Organization)
                 .Include(x => x.Judokas)
                     .ThenInclude(x => x.DanKyu)
                 .Include(x => x.ParentUser)
                 .Include(x => x.Organization.OrganizationType)
                 .FirstOrDefault();

            return Ok(judge);
        }

        [HttpPut("{id}/Block", Name = "BlockJudge")]
        public IActionResult Block(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            user.StatusId = UserStatus.STATUS_BLOCKED;
            db.User.Update(user);
            db.Save();
            return Ok();
        }

        [HttpPut("{id}/UnBlock", Name = "UnJudge")]
        public IActionResult UnBlock(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            user.StatusId = UserStatus.STATUS_APPROVED;
            db.User.Update(user);
            db.Save();
            return Ok();
        }
    }
}
