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
        public static readonly int ROLE_COACH = 3;
        public static readonly int ROLE_JUDGE = 4;
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
