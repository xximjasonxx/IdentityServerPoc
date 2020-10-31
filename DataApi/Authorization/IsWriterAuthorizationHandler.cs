using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataApi.Authorization
{
    public class IsWriterAuthorizationHandler : AuthorizationHandler<IsWriterAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsWriterAuthorizationRequirement requirement)
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
