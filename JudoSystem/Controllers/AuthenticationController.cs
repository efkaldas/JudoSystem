using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Helpers;
using JudoSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        private readonly IAuthService _authService;
        public AuthenticationController(IConfiguration configuration, IRepositoryWrapper repoWrapper, IAuthService authService)
        {
            this.configuration = configuration;
            db = repoWrapper;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserDto userDto)
        {
            User user = db.User.FindByCondition(x => x.Email == userDto.Email).Include(x => x.Status)
                .Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefault();

            if (user == null)
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_NOT_FOUND_CONST, "Vartotojas neegzistuoja"));

            if (!StringHelper.VerifyPassword(user.Password, userDto.Password))
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_BAD_REQUEST_CONST, "Neteisingas slaptažodis"));

            string token = _authService.GenerateToken(configuration, user);

            return Ok(new JwtToken(token));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgotPassword([FromBody]ForgotPasswordRequest forgotPasssword)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _authService.ForgotPassword(forgotPasssword);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResetPassword([FromBody]ResetPasswordRequest resetPassword)
        {
            var user = db.User.FindByCondition(x => x.ResetToken == resetPassword.Token && x.ResetTokenExpires > DateTime.UtcNow).FirstOrDefault();

            if (user == null)
                return new NotFoundObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_BAD_REQUEST_CONST, "Invalid Token"));

            // update password and remove reset token
            user.Password = StringHelper.HashPassword(resetPassword.Password);
            user.ResetToken = null;
            user.ResetTokenExpires = null;

            db.User.Update(user);
            db.Save();

            return Ok();
        }
    }
}
