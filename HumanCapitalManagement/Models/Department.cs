using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class Department
    {
        public Department()
        {
            Positions = new HashSet<Position>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? AssignmentId { get; set; }

        public virtual ProjectAssignment? Assignment { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
