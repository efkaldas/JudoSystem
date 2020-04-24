using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class AgeGroup
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Title { get; set; }
        public int CompetitonsId { get; set; }
        public Competitions Competitions { get; set; }
        public int GenderId { get; set; }
        public Gender gender { get; set; }
        [Required(ErrorMessage = "YearsFrom is required")]
        public int YearsFrom { get; set; }
        [Required(ErrorMessage = "YearsTo is required")]
        public int YearsTo { get; set; }
        [Required(ErrorMessage = "DankKyuFrom is required")]
        public int DanKyuFrom { get; set; }
        [Required(ErrorMessage = "DankKyuTo is required")]
        public int DanKyuTo { get; set; }
        public DateTime CompetitionsDate { get; set; }
        public DateTime WeightInFrom { get; set; }
        public DateTime WeightInTo { get; set; }
        List<WeightCategory> WeightCategories { get; set; }
    }
}
