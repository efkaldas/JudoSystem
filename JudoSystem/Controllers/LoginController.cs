using System;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Models;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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