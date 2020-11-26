namespace AuthApp.Client.Views.Shared
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using AuthApp.Shared.Models;
    using AuthApp.Shared.Brokers.Identities;

    public partial class LoginDisplay
    {
        [Inject]
        IIdentityBroker IdentityBroker { get; set; }
        IdentityModel IdentityModel => IdentityBroker?.IdentityModel;
        private async Task BeginSignOut(MouseEventArgs args)
        {
            await SignOutManager.SetSignOutState();
            Navigation.NavigateTo("authentication/logout");
        }
    }
}