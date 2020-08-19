using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using DB.Context;
using HiQo_Remote_Booking.ServiceProviderExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Profiles;
using HiQo_Remote_Booking.Filters;
using HiQo_Remote_Booking.ApplicationBuilderExtensions;
using HiQo_Remote_Booking.IEndpointsRouteBuilderExtensions;
using Microsoft.Extensions.Logging;
using HiQo_Remote_Booking.LoggerFactoryExtensions;
using Microsoft.OpenApi.Models;

namespace HiQo_Remote_Booking
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContext, HqrbContext>(options => 
                options.UseLazyLoadingProxies().UseSqlServer(connection));
            services.AddAutoMapper(typeof(DtoProfile));
            services.AddAutoMapper(typeof(BookingDTOProfile));
            services.AddUnitOfWorkAndRepository();
            services.AddBusinessLogicLayer();
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(BadRequestExceptionFilterAttribute));
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestProcessingLog();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
         
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
