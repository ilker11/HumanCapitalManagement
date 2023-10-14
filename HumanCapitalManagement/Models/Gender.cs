using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class Gender
    {
        public Gender()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
