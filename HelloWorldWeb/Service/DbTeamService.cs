using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Service
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;

        public DbTeamService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember(name);
            this.context.Add(name);
            this.context.SaveChanges();
            return teamMember.Id;
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name = "Radu";
            teamInfo.TeamMembers = context.TeamMembers.ToList();
            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberName(int memberid, string name)
        {
            throw new NotImplementedException();
        }
    }
}
