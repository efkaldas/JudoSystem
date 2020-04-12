using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public CoachController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/Coach
        [HttpGet]
        public IActionResult Get()
        {

            return Ok();
        }

        // GET: api/Coach/5
        [HttpGet("{id}", Name = "GetCoach")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST: api/Coach
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT: api/Coach/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
