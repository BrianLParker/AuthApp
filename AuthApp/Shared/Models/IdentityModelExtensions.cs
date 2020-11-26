namespace AuthApp.Shared.Models
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Text.Json;

    public static class IdentityModelExtensions
    {
        public static IdentityModel GetIdentityModel(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return default;
            IdentityModel id = new IdentityModel();

            return user.UpdateIdentityModel( id);
        }

        public static string GetUserDisplayName(this IdentityModel identityModel)
        {
            return string.IsNullOrWhiteSpace(identityModel.DisplayName) ? 
                identityModel.Email : 
                identityModel.DisplayName;
        }

        public static IdentityModel UpdateIdentityModel(this ClaimsPrincipal user, IdentityModel id)
        {
            id.DisplayName = user.FindFirst(CustomClaimTypes.DisplayName)?.Value ?? "";
            if (user.Claims.Any(a => a.Type.Equals(CustomClaimTypes.DateOfBirth)))
            {
                id.DateOfBirth = user.GetJsonClaim<DateTimeOffset?>(CustomClaimTypes.DateOfBirth);
            }
            id.DateOfBirthConfirmed = user.GetJsonClaim<bool>(CustomClaimTypes.DateOfBirthVerified);


            if (user.Claims.Any(a => a.Type.Equals("role")))
            {
                id.Roles = user.Claims.Where(a => a.Type.Equals("role")).Select(a => a.Value).ToList();
            }
            else
            {
                id.Roles = Array.Empty<string>();
            }

            if (user.FindFirst("sub") == null)
            {
                id.Email = user.FindFirst(ClaimTypes.Email)?.Value ?? "";
                id.UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            }
            else
            {
                id.Email = user.FindFirst("email")?.Value ?? "";
                id.UserId = user.FindFirst("sub")?.Value ?? "";
            }
            return id;
        }

        public static T GetJsonClaim<T>(this ClaimsPrincipal user, string claimType) =>
            JsonSerializer.Deserialize<T>(user.FindFirst(claimType)?.Value ?? "");

        public static Guid GetUserId(this IdentityModel identityModel) => Guid.Parse(identityModel.UserId);
    }
}
