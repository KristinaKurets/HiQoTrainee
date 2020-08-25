using HiQo_Remote_Booking.LoggerFactoryExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RequestLogger.Entities;
using RequestLogger.Extensions;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.Middleware
{
    public class RequestProcessingLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestProcessingLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._logger = loggerFactory.CreateLogger<RequestLogger.Logger.RequestLogger>(); 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            _logger.Log(new RequestProcessingEntity
            {
                Method = context.Request.Method,
                Path = context.Request.Path,
                StatusCode = context.Response.StatusCode
            });
            
        }
    }
}
