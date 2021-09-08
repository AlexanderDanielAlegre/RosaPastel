using Microsoft.EntityFrameworkCore;
using PracticeV2.Bussines.Dtos;
using PracticeV2.Bussines.Interfaces;
using PracticeV2.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PracticeContext _context;
        public UserRepository(PracticeContext context)
        {
            _context = context; 
        }
        public async Task <IEnumerable<EmployeeDto>> GetAllUsers()
        {
            var result = await _context.Employees.Select(emp => new EmployeeDto
                {
                    Name = emp.Name,
                    Address= emp.Address
                    ,Telephone = emp.Telephone
                    ,EmploymentDate = emp.EmploymentDate
                    ,Type = emp.Type
                    ,Id = emp.Id
                }).ToListAsync();

            return result;
        }
        public async Task<IEnumerable<EmployeeDto>> GetUser(string name, string pass)
        {
            var result = await _context.Employees.Where(x=> x.Name== name && x.Password == pass).Select(emp => new EmployeeDto
            {
                Name = emp.Name,
                Address = emp.Address,
                Telephone = emp.Telephone,
                EmploymentDate = emp.EmploymentDate,
                Type = emp.Type,
                Id = emp.Id
            }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<EmployeeDto>> Login(string name, string pass)
        {
            var result = await _context.Employees.Where(x => x.Name == name && x.Password == pass).Select(emp => new EmployeeDto
            {
                Name = emp.Name,
                Address = emp.Address,
                Telephone = emp.Telephone,
                EmploymentDate = emp.EmploymentDate,
                Type = emp.Type,
                Id = emp.Id
            }).ToListAsync();

            return result;
        }

    }
}
