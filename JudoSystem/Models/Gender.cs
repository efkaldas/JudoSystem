using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TextLT { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public int TextEN { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public int TextRU { get; set; }
    }
}
