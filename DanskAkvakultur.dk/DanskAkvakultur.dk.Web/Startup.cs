using DanskAkvakultur.dk.DataAccess.Managers;
using DanskAkvakultur.dk.DataAccess.Factories;
using DanskAkvakultur.dk.DataAccess.Repositories;
using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.DataAccess.Services;
using DanskAkvakultur.dk.DataAccess.Services.Abstrations;
using DanskAkvakultur.dk.Shared.Configurations;
using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using DanskAkvakultur.dk.Shared.Hubs.Endpoints;

namespace DanskAkvakultur.dk.Web
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
            var simSettings = Configuration.GetSection("Simulation").Get<SimulationSettings>();
            var connSettings = Configuration.GetSection("DbConfig").Get<SqlDbConnectionSettings>();

            services.AddScoped<ISimulationHubSettings>(s =>
            {
                var navManager = s.GetService<NavigationManager>();
                simSettings.AbsoluteUri = navManager.ToAbsoluteUri(simSettings.RelativeUri);
                return simSettings;
            });
            services.AddSingleton<IConnectionSettings>(connSettings);

            services.AddTransient<ISimulationService, SimulationClientService>();

            /* Data Access Library Configuration */
            services.AddSingleton<IDbFactory, SqlDbConnectionFactory>();
            services.AddScoped<IDbManager, SqlDbManager>();
            services.AddScoped<IScoreRepository, DbScoreRepository>();

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
                endpoints.MapHub<VirtualSimulationHubEndpoint>("/virtual-simulation-hub");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
