using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.Middleware
{
    public static class RequestProcessingLogExtensions
    {
        public static IApplicationBuilder UseRequestProcessingLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestProcessingLogMiddleware>();
        }
    }
}
