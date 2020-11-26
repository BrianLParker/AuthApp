namespace AuthApp.Client.Services
{
    using System.Threading.Tasks;
    using AuthApp.Shared.Brokers.Identities;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Components.Authorization;

    public class IdentityService
    {
        private readonly IIdentityBroker identityBroker;
        private readonly AuthenticationStateProvider authState;

        public IdentityService(IIdentityBroker identityBroker, AuthenticationStateProvider authState)
        {
            authState.AuthenticationStateChanged += AuthenticationStateChanged;
            this.identityBroker = identityBroker;
            this.authState = authState;
        }

        private void AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authenticationState = task.Result;
            identityBroker.IdentityModel = authenticationState.User.GetIdentityModel();
        }

        public async Task Update()
        {
            var authState = await this.authState.GetAuthenticationStateAsync();
            var user = authState.User;
            identityBroker.IdentityModel = user.GetIdentityModel();
        }
    }
}