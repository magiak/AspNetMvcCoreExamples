using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Threading.Tasks;

namespace AspNetMvcCoreExamples.Business.Security.Handlers
{
    public class ClaimsRequirementHandler : AuthorizationHandler<ClaimsAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimsAuthorizationRequirement requirement)
        {
            if (!context.User.HasClaim(requirement.ClaimType, true.ToString()))
            {
                // Unauthorized
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
