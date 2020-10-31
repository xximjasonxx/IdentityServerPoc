using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataApi.Authorization
{
    public class IsViewerAuthorizationHandler : AuthorizationHandler<IsViewerAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsViewerAuthorizationRequirement requirement)
        {
            var assignedRoles = context.User.Claims.Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value)
                .ToList();

            if (assignedRoles.Any(x => x == requirement.RoleName))
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}
