using System;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using JudoSystem.Helpers;
using JudoSystem.Models;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public RegistrationController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }

        // POST: api/Registration
        [AllowAnonymous]
        [HttpPost]
   //     [ServiceFilter(typeof(ValidateForm))]
        public IActionResult Register([FromBody]User user)
        {

            user.Password = StringHelper.HashPassword(user.Password);

            if (db.User.FindByCondition(x => x.Email == user.Email).FirstOrDefault() != null)
                return new ConflictObjectResult(ErrorDetails.HTTP_STATUS_ENTITY_EXISTS);

            if (db.User.FindByCondition(x => x.Organization.ExactName == user.Organization.ExactName).FirstOrDefault() != null)
                return new ConflictObjectResult(ErrorDetails.HTTP_STATUS_ENTITY_EXISTS);

            db.Organization.Create(user.Organization);
            db.Save();

            db.User.Create(user);
            db.Save();

            return Ok(user);


        }
    }
}
