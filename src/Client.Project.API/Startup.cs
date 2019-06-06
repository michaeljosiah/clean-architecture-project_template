using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Client.Project.Application;
using Client.Project.Application.Tables.Queries.GetAvailableTables;
using Client.Project.Domain;
using Client.Project.Domain.Interfaces.Commands;
using Client.Project.Domain.Interfaces.Persistance;
using Client.Project.Domain.Interfaces.Queries;
using Client.Project.Infrastructure.Dispatchers;
using Client.Project.Persistance.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Client.Project.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddAutoMapper(typeof(ApiMappingProfile), typeof(ApplicationMappingProfile));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //MVC Configuration
            services.AddMvc(x =>
            {
                x.ReturnHttpNotAcceptable = true;
                x.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CommandResult>())
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);


            //Swagger configuration
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Client Project API", Version = "v1", Description = "Connected Services scaffold project" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Client.Project.API.xml");
                x.IncludeXmlComments(filePath);
            });


            services.AddSingleton(Configuration.Get<CustomConfiguration>());
            services.AddSingleton<ITableRepository, MockTableRepository>();

            //Using scrutor library which adds the scan extension method to the built in .NET Core DI container to register dependancies
            services.Scan(scan => scan
           .FromAssembliesOf(new List<Type>()
           {
               typeof(QueryDispatcher),
               typeof(CommandResult),
           })
           //Register the dispatchers via their namespace
           .AddClasses(classes => classes.InNamespaces("Client.Project.Infrastructure.Dispatchers"))
           .AsImplementedInterfaces()
           .WithScopedLifetime()

           //Register all query handlers
           .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
           .AsImplementedInterfaces()
           .WithScopedLifetime()

            //Register all command handlers
           .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
           .AsImplementedInterfaces()
           .WithScopedLifetime()
           );
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddApplicationInsights(app.ApplicationServices,LogLevel.Warning);
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Client Project API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Global exception handling.When an error occurs set the status code to 500 and return a default message
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error has occured. Please try again later.");
                    });
                });
            }

      
            app.UseMvc();
        }
    }
}
