namespace AuthApp.Client.Views.Pages
{
    using AuthApp.Client.Models;
    using AuthApp.Shared.Models;

    public partial class FetchData : BaseFetchData<WeatherForecast>
    {
        public FetchData() : base("WeatherForecast") { }
    }
}