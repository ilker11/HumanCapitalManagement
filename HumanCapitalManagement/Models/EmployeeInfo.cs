using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            Logins = new HashSet<Login>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public int? EmployementId { get; set; }
        public int? GenderId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CityId { get; set; }
        public int? SalaryId { get; set; }
        public string? Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public virtual City? City { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual Salary? Salary { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
