﻿using HelloWorldWeb.Models;
using HelloWorldWebApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void TestCheckingConvertion()
        {
            // Assume
            string content = LoadJsonFromResource();
            var weatherControllerSettingsMock = new Mock<IWeatherControllerSettings>();
            WeatherController weatherController = new WeatherController(weatherControllerSettingsMock.Object);

            // Act
            var result = weatherController.ConvertResponseToWeatherForecastList(content);

            // Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();

            Assert.Equal(new DateTime(2021, 8, 12), firstDay.Date);
            Assert.Equal(24.260009765625, firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.TestData.ContentWeatherApi.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}