using System;
using Entities;
using Entities.Models;
using JudoSystem.Helpers;
using JudoSystem.Models;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly JudoDbContext db;
        public RegistrationController(JudoDbContext context)
        {
            db = context;
        }

        // POST: api/Registration
        [AllowAnonymous]
        [HttpPost]
        public Response Register([FromBody]User user)
        {
            Response response = new Response();
            try
            {
                RegistrationService service = new RegistrationService();

                user.Password = StringHelper.HashPassword(user.Password);

                if (service.IsFormValid(user, db))
                {
                    db.User.Add(user);
                    db.SaveChanges();
                }

                response.success(user);
            }
            catch (Exception e)
            {
                response.error(e.Message);
            }
            return response;
        }
    }
}
