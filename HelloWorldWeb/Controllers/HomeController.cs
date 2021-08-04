// <copyright file="HomeController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly TeamInfo teamInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<string>(new string[] { "Claudia", "Radu", "Teona", "Dragos", "Leon", "George" }),
            };
        }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            this.teamInfo.TeamMembers.Add(name);
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamInfo.TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(this.teamInfo);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public override bool Equals(object obj)
        {
            return obj is HomeController controller &&
                   EqualityComparer<ILogger<HomeController>>.Default.Equals(this.logger, controller.logger);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
