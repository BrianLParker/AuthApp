namespace AuthApp.Client.Views.Pages
{
    using AuthApp.Client.Models;
    using AuthApp.Shared.Models;

    public partial class AdminsOnly : BaseFetchData<WeatherForecast>
    {
        public AdminsOnly() : base("AdminWeatherForecast") { }
    }
}