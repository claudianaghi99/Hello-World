// <copyright file="HomeController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Controllers
{
    using System;
    using System.Diagnostics;
    using HelloWorldWeb.Models;
    using HelloWorldWeb.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService, IBroadcastService broadcastService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
            this.broadcastService = broadcastService;
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        [Authorize]
        public int AddTeamMember(string name)
        {
            // TeamMember member = new TeamMember(name, timeService);
            TeamMember member = new TeamMember() { Name = name };
            int newMemberId = this.teamService.AddTeamMember(member);
            broadcastService.NewTeamMemberAdded(member, member.Id);
            return newMemberId;
        }

        [HttpDelete]
        [Authorize]
        public void RemoveMember(int id)
        {
            teamService.RemoveMember(id);
            this.broadcastService.TeamMemberDeleted(id);
        }

        [HttpPost]
        [Authorize]
        public void UpdateMemberName(int memberId, String name)
        {
            teamService.UpdateMemberName(memberId, name);
            this.broadcastService.TeamMemberEdited(memberId, name);
        }

        public IActionResult Index()
        {
             return this.View(this.teamService.GetTeamInfo());
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

        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
