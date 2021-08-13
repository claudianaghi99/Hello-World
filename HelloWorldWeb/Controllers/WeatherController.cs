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
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string longitude = "23.5800";
        private readonly string latitude = "46.7700";
        private readonly string apiKey = "02d7a76352ce38d0cc90b1e68df3c81a";

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

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherForecastList(string content)
        {
            var json = JObject.Parse(content);

            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();

            var jsonArray = json["daily"].Take(7);

            foreach (var item in jsonArray)
            {
                DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord();
                long unixDateTime = item.Value<long>("dt");
                dailyWeatherRecord.Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date;

                float temp = item.SelectToken("temp").Value<float>("day");
                dailyWeatherRecord.Temperature = this.ConvertKelvintoCelsius(temp);

                string weather = item.SelectToken("weather")[0].Value<string>("description");
                dailyWeatherRecord.Type = this.Convert(weather);

                result.Add(dailyWeatherRecord);
            }

            return result;
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds":
                    return WeatherType.FewClouds;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }

        private float ConvertKelvintoCelsius(float kelvin)
        {
            float celsius = kelvin - 273.15f;
            return celsius;
        }
    }
}