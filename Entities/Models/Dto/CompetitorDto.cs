using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Dto
{
    public class CompetitorDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string WeightCategory { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Club { get; set; }
        public string AgeGroup { get; set; }
    }
}
