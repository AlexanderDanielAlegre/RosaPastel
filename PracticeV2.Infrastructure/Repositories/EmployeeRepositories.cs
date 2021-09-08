using PracticeV2.Business.Dtos;
using PracticeV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Infrastructure.Repositories
{

    public class EmployeeRepositories
    {
        private readonly PracticeContext _context;
        public EmployeeRepositories(PracticeContext context)
        {
            _context = context;
        }
        public IEnumerable<EmployeeDto> GetallEmployees()
        {
            var response = _context.Employees.Select(x => new EmployeeDto
            {
                Name = x.Name,
                Address = x.Address,
                Type = x.Type,
                Id = x.Id,
                Telephone = x.Telephone,
                EmploymentDate = x.EmploymentDate
            });
            ;


            return response;
        }
    }
}
