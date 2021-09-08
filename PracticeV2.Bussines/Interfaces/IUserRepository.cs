using PracticeV2.Bussines.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Bussines.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllUsers();

        Task<IEnumerable<EmployeeDto>> GetUser(string name, string pass);

        Task<IEnumerable<EmployeeDto>> Login(string name, string pass);
    }
}
