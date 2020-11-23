using ADOLibrary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieRental.API", Version = "v1" });
            });
            services.AddSingleton((sp) => new Connection(@"Data Source=DESKTOP-PJ4VH9N; Initial Catalog=MovieRental; Integrated Security=True; Connect Timeout=60; Encrypt= False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"));
            //IserviceProvider permet de recuperer les services automatiquement.
            services.AddSingleton<ActorService>();
            services.AddSingleton<CategoryService>();
            services.AddSingleton<CustomerService>();
            services.AddSingleton<FilmService>();
            services.AddSingleton<LanguageService>();
            services.AddSingleton<RatingService>();
            services.AddSingleton<RentalService>();
            services.AddSingleton<RentalDetailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieRental.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
