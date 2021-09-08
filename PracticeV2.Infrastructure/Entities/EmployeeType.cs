using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeV2.Infrastructure.Data
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
