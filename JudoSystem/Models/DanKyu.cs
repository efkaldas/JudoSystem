using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class DanKyu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Text { get; set; }
        [Column(TypeName = "VARCHAR(1024)")]
        [StringLength(1024)]
        public string Imagepath { get; set; }
    }
}
