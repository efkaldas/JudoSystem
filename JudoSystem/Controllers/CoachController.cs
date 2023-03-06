using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Enums;
using JudoSystem.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Tls;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public CoachController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/Coach
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            List<User> users = db.User.FindAll()
                .Include(x => x.UserRoles)
                .Include(x => x.DanKyu).ToList();

            List<User> coaches = users.Where(x => x.UserRoles.Where(x => x.Type == UserType.Coach) != null).ToList();

            return Ok(coaches);
        }
        [HttpGet("My", Name = "GetMyCoach")]
        [Authorize(Roles = "Admin, OrganizationAdmin")]
        public IActionResult GetMy()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            List<User> users = db.User.FindByCondition(x => x.ParentUserId == userId)
                .Include(x => x.UserRoles)
                .Include(x => x.DanKyu).ToList();

            List<User> coaches = users.Where(x => x.UserRoles.Where(x => x.Type == UserType.Coach) != null).ToList();

            return Ok(coaches);
        }

        // GET: api/Coach/5
        [HttpGet("{id}", Name = "GetCoach")]
        [Authorize]
        public IActionResult Get(int id)
        {
           User coach = db.User.FindByCondition(x => x.Id == id)
                .Include(x => x.DanKyu)
                .Include(x => x.Organization)
                .Include(x => x.Judokas)
                    .ThenInclude(x => x.DanKyu)
                .FirstOrDefault();

            return Ok(coach);
        }

        // POST: api/Coach
        [HttpPost]
        [Authorize(Roles = "Admin, OrganizationAdmin)]
        public IActionResult Post([FromBody] User coach)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
            User user = db.User.FindByCondition(x => x.Id == userId).Include(x => x.Organization).FirstOrDefault();
            coach.UserRoles = new List<UserRole>();
            coach.OrganizationId = user.Organization.Id;
            coach.ParentUserId = user.Id;
            coach.Password = StringHelper.HashPassword(coach.Password);
            coach.UserRoles.Add(new UserRole { Type = UserType.Coach });
            db.User.Create(coach);
            db.Save();
            return Ok();
        }

        // PUT: api/Coach/5
        [HttpPut("{id}/Block", Name = "BlockCoach")]
        [Authorize(Roles = "Admin, OrganizationAdmin")]
        public IActionResult Block(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            user.Status = UserStatus.Blocked;
            db.User.Update(user);
            db.Save();
            return Ok();
        }

        [HttpPut("{id}/UnBlock", Name = "UnBlock")]
        [Authorize(Roles = "Admin, OrganizationAdmin")]
        public IActionResult UnBlock(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            user.Status = UserStatus.Approved;
            db.User.Update(user);
            db.Save();
            return Ok();
        }
    }
}
