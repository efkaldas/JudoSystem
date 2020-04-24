using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Competitor
    {
        public int WeightCategoryId { get; set; }
        public WeightCategory WeightCategory { get; set; }
        public int JudokaId { get; set; }
        public Judoka Judoka { get; set; }
    }
}
