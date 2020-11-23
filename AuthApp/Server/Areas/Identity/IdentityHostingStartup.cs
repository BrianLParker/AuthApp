using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AuthApp.Server.Areas.Identity.IdentityHostingStartup))]
namespace AuthApp.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}