using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Business.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public int? Telephone { get; set; }
        public string Address { get; set; }
        public DateTime? EmploymentDate { get; set; }
    }
}
