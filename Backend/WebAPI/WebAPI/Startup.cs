using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLogic;
using DataAccess;
using DataAccess.Data;
using WebApi.JWT;

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

            services.AddSqlContext(Configuration);

            services.AddTransient<JwtService>();
            services.AddTransient<AirlineContext>();

            BusinessLogicModule.Register(services);
            DataAccessModule.Register(services);

            services.AddTransient<IJwtService, JwtService>();

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
            app.UseExceptionHandling();

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