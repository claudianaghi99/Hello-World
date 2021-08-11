using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<TeamMember>(),
            };
            this.AddTeamMember("Radu");
            this.AddTeamMember("Teona");
            this.AddTeamMember("Claudia");
            this.AddTeamMember("Leon");
            this.AddTeamMember("George");
            this.AddTeamMember("Dragos");
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public int AddTeamMember(string name)
        {
            TeamMember member = new TeamMember(name);
            this.teamInfo.TeamMembers.Add(member);
            return member.Id;
        }

        public void RemoveMember(int id)
        {
            var member = this.GetTeamMemberById(id);
            this.teamInfo.TeamMembers.Remove(member);
        }

        public TeamMember GetTeamMemberById(int id)
        {
            foreach (TeamMember member in this.teamInfo.TeamMembers)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
        }

        public void UpdateMemberName(int memberId, string name)
        {
            TeamMember member = this.teamInfo.TeamMembers.Single(element => element.Id == memberId);
            member.Name = name;
        }
    }
}