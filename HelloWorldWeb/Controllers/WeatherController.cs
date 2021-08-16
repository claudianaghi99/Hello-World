using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWebApp.Controllers
{
    /// <summary>
    /// fetch data from weather API.
    /// <see cref="href="https://openweathermap.org/api">
    /// Weather API
    /// </see>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public const float KELVINCONST = 273.15f;
        private readonly string longitude = "23.5800";
        private readonly string latitude = "46.7700";
        private readonly string apiKey = "02d7a76352ce38d0cc90b1e68df3c81a";

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherController"/> class.
        /// </summary>
        /// <param name="conf"></param>
        public WeatherController(IWeatherControllerSettings conf)
        {
            this.longitude = conf.Longitude;
            this.latitude = conf.Latitude;
            this.apiKey = conf.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=c969b66bb3c8e3fe32d4485a1623f42c
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={this.latitude}&lon={this.longitude}&exclude=hourly,minutely&appid={this.apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return this.ConvertResponseToWeatherForecastList(response.Content);
        }

        [NonAction]
        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherForecastList(string content)
        {
            var json = JObject.Parse(content);

            if (json["daily"] == null)
            {
                throw new Exception("ApiKey is not valid.");
            }

            var jsonArray = json["daily"].Take(7);

            // lambda expression
            // result.AddRange(jsonArray.Select(item => CreateDailyWeatherFromJToken(item)));
            return jsonArray.Select(this.CreateDailyWeatherRecordFromJToken);
        }

        /// <summary>
        /// Get a weather forecast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="id">Amount of days from now (from 0 to 7).</param>
        /// <returns>The weather forecast.</returns>
        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [NonAction]
        public float ConvertKelvintoCelsius(float kelvin)
        {
            return kelvin - KELVINCONST;
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;

            float temp = item.SelectToken("temp").Value<float>("day") - 273.15f;

            // dailyWeatherRecord.Temperature = this.ConvertKelvintoCelsius(temp);
            string weather = item.SelectToken("weather")[0].Value<string>("description");
            var type = this.Convert(weather);
            DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(day, temp, type);
            return dailyWeatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "thunderstorm":
                    return WeatherType.Thunderstorm;
                case "light rain":
                    return WeatherType.LightRain;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                case "heavy intensity rain":
                    return WeatherType.HeavyRain;
                case "very heavy rain":
                    return WeatherType.HeavyRain;
                case "snow":
                    return WeatherType.Snow;
                case "mist":
                    return WeatherType.Mist;
                case "fog":
                    return WeatherType.Fog;
                case "clear sky":
                    return WeatherType.ClearSky;
                case "few clouds":
                    return WeatherType.FewClouds;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "overcast clouds":
                    return WeatherType.OvercastClouds;
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }
    }
}