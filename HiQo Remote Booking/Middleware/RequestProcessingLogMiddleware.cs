﻿using HiQo_Remote_Booking.LoggerProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this._logger = loggerFactory.AddDataBaseLogger().CreateLogger("BadRequestLog"); ;
        }

        public async Task InvokeAsync(HttpContext context)
        {
             await _next.Invoke(context);
             _logger.LogInformation("Method:{0} Path:{1} Status code: {2}",context.Request.Method,context.Request.Path,context.Response.StatusCode);
         
        }
    }
}
