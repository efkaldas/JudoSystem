using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IEntity
    {

        [Key]
        public int Id { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public User ParentUser { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int StatuId { get; set; }
        public UserStatus Status { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Password { get; set; }
        [Timestamp]
        public DateTime DateCreated { get; set; }
        [Timestamp]
        public DateTime DateUpdated { get; set; }
    }
}
