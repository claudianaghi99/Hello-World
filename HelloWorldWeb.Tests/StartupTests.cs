using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToASPNETString()
        {
            // Assume
            string herokuConnection = "postgres://gskboezypzuyzd:9f5422a3fdfce951de248c2644863a7b177ab64b5563bbcd3f1dfda05b9b29ca@ec2-63-33-14-215.eu-west-1.compute.amazonaws.com:5432/d2gb16994q85fs";

            // Act
            string aspnetConnectionString = Startup.ConvertHerokuStringToAspnetString(herokuConnection);

            // Assert
            Assert.Equal("Host=ec2-63-33-14-215.eu-west-1.compute.amazonaws.com;Port=5432;Database=d2gb16994q85fs;User Id=gskboezypzuyzd;Password=9f5422a3fdfce951de248c2644863a7b177ab64b5563bbcd3f1dfda05b9b29ca;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;", aspnetConnectionString);
        }
    }
}
