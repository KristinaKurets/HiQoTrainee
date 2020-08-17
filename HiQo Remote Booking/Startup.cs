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
using HiQo_Remote_Booking.IEndpointsRouteBuilderExtensions;
using HiQo_Remote_Booking.Middleware;

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
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.ConfigureAdminPanelEndpoints();
                endpoints.ConfigureBookingEndpoints();
                endpoints.ConfigureDesksAvailabilityEndpoints();
            });
        }
    }
}
