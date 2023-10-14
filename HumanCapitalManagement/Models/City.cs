using System;
using System.Collections.Generic;

namespace HumanCapitalManagement.Models
{
    public partial class City
    {
        public City()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
