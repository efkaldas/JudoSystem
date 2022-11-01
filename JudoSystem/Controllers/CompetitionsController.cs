using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Aspose.BarCode.Generation;
using BarcodeLib;
using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Helpers;
using JudoSystem.Interfaces;
using JudoSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SautinSoft.Document;

namespace JudoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private IRepositoryWrapper db;
        private readonly IConfiguration configuration;
        private readonly IEmailSendService _emailSendService;
        public CompetitionsController(IConfiguration configuration, IRepositoryWrapper repoWrapper, IEmailSendService emailSendService)
        {
            this.configuration = configuration;
            db = repoWrapper;
            _emailSendService = emailSendService;
        }
        // GET: api/Competitions
        [HttpGet]
        public IActionResult Get()
        {
            var competitions = db.Competitions.FindAll().ToList();
            return Ok(competitions);
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("{id}/Competitors-list.csv", Name = "GetCompetitorsList")]
        public IActionResult GetCompetitors(int id)
        {
            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                    .Include(x => x.AgeGroups)
                        .ThenInclude(x => x.WeightCategories)
                            .ThenInclude(x => x.Competitors)
                                .ThenInclude(x => x.Judoka)
                                    .ThenInclude(x => x.User)
                                        .ThenInclude(x => x.Organization)
                     .Include(x => x.AgeGroups)
                        .ThenInclude(x => x.WeightCategories)
                            .ThenInclude(x => x.Competitors)
                                .ThenInclude(x => x.Judoka).FirstOrDefault();

            CompetitorsListService export = new CompetitorsListService();
            string file = export.Execute(competitions);

            return File(System.IO.File.OpenRead(file), "text/csv;charset=utf-8");

        }

        // GET: api/Competitions/5
        [HttpGet("{id}", Name = "GetCompetitions")]
        public IActionResult Get(int id)
        {
            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                .Include(x => x.Judges)
                .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                .FirstOrDefault();
            return Ok(competitions);
        }
        // GET: api/Competitions/5
        [Authorize(Roles = "Admin, Coach")]
        [HttpGet("{id}/MyCompetitors", Name = "GetMyCompetitors")]
        public IActionResult GetMyCompetitors(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                        .ThenInclude(x => x.Competitors)
                            .ThenInclude(x => x.Judoka)
                 .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                        .ThenInclude(x => x.Competitors)
                            .ThenInclude(x => x.Judoka)
                                .ThenInclude(x => x.DanKyu).FirstOrDefault();

            List<Judoka> competitors = competitions.AgeGroups.SelectMany(x => x.WeightCategories).SelectMany(x => x.Competitors).Where(x => x.Judoka.UserId == userId).Select(x => x.Judoka).ToList();

            return Ok(competitors);
        }
        // GET: api/Competitions/5
        [HttpGet("{id}/AgeGroups", Name = "GetCompetitionsАgeGroups")]
        public IActionResult GetAgeGroups(int id)
        {
            List<AgeGroup> ageGroups = db.AgeGroup.FindByCondition(x => x.CompetitionsId == id).ToList();
            return Ok(ageGroups);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/ResultsFile", Name = "ImportResultsFile")]
        public IActionResult ImportResultsFile(int id, [FromHeader]IFormFile file)
        {
            var httpRequest = HttpContext.Request;
            if (httpRequest.Form.Files.Count == 0)
            {
                return null;
            }
            string localFileLocation = Path.GetTempPath() + file.FileName;

            if (System.IO.File.Exists(localFileLocation))
                System.IO.File.Delete(localFileLocation);

            if (file.ContentType.ToString() == "application/pdf")
            {
                using (var fileStream = new FileStream(localFileLocation, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            if (System.IO.File.Exists(localFileLocation))
            {
                ResultsFileReaderService service = new ResultsFileReaderService();

                return Ok();
            }
            return null;
        }

        // POST: api/Competitions
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] Competitions competitions)
        {
            competitions.DateCreated = DateTime.Now;
            db.Competitions.Create(competitions);
            db.Save();
            return Ok(competitions);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/RegulationsFile", Name = "ImportRegulationsFile")]
        public IActionResult ImportRegulationsFile(int id, [FromHeader]IFormFile file)
        {
            var competitions = db.Competitions.FindByCondition(x => x.Id == id).Single();
            var httpRequest = HttpContext.Request;
            if (httpRequest.Form.Files.Count == 0)
            {
                return null;
            }
            string localFileLocation = Path.GetTempPath() + file.FileName;

            if (System.IO.File.Exists(localFileLocation))
                System.IO.File.Delete(localFileLocation);

            if (file.ContentType.ToString() == "application/pdf")
            {
                using (var fileStream = new FileStream(localFileLocation, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var users = db.User.FindAll();

            if (System.IO.File.Exists(localFileLocation))
            {
                competitions.Regulations = localFileLocation;
                db.Competitions.Update(competitions);
                _emailSendService.SendEmail(DateTime.Now.ToString("yyyy-MM-dd") + " Varžybų protokolai!", "", users.Select(x => x.Email).ToList(), localFileLocation);

                return Ok();
            }
            return null;
        }

        // PUT: api/Competitions/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id).FirstOrDefault();
            db.Competitions.Delete(competitions);
            db.Save();
            return Ok();
        }

        // GET: api/Competitions
        [HttpGet("{id}/MyCompetitors/PDF", Name = "GetMycompetitorsPDF")]
        public IActionResult GetMycompetitorsPDF(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == id)
                .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                        .ThenInclude(x => x.Competitors)
                            .ThenInclude(x => x.Judoka)
                 .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                        .ThenInclude(x => x.Competitors)
                            .ThenInclude(x => x.Judoka)
                                .ThenInclude(x => x.DanKyu).FirstOrDefault();

            List<Competitor> competitors = competitions.AgeGroups.SelectMany(x => x.WeightCategories).SelectMany(x => x.Competitors).Where(x => x.Judoka.UserId == userId).ToList();

            var html = "<html><style>table { table-layout: fixed; width: 100px; }, td { border: 1px solid black;}</style><div><table cellspacing=\"0\" cellpadding=\"10\">";
            var trEnd = "</tr>";

            var i = 1;
            var row = "<tr>";
            var fullRow = string.Empty;

            foreach (var competitor in competitors)
            {
                Barcode b = new BarcodeLib.Barcode();
                Image barcode = b.Encode(BarcodeLib.TYPE.CODE128, competitor.JudokaId.ToString("D5"), 127, 50);             

                System.IO.MemoryStream ms = new MemoryStream();
                barcode.Save(ms, ImageFormat.Bmp);
                byte[] byteImage = ms.ToArray();
                var barcodeBase64 = Convert.ToBase64String(byteImage);

                var column = 
                    $"<td>" +
                    $"<h2> { competitor.Judoka.Firstname } { competitor.Judoka.Lastname } </h2>" +
                    $"<p> { competitor.WeightCategory.AgeGroup.Title } </p>" +
                    $"<p> { competitor.WeightCategory.Title } </p>" +
                    $"<p><img src=\"data:image/png;base64,{ barcodeBase64 }\" /></p>" +
                    "</td>";

                fullRow += column;

                if (i % 4 == 0 || competitors.Count == i)
                {
                    fullRow = row + fullRow + trEnd;
                    html += fullRow;
                    fullRow = string.Empty;
                }
                i++;
            }
            html += "</table></div></html>";

            var file = PDFHelper.ConvertHtmlToBytesPdf(html);

            return File(file, "application/pdf;charset=utf-8");
        }

    }
}
