using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string RoleNameEN { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string RoleNameLT { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string RoleNameRU { get; set; }

        List<User> User { get; set; }
    }
}
