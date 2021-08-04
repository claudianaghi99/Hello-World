using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Service;

namespace HelloWorldWebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<string>(new string[]
               {
                    "Sechei Radu",
                    "Tanase Teona",
                    "Duma Dragos",
                    "Campean Leon",
                    "Naghi Claudia",
                    "Marian George",
               }),
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public void AddTeamMember(string name)
        {
            this.teamInfo.TeamMembers.Add(name);
        }
    }
}
