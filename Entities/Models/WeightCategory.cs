using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class WeightCategory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Title { get; set; }
        public int AgeGroupId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public List<Competitor> Competitors { get; set; }
        public List<CompetitionsResults> Results { get; set; }
    }
}
