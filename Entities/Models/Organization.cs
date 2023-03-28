using Enums;
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
        public Country Country { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string City { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Address { get; set; }
        public List<User> Users { get; set; }
        public byte[] Image { get; set; }
        public OrganizationType Type { get; set; }
    }
}
