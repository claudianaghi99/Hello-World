using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class DailyWeatherRecord
    {

        public const float KELVIN_CONST = 273.15f;

        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            this.Date = day;
            this.Temperature = temperature;
            this.Type = type;
        }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Date { get; set; }

        public float ConvertKelvintoCelsius(float kelvin)
        {
            return kelvin - KELVIN_CONST;
        }
    }
}