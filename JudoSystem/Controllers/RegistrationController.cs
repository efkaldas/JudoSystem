using System;
using JudoSystem.Helpers;
using JudoSystem.Models;
using JudoSystem.Services;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        static IUserSql userSql = new UserSql();

        // POST: api/Registration
        [AllowAnonymous]
        [HttpPost]
        public Response Register([FromBody]UserDao userDao)
        {
            Response response = new Response();
            try
            {
                RegistrationService service = new RegistrationService();

                userDao.Password = StringHelper.HashPassword(userDao.Password);

                if (service.IsFormValid(userDao))
                {
                    userSql.InsertUser(userDao);
                }

                response.success(userDao);
            }
            catch (Exception e)
            {
                response.error(e.Message);
            }
            return response;
        }
    }
}
