using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class Position
    {
        public Position()
        {
            Departments = new HashSet<Department>();
        }

        public int PositionId { get; set; }
        public string? PositionName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
