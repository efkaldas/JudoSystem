using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserStatus
    {
        public static readonly int STATUS_APPROVED = 1;
        public static readonly int STATUS_NOT_APPROVED = 2;
        public static readonly int STATUS_BLOCKED = 3;

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "StatusNameEN is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string StatusNameEN { get; set; }
        [Required(ErrorMessage = "StatusNameLT is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string StatusNameLT { get; set; }
        [Required(ErrorMessage = "StatusNameRU is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string StatusNameRU { get; set; }
    }
}
