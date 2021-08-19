using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures_C
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            TeamMember teamMember = new TeamMember() {Name="Member1"};
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("TeamMember.json", jsonString);
            var readText = File.ReadAllTextAsync("TeamMember.json");
            readText.Wait();
            var expectedOutput = readText.Result;
            var teamMemberDesearialized = JsonSerializer.Deserialize<TeamMember>(expectedOutput);
            Console.WriteLine(teamMemberDesearialized);

            Coffe coffe = MakeCoffe("grain", "milk", "water", "sugar", Espresso);
            Console.WriteLine($"Here is your coffee:{coffe}.");
        }

        static Coffe MakeCoffe(string grains, string milk, string water, string sugar, Func<string, string, string, string, Coffe> recipe)
        {
            try
            {
                Console.WriteLine("Start preparing coffee.");
                var coffe = recipe(grains, milk, water, sugar);
                return coffe;
            }
            catch
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        static Coffe Espresso(string grains, string milk, string water, string sugar)
        {
            return new Coffe("Espresso");
        }
    }

    
}
