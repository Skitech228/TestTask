#region Using derectives

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TestTask.Application.Repository;
using TestTask.Application.Services;
using TestTask.Database;
using TestTask.Shared;
using TestTask.Shared.IEntityServices;

#endregion

namespace TestTask.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PlatformContext>(options =>
                                                           options.UseSqlServer(connection));

            services.AddScoped<ITextService, TextService>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<ITextRepository, TextRepository>();
            services.AddControllersWithViews();
            services.AddControllers();

            services.AddSwaggerGen(c =>
                                   {
                                       c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestTask", Version = "v1" });
                                   });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestTask v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}