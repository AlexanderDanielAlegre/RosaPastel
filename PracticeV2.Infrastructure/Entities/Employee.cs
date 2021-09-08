using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeV2.Infrastructure.Data
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public int? Telephone { get; set; }
        public string Address { get; set; }
        public DateTime? EmploymentDate { get; set; }

        public virtual EmployeeType TypeNavigation { get; set; }
    }
}
