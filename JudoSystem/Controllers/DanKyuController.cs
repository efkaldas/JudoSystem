using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanKyuController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        public DanKyuController(IConfiguration configuration, IRepositoryWrapper repoWrapper)
        {
            this.configuration = configuration;
            db = repoWrapper;
        }
        // GET: api/DanKyu
        [HttpGet]
        public IActionResult Get()
        {
            List<DanKyu> danKyus = db.DanKyu.FindAll();
            return Ok(danKyus);
        }

        // GET: api/DanKyu/5
        [HttpGet("{id}", Name = "GetDanKyu")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST: api/DanKyu
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT: api/DanKyu/5
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
