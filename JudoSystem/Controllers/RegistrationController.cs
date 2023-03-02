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
using JudoSystem.Interfaces;
using Enums;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IConfiguration configuration, IRepositoryWrapper repoWrapper, IRegistrationService registrationService)
        {
            this.configuration = configuration;
            db = repoWrapper;
            _registrationService = registrationService;
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
            user.UserRoles.Add(new UserRole { Type = UserType.OrganizationAdmin });

            if (user.Organization.Type == OrganizationType.Club || user.Organization.Type == OrganizationType.SportsCenter)
            {
                user.UserRoles.Add(new UserRole { Type = UserType.Coach });
            }
            else if(user.Organization.Type == OrganizationType.JudgesAssociation)
            {
                user.UserRoles.Add(new UserRole { Type = UserType.Judge });
            }

            user.BirthDate = user.BirthDate.Date;
            user.Organization.ShortName = user.Organization.ExactName;
            db.Organization.Create(user.Organization);
            db.User.Create(user);
            db.Save();

            _registrationService.SendMessage(user);

            return Ok(user);
        }
    }
}
