using Microsoft.Extensions.DependencyInjection;
using Service.AdminService.Interfaces;
using Service.AdminService.Realization;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.ServiceProviderExtensions
{
    public static class BusinessLogicLayerServiceProviderExtensions
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddTransient<IAllDesksService, AllDesksService>();
            services.AddTransient<IBookingSetupService, BookingSetupService>();
            services.AddTransient<IUserSetupService, UserSetupService>();
            services.AddTransient<IWorkPlansService, WorkPlanService>();
            services.AddTransient<IBookingManagementService, Service.BookingService.Realization.BookingManagementService>();
            services.AddTransient<IDeskAvailabilityService, Service.BookingService.Realization.DeskAvailabilityService>();
            services.AddTransient<IMyBookingsService, Service.BookingService.Realization.MyBookingsService>();

        }
    }
}
