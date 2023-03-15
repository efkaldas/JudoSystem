using System;
using System.Collections.Generic;
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

namespace JudoSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper db;
        public UserController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this.logger = logger;
            db = repository;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = db.User.FindAll()
                .Include(x => x.Organization)
                .Include(x => x.UserRoles).ToList();

            users.Remove(users.Find(x => x.Id == 1));

            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        [ServiceFilter(typeof(ValidateEntityExists<User>))]
        public IActionResult Get(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id)
                .Include(x => x.Organization)
                .Include(x => x.UserRoles).FirstOrDefault();
           // User user = HttpContext.Items["entity"] as User;
            return Ok(user);
        }
        // GET: api/User/5
        [HttpGet("full/{id}", Name = "GetUserWithCompany")]
        [ServiceFilter(typeof(ValidateEntityExists<User>))]
        public IActionResult GetUserWithCompany(int id)
        {
            User user = db.User.FindByCondition(x => x.Id == id)
                .Include(x => x.DanKyu)
                .Include(x => x.UserRoles)
                .Include(x => x.Organization).FirstOrDefault();
            // User user = HttpContext.Items["entity"] as User;
            return Ok(user);
        }

        [HttpGet("{id}/Judokas", Name = "Get")]
        public IActionResult GetJudokas(int id)
        {
            Judoka judoka = db.Judoka.FindByConditionFull(x => x.Id == id).FirstOrDefault();
            return Ok(judoka);
        }

        // POST: api/User
        [HttpPost]
        [ServiceFilter(typeof(ValidateForm))]
        public IActionResult Post([FromBody] User user)
        {
            db.User.Create(user);
            db.Save();

            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateForm))]
        public IActionResult Put(User user)
        {
            if (user.Id > 0)
                return new ConflictObjectResult(ErrorDetails.HTTP_STATUS_FORBIDDEN);

            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            User updateUser = db.User.FindByCondition(x => x.Id == userId).FirstOrDefault();

            db.User.Update(updateUser);
            db.Save();

            updateUser.Firstname = StringHelper.ToTitleCase(user.Firstname);
            updateUser.Lastname = StringHelper.ToTitleCase(user.Lastname);
            updateUser.BirthDate = user.BirthDate;
            updateUser.Gender = user.Gender;
            updateUser.DanKyuId = user.DanKyuId;
            updateUser.Email = user.Email;
            updateUser.PhoneNumber = user.PhoneNumber;
            updateUser.Password = StringHelper.HashPassword(user.Password);

            updateUser.DateUpdated = DateTime.Now;

            db.User.Update(updateUser);
            db.Save();

            return Ok();
        }

        // PUT: api/User/5
        [HttpPost("UploadProfileImage")]
        [ServiceFilter(typeof(ValidateForm))]
        public IActionResult UploadImage([FromBody]string imagePath)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            User updateUser = db.User.FindByCondition(x => x.Id == userId).FirstOrDefault();
            updateUser.Image = imagePath;

            db.User.Update(updateUser);
            db.Save();

            return Ok();
        }
    }
}
