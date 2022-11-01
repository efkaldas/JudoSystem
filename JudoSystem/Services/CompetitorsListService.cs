
using CsvHelper;
using CsvHelper.Configuration;
using Entities.Models;
using Entities.Models.Dto;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using System.Threading;


namespace JudoSystem.Services
{
    public class CompetitorsListService
    {
        private string filePath = Path.GetTempPath() + "Competitors.csv";
        public string Execute(Competitions competitions)
        {
            List<CompetitorDto> competitors = SetCompetitors(competitions);
            string file = ExportFile(filePath, competitors);

            return file;
        }
        private List<CompetitorDto> SetCompetitors(Competitions competitions)
        {
            List<CompetitorDto> competitors = new List<CompetitorDto>();

            foreach (var ageGroup in competitions.AgeGroups)
            {
                string ageGroupTitle = ageGroup.Title;
                foreach (var weightCategory in ageGroup.WeightCategories)
                {
                    string weightCategoryTitle = weightCategory.Title;
                    foreach (var competitor in weightCategory.Competitors)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Id = competitor.Judoka.Id,
                            Firstname = competitor.Judoka.Firstname,
                            Lastname = competitor.Judoka.Lastname,
                            Gender = competitor.Judoka.Gender.ToString(),
                            Country = competitor.Judoka.User.Organization.Country,
                            City = competitor.Judoka.User.Organization.City,
                            Club = competitor.Judoka.User.Organization.ShortName,
                            AgeGroup = ageGroupTitle,
                            WeightCategory = weightCategoryTitle
                        });
                    }
                }
            }
            return competitors;
        }
        private string ExportFile(string filePath, List<CompetitorDto> competitors)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };
            using (TextWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, config);
                csv.WriteRecords(competitors); // where values implements IEnumerable
            }
            Thread.Sleep(1000);
            return filePath;
        }
    }
}
