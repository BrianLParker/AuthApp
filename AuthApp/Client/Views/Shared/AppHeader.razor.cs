namespace AuthApp.Client.Views.Shared
{
    using System;
    using Microsoft.AspNetCore.Components;
    using AuthApp.Shared.Models;
    using AuthApp.Shared.Brokers.Identities;

    public partial class AppHeader
    {
        [Inject]
        IIdentityBroker IdentityBroker { get; set; }
        IdentityModel IdentityModel => IdentityBroker?.IdentityModel;
        string Greating
        {
            get
            {
                var hour = DateTime.Now.Hour;
                if (hour > 18)
                    return "Good Evening";
                if (hour > 12)
                    return "Good Afternoon";
                if (hour > 10)
                    return "Hello";
                return "Good Morning";
            }
        }
    }
}