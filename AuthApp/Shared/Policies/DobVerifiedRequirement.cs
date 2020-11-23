namespace AuthApp.Shared.Policies
{
    using Microsoft.AspNetCore.Authorization;

    public class DobVerifiedRequirement : IAuthorizationRequirement
    {
        public bool DobVerified { get; }

        public DobVerifiedRequirement(bool dobVerified)
        {
            DobVerified = dobVerified;
        }
    }
}
