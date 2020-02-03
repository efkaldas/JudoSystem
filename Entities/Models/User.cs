﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public int RoleId { get; set; }
        public User ParentUser { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Firstname { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Lastname { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string PhoneNumber { get; set; }
        public UserStatus Status { get; set; }
        public int StatuId { get; set; }
        public Organization Organization { get; set; }
        public int? OrganizationId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        [StringLength(250)]
        public string Password { get; set; }
        [Timestamp]
        public DateTime DateCreated { get; set; }
        [Timestamp]
        public DateTime DateUpdated { get; set; }
    }
}