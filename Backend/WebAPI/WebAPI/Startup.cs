using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLogic;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi
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
            services.AddSingleton<IConnectionSettings, ConnectionSettings>();
            
            BusinessLogicModule.Register(services);
            DataAccessModule.Register(services);

            services.AddControllers();
            
            services.AddMemoryCache();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(
                options =>
                    options
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
            );

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                }
            );
        }
    }
}