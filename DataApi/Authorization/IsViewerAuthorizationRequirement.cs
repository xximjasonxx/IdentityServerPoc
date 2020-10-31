using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApi.Authorization
{
    public class IsViewerAuthorizationRequirement : IAuthorizationRequirement
    {
        public string RoleName => "Viewer";
    }
}
