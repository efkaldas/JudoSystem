using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JudoSystem.Authentication;
using JudoSystem.Models;
using JudoSystem.Models.Dto;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
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
                UserService userService = new UserService();
                if (userService.checkUser(userDto))
                {
                    string token = authService.generateToken(configuration);
                    response.success(token);
                }
                else
                {
                    response.error("Unauthorized", 401);
                }
            }
            catch (Exception e)
            {
                response.error(e.Message);
            }
            return response;
        }
    }
}