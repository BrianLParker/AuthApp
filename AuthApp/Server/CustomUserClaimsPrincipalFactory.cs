namespace AuthApp.Server
{
    using System.Security.Claims;
    using System.Text.Json;
    using System.Threading.Tasks;
    using AuthApp.Server.Models;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;

    public class CustomUserClaimsPrincipalFactory
         : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            ClaimsPrincipal principal = await base.CreateAsync(user);

            var identity = (ClaimsIdentity)principal.Identity;

            identity.AddClaim(new Claim(CustomClaimTypes.DateOfBirthVerified, JsonSerializer.Serialize(user.DateOfBirthVerified)));

            if (user.DateOfBirth.HasValue)
            {
                identity.AddClaim(new Claim(CustomClaimTypes.DateOfBirth, JsonSerializer.Serialize(user.DateOfBirth)));
            }

            if (!string.IsNullOrWhiteSpace(user.DisplayName))
            {
                identity.AddClaim(new Claim(CustomClaimTypes.DisplayName, user.DisplayName));
            }

            return principal;
        }
    }
}
