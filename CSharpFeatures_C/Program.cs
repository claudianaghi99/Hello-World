using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures_C
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamMember teamMember = new TeamMember() {Name="Member1"};
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("TeamMember.json", jsonString);
            var teamMemberDesearialized = JsonSerializer.Deserialize<TeamMember>(jsonString);
        }
    }
}
