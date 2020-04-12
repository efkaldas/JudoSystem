using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class AgeGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CompetitonsId { get; set; }
        public Competitons Competitons { get; set; }
        public int GenderId { get; set; }
        public Gender gender { get; set; }
        public int YearsFrom { get; set; }
        public int YearsTo { get; set; }
    }
}
