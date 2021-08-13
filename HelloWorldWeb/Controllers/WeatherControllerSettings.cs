using HelloWorldWebApp.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWeb.Controllers
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration conf)
        {
            this.ApiKey = conf["WeatherForecast:ApiKey"];
            this.Longitude = conf["WeatherForecast:Longitude"];
            this.Latitude = conf["WeatherForecast:Latitude"];
        }

        public string ApiKey { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
        }
}