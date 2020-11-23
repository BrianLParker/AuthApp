namespace AuthApp.Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public abstract class BaseWeatherForecastController<TController> : ControllerBase where TController : BaseWeatherForecastController<TController>
    {

        private readonly ILogger<TController> logger;
        private readonly int returnQty;
        private readonly string[] weatherConditions;
        UserManager<ApplicationUser> userManager;
        public BaseWeatherForecastController(
            ILogger<TController> logger, int returnQty,
            UserManager<ApplicationUser> userManager,
            params string[] weatherConditions)
        {
            this.logger = logger;
            this.returnQty = returnQty;
            this.weatherConditions = weatherConditions;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var user = await GetUser();

            var asdas = user;
            var rng = new Random();

            return Enumerable.Range(1, returnQty)
                .Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = weatherConditions[rng.Next(weatherConditions.Length)]
                })
                .ToArray();
        }

        private async Task<ApplicationUser> GetUser()
        {
            ApplicationUser user = default;

            if (User.Identity.IsAuthenticated)
            {
                var userEmail = User.FindFirst(ClaimTypes.Email).Value;
                user = await userManager.FindByEmailAsync(userEmail);
            }

            return user;
        }
    }
}
