using Api.MapperProfiles;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infrastructure.Middlewares;
using Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;

namespace EmployeeTimeTrackingDDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeTimeTrackingDDD", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("Default");
            var builder = new ContainerBuilder();
            ILogger logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

            builder.Properties.Add("ConnectionString", connectionString);
            builder.Populate(services);

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
                cfg.AddProfile<ReportProfile>();
                cfg.AddProfile<EmployeeReportProfile>();
            })).AsSelf().SingleInstance();

            builder.RegisterModule<AutoFacModule>();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeTimeTrackingDDD v1"));
            }
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseStaticFiles();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
