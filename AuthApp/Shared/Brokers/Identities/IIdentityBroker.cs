namespace AuthApp.Shared.Brokers.Identities
{
    using System;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Components;

    public interface IIdentityBroker
    {
        IdentityModel IdentityModel { get; set; }

        event EventHandler<IdentityModel> OnIdentityChanged;
    }
}
