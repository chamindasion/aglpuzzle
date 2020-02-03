using Agl.Puzzle.Data;
using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models;
using Agl.Puzzle.Service;
using Agl.Puzzle.Service.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agl.Puzzle.API
{
    public class Startup
    {
        private AglConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            this._configuration = new AglConfiguration();
            Configuration = configuration;                      
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc();
            services.AddSingleton(this._configuration);
            services.AddTransient<IPetApiClient, PetApiClient>();
            services.AddTransient<IPersonPetReadService, PersonPetReadService>();        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build()
                .Bind(_configuration);

            app.UseCors(options => options.AllowAnyMethod().AllowAnyOrigin().AllowCredentials().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseMvc();
        }
    }
}
