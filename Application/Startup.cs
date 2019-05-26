using System;
using Application.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        private ServiceProvider BindConfigurations(IServiceCollection services)
        {
            services.AddOptions();
            
            var spaConfigSection = Configuration.GetSection("SPA");
            services.Configure<SpaConfig>(spaConfigSection);

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Return bounded provider to use configurations immediately
            var serviceProvider = BindConfigurations(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // TODO Once app is ready for a full production release, change MaxAge to a much longer time (1+ years)
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromHours(12);
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = serviceProvider.GetService<IOptions<SpaConfig>>().Value.RootPath;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // TODO Add default exception page that is not related the the SPA app
                // app.UseExceptionHandler("/Error");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
                // TODO Link to configurations rather than a string constant
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer("start");
                }
            });
        }
    }
}