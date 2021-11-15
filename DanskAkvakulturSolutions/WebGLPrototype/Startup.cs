using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGLPrototype.Data;

namespace WebGLPrototype
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
            services.AddSingleton<WeatherForecastService>();

            //var provider = new FileExtensionContentTypeProvider();
            //provider.Mappings.Remove(".data");
            //provider.Mappings[".data"] = "application/octet-stream";
            //provider.Mappings.Remove(".wasm");
            //provider.Mappings[".wasm"] = "application/wasm";
            //provider.Mappings.Remove(".symbols.json");
            //provider.Mappings[".symbols.json"] = "application/octet-stream";

            //services.Configure<StaticFileOptions>(options =>
            //{
            //    options.ContentTypeProvider = provider;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            provider.Mappings[".wasm"] = "application/wasm";
            provider.Mappings[".data.gz"] = "application/octet-stream";
            provider.Mappings[".wasm.gz"] = "application/wasm";
            provider.Mappings[".js.gz"] = "application/javascript";
            provider.Mappings[".data.br"] = "application/octet-stream";
            provider.Mappings[".wasm.br"] = "application/wasm";
            provider.Mappings[".js.br"] = "application/javascript";
            provider.Mappings[".symbols.json.br"] = "application/octet-stream";
            provider.Mappings[".unityweb"] = "TYPE/SUBTYPE";
            app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
