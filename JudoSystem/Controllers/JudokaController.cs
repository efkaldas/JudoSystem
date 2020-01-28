using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JudoSystem.Models;
using JudoSystem.Models.Dao;
using JudoSystem.SQL.Interfaces;
using JudoSystem.SQL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudokaController : ControllerBase
    {
        static IJudokaSql judokaSql = new JudokaSql();
        // GET: api/Judoka
        [HttpGet, Authorize(Roles="Admin, User")]
        public Response GetJudokas()
        {
            Response res = new Response();
            try
            {
                List<JudokaDao> judokas = new List<JudokaDao>();
                judokas = judokaSql.getJudokas();
                res.success(judokas);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
        [HttpGet("UserJudokas", Name = "GetUserJudokas"), Authorize(Roles = "Admin, User")]
        public Response GetUserJudokas()
        {
            Response res = new Response();
            try
            {
                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                List<JudokaDao> judokas = new List<JudokaDao>();
                judokas = judokaSql.getUserJudokas(Convert.ToInt32(userId));
                res.success(judokas);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
        [HttpGet("{id}", Name = "GetJudoka"), Authorize]
        public Response GetJudoka(int id)
        {
            Response res = new Response();
            try
            {
                JudokaDao newJudoka = judokaSql.getJudokaById(id);
                res.success(newJudoka);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }


        // POST: api/Judoka
        [HttpPost, Authorize]
        public Response CreateJudoka([FromBody] JudokaDao newJudoka)
        {
            Response res = new Response();
            try
            {
                if (newJudoka.UserId != 0)
                {
                    throw new Exception("U can't do it");
                }
                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

                newJudoka.UserId = Convert.ToInt32(userId);

                judokaSql.insertJudoka(newJudoka);
                res.success(newJudoka);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }

        // PUT: api/Judoka/5
        [HttpPut("{id}"), Authorize]
        public Response UpdateJudoka(int id, [FromBody]JudokaDao judoka)
        {
            Response res = new Response();
            try
            {
                judoka.Id = id;
                judokaSql.updateJudoka(judoka);
                res.success(judoka);
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"), Authorize]
        public Response DeleteJudoka(int id)
        {
            Response res = new Response();
            try
            {
                judokaSql.deleteJudoka(id);
                res.success("Removed");
            }
            catch (Exception e)
            {
                res.error(e.Message);
            }
            return res;
        }
    }
}
