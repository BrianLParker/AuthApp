namespace AuthApp.Client.Views.Pages
{
    using AuthApp.Client.Models;
    using AuthApp.Shared.Models;

    public partial class AdultsOnly : BaseFetchData<WeatherForecast>
    {
        public AdultsOnly() : base("AdultWeatherForecast") { }
    }
}