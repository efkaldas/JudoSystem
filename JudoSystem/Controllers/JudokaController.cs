using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet, Authorize]
        public Response getJudokas()
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
        [HttpGet("{id}", Name = "getJudoka"), Authorize]
        public Response getJudoka(int id)
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
        public Response createJudoka([FromBody] JudokaDao newJudoka)
        {
            Response res = new Response();
            try
            {
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
        public Response updateJudoka(int id, [FromBody]JudokaDao judoka)
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
        public Response deleteJudokas(int id)
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
