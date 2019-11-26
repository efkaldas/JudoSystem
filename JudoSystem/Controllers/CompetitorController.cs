using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JudoSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        // GET: api/Competitors
        [HttpGet]
        public IEnumerable<string> getCompetitorList()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Competitors/5
        [HttpGet("{id}", Name = "getCompetitor")]
        public Response getCompetitor(int id)
        {
            Response res = new Response();
            return res;
        }

        // POST: api/Competitors
        [HttpPost]
        public void insertCompetitor([FromBody] string value)
        {
        }

        // PUT: api/Competitors/5
        [HttpPut("{id}")]
        public void updateCompetitor(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void deleteCompetitor(int id)
        {
        }
    }
}
