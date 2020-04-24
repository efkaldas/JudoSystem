using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class CompetitionsResults
    {
        [Key]
        public int Id { get; set; }
        public int WeightCategoryId { get; set; }
        public WeightCategory WeightCategory { get; set; }
        public int JudokaId { get; set; }
        public Judoka Judoka { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }
    }
}
