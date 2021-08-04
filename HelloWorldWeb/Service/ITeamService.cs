using HelloWorldWeb.Models;

namespace HelloWorldWeb.Service
{
    public interface ITeamService
    {
        void AddTeamMember(string name);

        TeamInfo GetTeamInfo();
    }
}