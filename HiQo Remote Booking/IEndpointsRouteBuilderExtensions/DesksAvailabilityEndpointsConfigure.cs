using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace HiQo_Remote_Booking.IEndpointsRouteBuilderExtensions
{
    public static class DesksAvailabilityEndpointsConfigure
    {
        public static void ConfigureDesksAvailabilityEndpoints(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "getDesksAvailability",
                pattern: "/desks/available/{date}/{deskStatus?}",
                defaults: new {controller = "DeskAvailability", action = "GetDeskAvailability"});
        }
    }
}