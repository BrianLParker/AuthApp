namespace AuthApp.Shared.Policies
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using AuthApp.Shared.Brokers.DateTimes;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Authorization;

    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        public MinimumAgeHandler(IDateTimeBroker dateTimeBroker)
        {
            DateTimeBroker = dateTimeBroker;
        }

        protected IDateTimeBroker DateTimeBroker { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == CustomClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            var claimValue = context.User.FindFirst(c => c.Type == CustomClaimTypes.DateOfBirth).Value;

            var dob = JsonSerializer.Deserialize<DateTimeOffset?>(claimValue);

            if (!dob.HasValue)
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = dob.Value;

            var calculatedAge = DateTimeBroker.GetDateTime().Date.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTimeBroker.GetDateTime().AddYears(-calculatedAge))
            {
                calculatedAge--;
            }

            if (calculatedAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
