using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace ApiCalculaJuros.TesteIntegracao.Fixtures
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestContext()
        {
            SetupClient();
            //InitConfiguration();
        }

        private void SetupClient()
        {
            var webBuilder = new WebHostBuilder().UseStartup<Startup>();
            webBuilder.ConfigureServices(p =>
            {
                
            });

            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>()
                                                         .UseConfiguration(new ConfigurationBuilder()        
                                                         .AddJsonFile("appsettings.test.json")
                                                         .Build()));
            Client = _server.CreateClient();
        }

        private static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}