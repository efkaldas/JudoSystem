using Contracts.Interfaces;
using Entities.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class ResultsFileReaderService
    {
        public void execute(IRepositoryWrapper db, int eventId, string path)
        {
            Competitions competitions = GetCompetitions(db, eventId);
            List<string> pages = PdfText(path);

            List<CompetitionsResults> competitionsResults = GetResults(pages, competitions, db);

            db.CompetitionsResults.FindAll();


            db.CompetitionsResults.Create(competitionsResults[0]);

            db.CompetitionsResults.CreateMany(competitionsResults);
            db.Save();
        }
        private Competitions GetCompetitions(IRepositoryWrapper db, int eventId)
        {
            Competitions competitions = db.Competitions.FindByCondition(x => x.Id == eventId)
                .Include(x => x.ComppetitionsType)
                .Include(x => x.AgeGroups)
                    .ThenInclude(x => x.WeightCategories)
                        .ThenInclude(x => x.Competitors)
                            .ThenInclude(x => x.Judoka).FirstOrDefault();

            return competitions;

        }
        private List<CompetitionsResults> GetResults(List<string> pages, Competitions competitions, IRepositoryWrapper db)
        {
            List<CompetitionsResults> result = new List<CompetitionsResults>();

            try
            {
                foreach (var page in pages)
                {
                    bool isTable = false;
                    string[] rows = page.Split('\n');
                    string category = rows.First().Split(' ').Last();
                    int count = 0;

                    foreach (var row in rows)
                    {
                        if (isTable)
                        {
                            string[] judokasData = row.Split(' ');
                            string club = row.Split(',').Last();


                            if (judokasData.Length > 3 && count < 2)
                            {
                                Competitor competitor = FindCompetitor(competitions, judokasData);
                                if (competitor == null)
                                    continue;

                                CompetitionsResults newResults = new CompetitionsResults
                                {
                                    WeightCategoryId = competitor.WeightCategoryId,
                                    JudokaId = competitor.JudokaId,
                                    Place = int.Parse(judokasData[0]),
                                    Points = CalculatePoints(int.Parse(judokasData[0]), competitions)
                                };

                                result.Add(newResults);

                                Judoka updatePoints = db.Judoka.FindByCondition(x => x.Id == competitor.JudokaId).FirstOrDefault();
                                updatePoints.Points = updatePoints.Points + newResults.Points;
                                db.Judoka.Update(updatePoints);
                            }
                            else if (count < 1)
                            {
                                count++;
                            }
                            else
                            {
                                isTable = false;
                                count = 0;
                            }
                        }
                        if (row.Equals("Pos Name"))
                            isTable = true;
                    }
                }
                db.Save();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private int CalculatePoints(int place, Competitions competitions)
        {
            int points = competitions.ComppetitionsType.Points / place;
            return points;
        }
        private Competitor FindCompetitor(Competitions competitions, string[] judokasData)
        {
            Competitor competitor = new Competitor();

            foreach (var ageGroup in competitions.AgeGroups)
            {
                foreach (var weightCateogry in ageGroup.WeightCategories)
                {
                    competitor = weightCateogry.Competitors.Find(x => x.Judoka.Firstname.ToLower() == judokasData[1].ToLower() 
                    && x.Judoka.Lastname.ToLower() == judokasData[2].TrimEnd(',').ToLower());
                    if (competitor != null)
                    {
                        return competitor;
                    }
                }
            }
            return competitor;
        }
        private List<string> PdfText(string path)
        {
            List<string> pages = new List<string>();
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text = PdfTextExtractor.GetTextFromPage(reader, page);
                pages.Add(text);
            }
            reader.Close();
            return pages;
        }
    }
}
