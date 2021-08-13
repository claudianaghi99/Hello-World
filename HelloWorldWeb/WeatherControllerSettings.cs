using HelloWorldWebApp.Controllers;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public string Longitude => throw new System.NotImplementedException();

        public string Latitude => throw new System.NotImplementedException();

        public string ApiKey => throw new System.NotImplementedException();
    }
}