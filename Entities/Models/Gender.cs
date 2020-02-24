using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "TextEN is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TextEN { get; set; }
        [Required(ErrorMessage = "TextLT is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TextLT { get; set; }
        [Required(ErrorMessage = "TextRU is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TextRU { get; set; }
    }
}
