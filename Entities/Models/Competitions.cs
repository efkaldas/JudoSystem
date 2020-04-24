using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Competitions
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Description { get; set; }
        public int CompetitionsTypeId { get; set; }
        public CompetitionsType ComppetitionsType { get; set; }
        public string Place { get; set; }
        public DateTime CompetitionsDate { get; set; }
        public decimal? EntryFee { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }
        public string Regulations { get; set; }
        [Required(ErrorMessage = "CardPayment is required")]
        public bool CardPayment { get; set; }
        public List<CompetitionsJudge> Judges { get; set; }
        public List<AgeGroup> AgeGroups { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
