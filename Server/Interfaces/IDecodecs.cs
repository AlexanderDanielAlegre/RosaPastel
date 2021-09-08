using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface IDecodecs
    {
        ClaimsPrincipal getPrincipal(string token);

        Task<IPrincipal> validateToken(string token);
    }
}
