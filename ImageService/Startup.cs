using ImageServiceApi.Configurations;
using ImageServiceApi.Configurations.Models;
using ImageServiceApi.Persistence;
using ImageServiceApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ImageServiceApi
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
            services.AddLogging();
            services.AddOptions();
            services.Configure<ImageServiceConfiguration>(Configuration.GetSection(typeof(ImageServiceConfiguration).Name));

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
            services.AddDbContext<Context>(options =>
                options.UseMySql(Configuration.GetConnectionString("SQLServer"), serverVersion)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImageService, ImageService>();

            services.AddControllers();
            services.ConfigureSwagger();

            // Cors policy
            services.AddCors(options =>
            {
                options.AddPolicy("cors", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            // ToDO from Cfg File!
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImageService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseExceptionHandlingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

 
        }
    }
}
