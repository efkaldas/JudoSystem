using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Helpers;
using JudoSystem.Interfaces;
using JudoSystem.Models;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        private readonly IAuthService _authService;
        public LoginController(IConfiguration configuration, IRepositoryWrapper repoWrapper, IAuthService authService)
        {
            this.configuration = configuration;
            db = repoWrapper;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserDto userDto)
        {
            User user = db.User.FindByCondition(x => x.Email == userDto.Email)
                .Include(x => x.UserRoles).FirstOrDefault();

            if (user == null)
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_NOT_FOUND_CONST, "Vartotojas neegzistuoja"));

            if (!StringHelper.VerifyPassword(user.Password, userDto.Password))
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_BAD_REQUEST_CONST, "Neteisingas slaptažodis"));
  
            string token = _authService.GenerateToken(configuration, user);

            return Ok(new JwtToken(token));
        }
    }
}