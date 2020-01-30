using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SweeneyVidyaGames.Api.Core.Services;
using SweeneyVidyaGames.Api.Domain.Repositories;
using SweeneyVidyaGames.Api.Interfaces;
using SweeneyVidyaGames.Api.Persistence.Contexts;
using SweeneyVidyaGames.Api.Persistence.Repositories;
using SweeneyVidyaGames.Api.Resources;

namespace SweeneyVidyaGames
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = new ConnectionString(Configuration.GetConnectionString("DefaultConnection"));

            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString.Value);
            });

            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Vidya Games",
                    Version = "v1",
                    Contact = new OpenApiContact { Name = "Tiffany Sweeney", Email = "tiffany.denkler@yahoo.com" }
                });
            });

            services.AddScoped<IVideoGameRepository, VideoGameRepository>();
            services.AddScoped<IVideoGameService, VideoGameService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vidya Games API V1");
            });
        }
    }
}
