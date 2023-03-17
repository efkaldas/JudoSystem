using Enums;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public int? ParentUserId { get; set; }
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
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }
        public int? DanKyuId { get; set; }
        public DanKyu DanKyu { get; set; }
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }
        public UserStatus Status { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Password { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        [Timestamp]
        public DateTime DateCreated { get; set; }
        [Timestamp]
        public DateTime DateUpdated { get; set; }
        public List<Judoka> Judokas { get; set; }
        public List<CompetitionsJudge> Competitions { get; set; }
    }
}
