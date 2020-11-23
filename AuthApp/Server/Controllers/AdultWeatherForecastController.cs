namespace AuthApp.Server.Controllers
{
    using AuthApp.Server.Models;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(Policy = Policies.VerifiedAdult)]
    [ApiController]
    [Route("[controller]")]
    public class AdultWeatherForecastController : BaseWeatherForecastController<AdultWeatherForecastController>
    {
        public AdultWeatherForecastController(ILogger<AdultWeatherForecastController> logger, UserManager<ApplicationUser> userManager)
            : base(logger, 7, userManager, Summaries) { }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Warm after glow", "Left wanting", "Adrenaline rush", "Whats that itch", "Diary cleared", "Number withheld", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
