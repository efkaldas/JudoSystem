using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Competitor
    {
        public int WeightGroupId { get; set; }
        public WeightGroup WeightGroup { get; set; }
        public int JudokaId { get; set; }
        public Judoka Judoka { get; set; }
    }
}
