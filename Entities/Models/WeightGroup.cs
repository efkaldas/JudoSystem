using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class WeightGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Judoka> Competitors { get; set; }
    }
}
