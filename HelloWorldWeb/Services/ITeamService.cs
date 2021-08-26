﻿namespace HelloWorldWeb.services
{
    using HelloWorldWeb.Models;

    public interface ITeamService
    {
        int AddTeamMember(TeamMember member);

        int AddTeamMember(string name);

        TeamInfo GetTeamInfo();

        TeamMember GetTeamMemberById(int id);

        public void RemoveMember(int id);

        public void UpdateMemberName(int memberid, string name);
    }
}