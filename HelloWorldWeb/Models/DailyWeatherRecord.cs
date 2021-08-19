namespace HelloWorldWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DailyWeatherRecord
    {
        public const float KELVINCONST = 273.15f;

        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            Date = day;
            Temperature = ConvertKelvinToCelsius(temperature);
            Type = type;
        }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Date { get; set; }

        public static float ConvertKelvinToCelsius(float temp)
        {
            float celsiusTemperature = temp - KELVINCONST;
            return (float)Math.Round(celsiusTemperature, 2);
        }
    }
}
