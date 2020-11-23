namespace ClaimsBasedAuth.Server.Controllers
{
    using AuthApp.Server.Models;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(Roles = Roles.Administrator)]
    [ApiController]
    [Route("[controller]")]
    public class AdminWeatherForecastController : BaseWeatherForecastController<AdminWeatherForecastController>
    {
        public AdminWeatherForecastController(ILogger<AdminWeatherForecastController> logger, UserManager<ApplicationUser> userManager)
            : base(logger, 10, userManager, Summaries) { }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
