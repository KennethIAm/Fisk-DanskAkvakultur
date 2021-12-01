using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataClassLibrary.Core.Settings;
using DataClassLibrary.Core.Settings.Interfaces;
using DataClassLibrary.Simulation.Services.Interfaces;
using DataClassLibrary.Simulation.Services;
using DataClassLibrary.Core.Endpoints;
using DataAccessLibrary.Leaderboard.Repository;
using DataAccessLibrary.Managers;
using DataAccessLibrary;
using DataAccessLibrary.Settings;

namespace BlazorServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            /* Load Configuration Settings */
            var simSettings = Configuration.GetSection("Simulation").Get<SimulationServiceSettings>();
            var connSettings = Configuration.GetSection("DbConfig").Get<DbConnectionSettings>();

            services.AddScoped<ISimulationSettings>(s =>
            {
                var navManager = s.GetService<NavigationManager>();
                simSettings.AbsoluteUri = navManager.ToAbsoluteUri(simSettings.RelativeUri);
                return simSettings;
            });
            services.AddSingleton<IConnectionSettings>(connSettings);

            services.AddTransient<ISimulationService, SimulationSignalRService>();

            /* Data Access Library Configuration */
            services.AddSingleton<IDbFactory, SqlDbConnectionFactory>();
            services.AddScoped<IDbManager, SqlDbManager>();
            services.AddScoped<ILeaderboardRepository, DbLeaderboardRepository>();

            /* Add compression to response packets. */
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".data"] = "application/octet-stream";
            provider.Mappings[".data.gz"] = "application/octet-stream";
            provider.Mappings[".data.br"] = "application/octet-stream";
            provider.Mappings[".wasm"] = "application/wasm";
            provider.Mappings[".wasm.gz"] = "application/wasm";
            provider.Mappings[".wasm.br"] = "application/wasm";
            provider.Mappings[".js.gz"] = "application/javascript";
            provider.Mappings[".js.br"] = "application/javascript";
            provider.Mappings[".symbols.json.br"] = "application/octet-stream";
            provider.Mappings[".unityweb"] = "TYPE/SUBTYPE";
            app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapHub<VirtualSimulationHub>("/virtual-simulation-hub");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
