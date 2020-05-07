
using CsvHelper;
using Entities.Models;
using Entities.Models.Dto;
using System.Collections.Generic;
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
                CompetitorDto newCompetitor = new CompetitorDto();
                newCompetitor.AgeGroup = ageGroup.Title;
                foreach (var weightCategory in ageGroup.WeightCategories)
                {
                    newCompetitor.WeightCategory = weightCategory.Title;
                    foreach (var competitor in weightCategory.Competitors)
                    {
                        newCompetitor.Id = competitor.Judoka.Id;
                        newCompetitor.Firstname = competitor.Judoka.Firstname;
                        newCompetitor.Lastname = competitor.Judoka.Lastname;
                        newCompetitor.Gender = competitor.Judoka.Gender.TextEN;
                        newCompetitor.Country = competitor.Judoka.User.Organization.Country;
                        newCompetitor.City = competitor.Judoka.User.Organization.City;
                        newCompetitor.Club = competitor.Judoka.User.Organization.ShortName;
                        competitors.Add(newCompetitor);
                    }
                }
            }
            return competitors;
        }
        private string ExportFile(string filePath, List<CompetitorDto> competitors)
        {
            using (TextWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture);
                csv.Configuration.HasHeaderRecord = true;
                csv.WriteRecords(competitors); // where values implements IEnumerable
            }
            Thread.Sleep(1000);
            return filePath;
        }
    }
}
