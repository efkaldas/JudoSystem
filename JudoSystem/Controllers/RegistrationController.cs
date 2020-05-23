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
using System.Collections.Generic;

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
        [ServiceFilter(typeof(ValidateForm))]
        public IActionResult Register([FromBody]User user)
        {
            List<UserRole> userRoles = new List<UserRole>();

            user.Password = StringHelper.HashPassword(user.Password);

            if (db.User.FindByCondition(x => x.Email == user.Email).FirstOrDefault() != null)
                return new ConflictObjectResult(ErrorDetails.HTTP_STATUS_ENTITY_EXISTS);

            if (db.User.FindByCondition(x => x.Organization.ExactName == user.Organization.ExactName).FirstOrDefault() != null)
                return new ConflictObjectResult(ErrorDetails.HTTP_STATUS_ENTITY_EXISTS);

            if (user.UserRoles != null)
            {
                return new ConflictObjectResult(ErrorDetails.HTTP_STATUS_BAD_REQUEST);
            }

            user.UserRoles = new List<UserRole>();
            user.UserRoles.Add(new UserRole { RoleId = Role.ORGANIZATION_ADMIN });

            if (user.Organization.OrganizationTypeId == Organization.TYPE_CLUB || user.Organization.OrganizationTypeId == Organization.TYPE_SPORTS_CENTER)
            {
                user.UserRoles.Add(new UserRole { RoleId = Role.COACH });
            }
            else if(user.Organization.OrganizationTypeId == Organization.TYPE_JUDGE_ASSOCIATION)
            {
                user.UserRoles.Add(new UserRole { RoleId = Role.JUDGE });
            }

            user.BirthDate = user.BirthDate.Date;
            user.Organization.ShortName = user.Organization.ExactName;
            db.Organization.Create(user.Organization);
            db.User.Create(user);
            db.Save();

            RegistrationService registrationService = new RegistrationService();
            registrationService.SendMessage(user);

            return Ok(user);
        }
    }
}
