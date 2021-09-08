using PracticeV2.Bussines.Common;
using PracticeV2.Bussines.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Bussines.Interfaces
{
   public  interface IUserService
    {
        Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetAllUsers();

        Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetUser(string name, string pass);


    }
}
