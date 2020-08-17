using HiQo_Remote_Booking.Middleware;
using Microsoft.AspNetCore.Builder;


namespace HiQo_Remote_Booking.ApplicationBuilderExtensions
{
    public static class RequestProcessingLogExtensions
    {
        public static IApplicationBuilder UseRequestProcessingLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestProcessingLogMiddleware>();
        }
    }
}
