using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace HiQo_Remote_Booking.IEndpointsRouteBuilderExtensions
{
    public static class BookingEndpointsConfigure
    {
        public static void ConfigureBookingEndpoints(this IEndpointRouteBuilder endpoint)
        {
            #region BookingManagment

            endpoint.MapControllerRoute(
                name: "createBooking",
                pattern: "/booking/management/create/{userId}/{deskId}/{time}",
                defaults: new {controller = "BookingManagement", action = "CreateBooking"});

            endpoint.MapControllerRoute(
                name: "deleteBooking",
                pattern: "/booking/management/delete/{userId}/{deskId}",
                defaults: new {controller = "BookingManagement", action = "CancelBooking" });

            #endregion

            #region MyBooking

            endpoint.MapControllerRoute(
                name: "actualBookings",
                pattern: "/booking/actual",
                defaults: new {controller = "MyBooking", action = "ActualBooking"});

            endpoint.MapControllerRoute(
                name: "expiredBookings",
                pattern: "/booking/expired",
                defaults: new { controller = "MyBooking", action = "ExpiredBooking" });

            #endregion
        }
    }
}