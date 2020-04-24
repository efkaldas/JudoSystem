using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class CompetitionsType
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Title  { get; set; }
        public int Points { get; set; }
    }
}
