﻿using System;
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
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string longitude = "23.5800";
        private readonly string latitude = "46.7700";
        private readonly string apiKey = "02d7a76352ce38d0cc90b1e68df3c81a";

        public WeatherController(IWeatherControllerSettings conf)
        {
            longitude = conf.Longitude;
            latitude = conf.Latitude;
            apiKey = conf.ApiKey;
        }

        public const float KELVIN_CONST = 273.15f;

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

            if (json["daily"] == null)
            {
                throw new Exception("ApiKey is not valid.");
            }

            var jsonArray = json["daily"].Take(7);

            // lambda expression
            // result.AddRange(jsonArray.Select(item => CreateDailyWeatherFromJToken(item)));
            return jsonArray.Select(CreateDailyWeatherRecordFromJToken);
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;

            float temp = item.SelectToken("temp").Value<float>("day")-273.15f;
            // dailyWeatherRecord.Temperature = this.ConvertKelvintoCelsius(temp);

            string weather = item.SelectToken("weather")[0].Value<string>("description");
            var type = this.Convert(weather);
            DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(day, temp, type);
            return dailyWeatherRecord;
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
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }

        public float ConvertKelvintoCelsius(float kelvin)
        {
            return kelvin - KELVIN_CONST;
        }
    }
}