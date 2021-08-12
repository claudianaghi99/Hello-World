using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.AddTeamMember("Radu");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }
        [Fact]
        public void RemoveMemberFromTheTeam()
        {
            // Assume
            TeamService teamService = new TeamService();



            // Act
            teamService.RemoveMember(2);



            // Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]

        public void UpdateTeamMember()
        {
            //Assume

            ITeamService teamService = new TeamService();

            //Act

            teamService.UpdateMemberName(0, "Alex");

            //Assert

            Assert.Equal("Alex", teamService.GetTeamMemberById(0).Name);
        }

    }
}
