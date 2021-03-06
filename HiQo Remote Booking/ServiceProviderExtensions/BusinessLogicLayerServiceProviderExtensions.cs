﻿using Microsoft.Extensions.DependencyInjection;
using Service.AdminService.Interfaces;
using Service.AdminService.Services;
using Service.BookingService.Interfaces;
using Service.BookingService.Realization;

namespace HiQo_Remote_Booking.ServiceProviderExtensions
{
    public static class BusinessLogicLayerServiceProviderExtensions
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookingManagementService, BookingManagementService>();
            services.AddTransient<IDeskAvailabilityService, DeskAvailabilityService>();
            services.AddTransient<IMyBookingsService, MyBookingsService>();
            services.AddTransient<IAdminService, AdminService>();
        }
    }
}
