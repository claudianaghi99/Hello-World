namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public static int GetIdCount()
        {
            return idCount;
        }

        public int GetAge()
        {
            TimeSpan age;
            DateTime birthdate = this.Birthdate;
            DateTime zeroTime = new DateTime(1, 1, 1);
            age = timeService.Now - birthdate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }
    }
}