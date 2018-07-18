using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Declarations;
using Declarations.DomainModel;
using Declarations.Interfaces.Query;
using GiHubGrapthQlDataRetriever;
using GitHubGrapthQlDataRetriever;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebService.Middleware;
using Xunit;

namespace UnitTests
{
    public class RestApiTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public RestApiTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetUserByLoginTest()
        {
            var res = await Get("torvalds", 3, 1);
            Assert.True(res.Item2 == HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetUserByLoginTestError()
        {
            var res = await Get("torvalds", 300, 100);
            Assert.True((int)res.Item2 == 500);
        }

        #region rest helpers

        public async Task<Tuple<QueryResult<GitUser>, HttpStatusCode>> Get(string user, int depth, int amount)
        {
            var response = await _client.GetAsync($"api/git/users/{user}?depth={depth}&amount={amount}");
            var code = response.StatusCode;
            if (response.StatusCode != HttpStatusCode.OK)
                return new Tuple<QueryResult<GitUser>, HttpStatusCode>(null, code);
            var responseString = await response.Content.ReadAsStringAsync();
            return new Tuple<QueryResult<GitUser>, HttpStatusCode>(JsonConvert.DeserializeObject<QueryResult<GitUser>>(responseString), code);
        }

        #endregion

        #region test Startup

        public class Startup
        {
            private string _user;
            public Startup(IConfiguration configuration)
            {
                IConfiguration sconfiguration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
                _user = sconfiguration.GetSection("Git")["User"];
                Configuration = configuration;
                InitAutoMapper();
            }

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
                services.AddSingleton<IDataRetriever>(new GitHubGrapthQlDataRetriever.GitHubGrapthQlDataRetriever(
                    user: _user,
                    tokenFunc: () => TokenProvider.Token));
                services.AddLogging();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                app.UseMvc();
            }

            private void InitAutoMapper()
            {
                Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperRepoProfile>(); });
            }

            
        }

        #endregion
    }
}
