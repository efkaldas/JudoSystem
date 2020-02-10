using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Country { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string City { get; set; }
        public int OrganizationTypeId { get; set; }
        public OrganizationType OrganizationType { get; set; }
    }
}
