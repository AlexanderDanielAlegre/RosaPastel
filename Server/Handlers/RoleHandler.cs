using Microsoft.AspNetCore.Authorization;
using Server.Interfaces;
using Server.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Handlers
{
    public class RoleHandler : AuthorizationHandler<RoleRequirment>
    {
        private readonly IDecodecs _decodecs;
        public RoleHandler(IDecodecs decodecs)
        {
            this._decodecs = decodecs;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirment requirement)
        {
            if (!context.User.HasClaim(c=> c.Type == ClaimTypes.Role))
            {
                return Task.CompletedTask;
            }
            if (context.User.HasClaim(x => x.Value == "Administratorr"))
            {
                int a = 1;
            }
          
            context.Succeed(requirement);
            //var pricipal = _decodecs.getPrincipal();
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
