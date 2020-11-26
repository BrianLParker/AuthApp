namespace AuthApp.Client.Views.Shared
{
    using System;
    using AuthApp.Shared.Brokers.Identities;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    public class IdentityManager : ComponentBase
    {
        [Inject]
        IIdentityBroker IdentityBroker { get; set; }

        [Inject]
        AuthenticationStateProvider AuthState { get; set; }
    }
}