using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        string AddTeamMember(string name);

        public void RemoveMember(int memberIndex);
        TeamInfo GetTeamInfo();
    }
}