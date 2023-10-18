using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class Salary
    {
        public Salary()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int SalaryId { get; set; }
        public decimal Salary1 { get; set; }
        public DateOnly Salary_Receive { get; set; }

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
