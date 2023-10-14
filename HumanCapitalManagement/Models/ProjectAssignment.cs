using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class ProjectAssignment
    {
        public ProjectAssignment()
        {
            Departments = new HashSet<Department>();
        }

        public int AssignmentId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string? ProjectDescription { get; set; }
        public DateOnly ProjectStartDate { get; set; }
        public DateOnly? ProjectEndDate { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
