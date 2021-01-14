using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UoW.Test
{
	public class CommonServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		protected readonly HttpClient _client;
		private readonly WebApplicationFactory<Startup> _factory;

		public CommonServiceTests(WebApplicationFactory<Startup> factory)
		{
			var projectDir = Directory.GetCurrentDirectory();
			var configPath = Path.Combine(projectDir, "appsettings.json");

			_factory = factory.WithWebHostBuilder(builder => 
			{
				builder.ConfigureAppConfiguration((context, conf) =>
				{
					conf.AddJsonFile(configPath);
				});
			});

			_client = _factory.CreateClient();
		}

		[Fact]
		public async Task TestHealthCheck()
		{
			var response = await _client.GetAsync("health");
			response.EnsureSuccessStatusCode();

			Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

			var responseString = await response.Content.ReadAsStringAsync();

			Assert.Equal("Healthy", responseString);
		}
	}
}
