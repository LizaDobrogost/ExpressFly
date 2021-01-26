using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLogic;
using DataAccess;

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
            services.AddCorsPolicy(Configuration);
            
            BusinessLogicModule.Register(services);
            DataAccessModule.Register(services);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                config =>
                    {
                        WebApiMapping.Initialize(config);
                        BusinessLogicMapping.Initialize(config);
                    }
                );

            mapperConfiguration.CompileMappings();

            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddControllers();
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

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("SpecificCorsPolicy");

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