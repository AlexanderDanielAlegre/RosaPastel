using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PracticeV2.Bussines.Dtos;
using PracticeV2.Bussines.Interfaces;
using Server;
using Server.Common;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IDecodecs _decodecs;
        public LoginController(IUserRepository userRepository,IDecodecs decodecs)
        {
            _userRepository = userRepository;
            _decodecs = decodecs;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] EmployeeDto user)
        {
            // var usuario = user;
            //lamar service

            var UserAuth = _userRepository.Login(user.Name, user.Password);
            var single = UserAuth.Result.FirstOrDefault();

            if (single == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "some_id"),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Password),
                new Claim(ClaimTypes.Role,"Administrator"),
                new Claim("AuthNeces","cookie")
            };

            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var singningCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(

                Constants.Audience,
                Constants.Issuer,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                singningCredentials

                );
            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponse loginResponse = new();

            loginResponse.success = true;
            loginResponse.token = tokenJson;
            return Ok(loginResponse);


        }
        [HttpGet]
        [Route("getauth")]

        public IActionResult Decode([FromHeader(Name = "Authorization")] string token)
        {
            string accessTokenWithoutBearerPrefix = token.Substring("Bearer ".Length);
            var ret = _decodecs.getPrincipal(accessTokenWithoutBearerPrefix);
            return Ok();    
        }
        [Authorize(Policy = "RoleAdmin")]
        [HttpGet]
        public IActionResult LoginGet()
        {

            var r =((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            var b = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Role);
            //var s = ((ClaimsPrincipal)User.Claims).FindFirst(ClaimTypes.Role);
            //var s = (User.Claims).Where(z=> z.Type == ClaimTypes.Role);
            //var s = (User.Claims).First(z=> z.Type == ClaimTypes.Role).Value;

            return Ok(r == null ? "" : r.Value);
        }

    }
}
