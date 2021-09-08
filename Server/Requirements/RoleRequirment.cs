using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Requirements
{
    public class RoleRequirment : IAuthorizationRequirement 
    {
        public RoleRequirment(string claims)
        {
            Claims = claims;

        }
        public string Claims { get; }

    }
}
