using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        string AddTeamMember(string name);

        TeamInfo GetTeamInfo();
    }
}