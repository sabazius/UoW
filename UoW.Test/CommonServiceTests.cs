using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Xunit;

namespace UoW.Test
{
    public class CommonServiceTests
    {
        protected readonly HttpClient _client;

        //public CommonServiceTests()
        //{
        //    var sever = new TestServer(new WebHostBulder()
        //        .UseEnvironment("Development")
        //        .UseStartup<Startup>());

        //    _client = server.CreateClient();
        //}

        //[Fact]
        //public void TestHealthCheck()
        //{
        //    var response = _client.GetAsync("health");
        //    response.EnsureSuccessStatusCode();

        //    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        //    var responseString = await response.Content.ReadAsStringAsync();

        //    Assert.Equal("Health", responseString);
        //}
    }
}
