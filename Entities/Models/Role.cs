using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public partial class Role
    {
        public static readonly int ADMIN = 1;
        public static readonly int ORGANIZATION_ADMIN = 2;
        public static readonly int COACH = 3;
        public static readonly int JUDGE = 4;
        public Role()
        {
        }
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
        public virtual List<UserRole> UserRoles{ get; set; }

    }
}
