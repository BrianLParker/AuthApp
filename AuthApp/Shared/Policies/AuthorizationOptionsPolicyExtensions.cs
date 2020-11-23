namespace AuthApp.Shared.Policies
{
    using AuthApp.Shared.Brokers.DateTimes;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.DependencyInjection;

    public static class AuthorizationOptionsPolicyExtensions
    {
        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<IAuthorizationHandler, DobVerifiedHandler>();
            services.AddScoped<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddAuthorizationCore(options => options.ConfigurePolicies());
        }

        public static AuthorizationOptions ConfigurePolicies(this AuthorizationOptions options)
        {
            options.AddPolicy(Policies.RequireDisplayName, policy => policy.RequireClaim(CustomClaimTypes.DisplayName));
            options.AddPolicy(Policies.RequireDoB, policy => policy.RequireClaim(CustomClaimTypes.DateOfBirth));
            options.AddPolicy(Policies.Adult, policy => policy.Requirements.Add(new MinimumAgeRequirement(18)));
            options.AddPolicy(Policies.VerifiedDoB, policy => policy.Requirements.Add(new DobVerifiedRequirement(true)));
            options.AddPolicy(Policies.VerifiedAdult, policy =>
            {
                policy.Requirements.Add(new MinimumAgeRequirement(18));
                policy.Requirements.Add(new DobVerifiedRequirement(true));
            });


            return options;
        }
    }
}
