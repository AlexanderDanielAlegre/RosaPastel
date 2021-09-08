using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeV2.Bussines.Dtos;
using PracticeV2.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController : ControllerBase
    {
       
        private readonly IUserRepository _userRepository;
        public MateriaPrimaController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        //TODO make Method async
        public async Task<IActionResult> Getusertest([FromBody] EmployeeDto user)
        {
            // var usuario = user;
            var UserAuth = _userRepository.Login(user.Name, user.Password);
           var single = UserAuth.Result.FirstOrDefault();

            if (single == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return Ok(single);

        }
    }
}
