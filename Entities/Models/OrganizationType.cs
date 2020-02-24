using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrganizationType : IEntity
    {
        public static readonly int TYPE_JUDGE_ASSOCIATION = 3;
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "TypeNameEN is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TypeNameEN { get; set; }
        [Required(ErrorMessage = "TypeNameLT is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TypeNameLT { get; set; }
        [Required(ErrorMessage = "TypeNameRU is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string TypeNameRU { get; set; }
    }
}
