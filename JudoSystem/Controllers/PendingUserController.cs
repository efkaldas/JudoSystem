using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PendingUserController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public PendingUserController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/PendingUser 
        [HttpGet]
        public IActionResult Get()
        {
            List<User> notApprovedUsers = db.User.FindByCondition(x => x.Status == UserStatus.NotApproved)
                .Include(x => x.Organization).Include(x => x.UserRoles).ToList();

            return Ok(notApprovedUsers);
        }

        // GET: api/PendingUser/5
        [HttpGet("{id}", Name = "GetPendingUser")]
        public IActionResult Get(int id)
        {
            return Ok();
        }


        // PUT: api/PendingUser/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            User dbUser = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            dbUser.Status = user.Status;
            db.User.Update(dbUser);
            db.Save();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            db.User.Delete(user);
            db.Save();

            return Ok();
        }
    }
}
