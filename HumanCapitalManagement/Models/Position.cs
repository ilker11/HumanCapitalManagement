using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class Position
    {
        public Position()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int PositionId { get; set; }
        public string? PositionName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
        
    }
}
