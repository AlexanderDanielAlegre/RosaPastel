using Microsoft.IdentityModel.Tokens;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Decodecs : IDecodecs
    {
        public  ClaimsPrincipal getPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Encoding.UTF8.GetBytes(Constants.Secret);
                //byte[] key = Encoding.UTF8.GetBytes("testasdermsokanmornmoarnma");
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    ValidIssuer = Constants.Issuer,
                    ValidAudience = Constants.Audience,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public  Task<IPrincipal> validateToken(string token)
        {
            ClaimsPrincipal principal = getPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
                IPrincipal Iprincipal = new ClaimsPrincipal(identity);
                return Task.FromResult(Iprincipal);
            }
            catch (NullReferenceException)
            {
                return Task.FromResult<IPrincipal>(null);
            }
        }
    }




}
