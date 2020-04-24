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
        [Required(ErrorMessage = "ExactName is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string ExactName { get; set; }
        [Column(TypeName = "VARCHAR(128)")]
        [StringLength(250)]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Country { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string City { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Address { get; set; }
        public string Image { get; set; }
        public int OrganizationTypeId { get; set; }
        public OrganizationType OrganizationType { get; set; }
    }
}
