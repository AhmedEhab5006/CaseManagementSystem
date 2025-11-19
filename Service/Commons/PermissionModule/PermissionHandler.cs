using Application.UseCases.Auth;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.PermissionModule
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IAuthService _authService;

        public PermissionHandler(IAuthService authService)
        {
            _authService = authService;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var userPermissions = await _authService.GetLoggedPermissions();

            if (userPermissions.Contains(requirement.PermissionName))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

        }
    }
}


