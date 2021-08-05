// <copyright file="TeamInfo.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public TeamMember( int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}