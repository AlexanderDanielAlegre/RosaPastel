using PracticeV2.Bussines.Common;
using PracticeV2.Bussines.Dtos;
using PracticeV2.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Bussines.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _employeeRepository;
        public UserService(IUserRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetAllUsers()
        {
            ServiceResponse<IEnumerable<EmployeeDto>> response = new();
            var result = await _employeeRepository.GetAllUsers();
            if (!result.Any())
            {
                response.IsSuccesful = false;
                response.ErrorMessage = "Cannot get all the Employees";
                return response;
            }
            response.IsSuccesful = true;
            response.Result = result;

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetUser(string name, string pass)
    {
            ServiceResponse<IEnumerable<EmployeeDto>> response = new();
            var result = await _employeeRepository.Login(name, pass);
            if (!result.Any())
            {
                response.IsSuccesful = false;
                response.ErrorMessage = "Cannot get all the Employees";
                return response;
            }
            response.IsSuccesful = true;
            response.Result = result;

            return response;
        }

    }
}
