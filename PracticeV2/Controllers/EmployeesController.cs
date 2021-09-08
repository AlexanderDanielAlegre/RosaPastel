using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeV2.Bussines.Common;
using PracticeV2.Bussines.Dtos;
using PracticeV2.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _employeeService;
        public UserController(IUserService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("Employees")]
        public async Task<ActionResult<ServiceResponse<EmployeeDto>>> GetEmployees()
        {
            var response = await _employeeService.GetAllUsers();
            if (!response.IsSuccesful)
            {
                return StatusCode(StatusCodes.Status400BadRequest, response.ErrorMessage);
            }
            return Ok(response.Result);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] EmployeeDto user)
        {
            // var usuario = user;
            //lamar service

            var UserAuth = await _employeeService.GetUser(user.Name, user.Password);
            var single = UserAuth.Result.FirstOrDefault();

            if (single == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok(single);
        }
    }
}
