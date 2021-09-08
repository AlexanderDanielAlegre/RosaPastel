using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeV2.Infraestructure.Data
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<User> Employees { get; set; }
    }
}
