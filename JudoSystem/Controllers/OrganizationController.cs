//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using JudoSystem.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace JudoSystem.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrganizationController : ControllerBase
//    {
//        IUserSql userSql = new UserSql();
//        IOrganizationSql organizationSql = new OrganizationSql();

//        // GET: api/Organization
//        [HttpGet]
//        public Response Get()
//        {
//            Response res = new Response();
//            try
//            {
//                List<OrganizationDao> organization = organizationSql.GetOrganizations();
//                res.success(organization);
//            }
//            catch (Exception e)
//            {
//                res.error(e.Message);
//            }
//            return res;
//        }

//        // GET: api/Organization/5
//        [HttpGet("{id}", Name = "Get")]
//        public Response Get(int id)
//        {
//            Response res = new Response();
//            try
//            {
//                OrganizationDao organization = organizationSql.GetOrganization(id);
//                res.success(organization);
//            }
//            catch (Exception e)
//            {
//                res.error(e.Message);
//            }
//            return res;

//        }

//        // POST: api/Organization
//        [HttpPost, Authorize(Roles = "Admin, User")]
//        public Response Post([FromBody] OrganizationDao data)
//        {
//            Response res = new Response();
//            try
//            {
//                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

//                if (string.IsNullOrEmpty(userId))
//                    throw new Exception("You don't have permissions to add organization");

//                UserDao user = userSql.GetUser(Convert.ToInt32(userId));

//                if (user.OrganizationId > 0)
//                    throw new Exception("You can't add second organization");

//                int organizationId = organizationSql.InsertOrganization(data);
//                user.OrganizationId = organizationId;
//                userSql.UpdateUser(user);

//                res.success(data);
//            }
//            catch (Exception e)
//            {
//                res.error(e.Message);
//            }
//            return res;
//        }

//        // PUT: api/Organization/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
