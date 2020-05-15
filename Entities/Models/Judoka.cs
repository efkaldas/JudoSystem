using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Judoka
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }

        [Required(ErrorMessage = "BirthYears is required")]
        public int BirthYears { get; set; }
        public DanKyu DanKyu { get; set; }
        public int DanKyuId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public virtual List<Competitor> WeightCategories { get; set; }
        public  List<JudokaRank> rating { get; set; }
    }
}
