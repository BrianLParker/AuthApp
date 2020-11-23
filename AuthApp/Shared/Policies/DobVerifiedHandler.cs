namespace AuthApp.Shared.Policies
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Authorization;

    public class DobVerifiedHandler : AuthorizationHandler<DobVerifiedRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DobVerifiedRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == CustomClaimTypes.DateOfBirthVerified))
            {
                return Task.CompletedTask;
            }

            var claimValue = context.User.FindFirst(c => c.Type == CustomClaimTypes.DateOfBirthVerified).Value;

            var isVerified = JsonSerializer.Deserialize<bool>(claimValue);

            if (isVerified)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
