namespace AuthApp.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AuthApp.Shared.Policies;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient(
                "AuthApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddScoped(
               typeof(AccountClaimsPrincipalFactory<RemoteUserAccount>),
               typeof(RolesAccountClaimsPrincipalFactory));

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AuthApp.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddPolicies();

            await builder.Build().RunAsync();
        }
    }
}
