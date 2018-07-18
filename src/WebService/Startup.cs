﻿using AutoMapper;
using Common;
using Declarations.Interfaces.Query;
using GiHubGrapthQlDataRetriever;
using GitHubGrapthQlDataRetriever;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebService.Middleware;

namespace WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InitAutoMapper();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IDataRetriever>(new GitHubGrapthQlDataRetriever.GitHubGrapthQlDataRetriever(
                user: Configuration.GetSection("Git")["User"],
                tokenFunc: () => TokenProvider.Token));
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }

        private void InitAutoMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperRepoProfile>();
            });
        }
    }
}
