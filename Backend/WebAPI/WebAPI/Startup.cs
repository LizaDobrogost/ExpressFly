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
        private readonly string AllowedSpecificOrigins = "_AllowedSpecificOrigins";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsPolicy(Configuration, AllowedSpecificOrigins);
            
            BusinessLogicModule.Register(services);
            DataAccessModule.Register(services);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                config =>
                    {
                        WebApiMapping.Initialize(config);
                        BusinessLogicMapping.Mapp(config);
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowedSpecificOrigins);

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