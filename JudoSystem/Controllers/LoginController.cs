using System;
using System.Linq;
using System.Net;
using ActionFilters.Filters;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Helpers;
using JudoSystem.Models;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserDto userDto)
        {
            AuthService authService = new AuthService();

            User user = db.User.FindByCondition(x => x.Email == userDto.Email).Include(x => x.Role).FirstOrDefault();

            if (user == null)
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_NOT_FOUND_CONST, "User with this email not exists"));

            if (!StringHelper.VerifyPassword(user.Password, userDto.Password))
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_BAD_REQUEST_CONST, "Incorrect password"));
  
            string token = authService.GenerateToken(configuration, user);

            return Ok(new JwtToken(token));
        }
    }
}