using System;
using JudoSystem.Models;
using JudoSystem.Models.Contexts;
using JudoSystem.Models.Dto;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly JudoDbContext db;
        //public LoginController(JudoDbContext context)
        //{
        //    db = context;
        //}
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration, JudoDbContext context)
        {
            this.configuration = configuration;
            db = context;
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
                User user = userService.GetLoggedUser(userDto, db);
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