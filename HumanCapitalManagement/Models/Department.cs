using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class Department
    {
        public Department()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? PositionId { get; set; }
        public int? AssignmentId { get; set; }

        public virtual ProjectAssignment? Assignment { get; set; }
        public virtual Position? Position { get; set; }
        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
