﻿namespace HelloWorldWeb.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HelloWorldWeb.Models;
    using Microsoft.AspNetCore.SignalR;

    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        public TeamService(IBroadcastService broadcastService)
        {
            this.broadcastService = broadcastService;
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<TeamMember>(),
            };
            AddTeamMember("Radu");
            AddTeamMember("Teona");
            AddTeamMember("Claudia");
            AddTeamMember("Leon");
            AddTeamMember("George");
            AddTeamMember("Dragos");
        }

        /// <inheritdoc/>
        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        /// <inheritdoc/>
        public TeamMember GetTeamMemberById(int id)
        {
            foreach (TeamMember member in teamInfo.TeamMembers)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public int AddTeamMember(string name)
        {
            TeamMember member = new TeamMember(name, timeService);
            this.teamInfo.TeamMembers.Add(member);
            broadcastService.NewTeamMemberAdded(name, member.Id);
            return member.Id;
        }

        public void RemoveMember(int id)
        {
            var member = GetTeamMemberById(id);
            this.teamInfo.TeamMembers.Remove(member);
            this.broadcastService.TeamMemberDeleted(id);
        }

        public void UpdateMemberName(int memberId, string name)
        {
            int index = teamInfo.TeamMembers.FindIndex(element => element.Id == memberId);
            teamInfo.TeamMembers[index].Name = name;
            this.broadcastService.TeamMemberEdited(memberId, name);
        }
    }
}
