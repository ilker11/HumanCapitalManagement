using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HumanCapitalManagement.Models
{
    public partial class Login
    {
        public int LoginId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Username { get; set; } 
        [Required]
        public string PasswordHash { get; set; } 
        public int? EmployeeId { get; set; }
        public int? RoleId { get; set; }

        public virtual EmployeeInfo? Employee { get; set; }
        public virtual Role RoleName { get; set; }
    }
}
