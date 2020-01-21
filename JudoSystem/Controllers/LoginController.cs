using System;
using JudoSystem.Models;
using JudoSystem.Models.Dto;
using JudoSystem.Services;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        IUserSql userSql = new UserSql();
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public Response Login([FromBody]UserDto userDto)
        {
            Response response = new Response();
            AuthService authService = new AuthService();
            try
            {
                LoginService userService = new LoginService();
                UserDao user = userService.GetLoggedUser(userDto);
                string token = authService.GenerateToken(configuration, user);

                response.success(token);
            }
            catch (Exception e)
            {
                response.error(e.Message);
            }
            return response;
        }
    }
}