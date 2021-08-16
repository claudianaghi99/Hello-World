namespace HelloWorldWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DailyWeatherRecord
    {
        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            this.Date = day;
            this.Temperature = temperature;
            this.Type = type;
        }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Date { get; set; }
    }
}