using HiQo_Remote_Booking.LoggerProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.Filters
{
    public class BadRequestExceptionFilterAttribute: Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;
        public BadRequestExceptionFilterAttribute(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.AddDataBaseLogger().CreateLogger("BadRequestLog");
        }
        public void OnException(ExceptionContext context)
        {   
                string actionName = context.ActionDescriptor.DisplayName;           
                string exceptionMessage = context.Exception.Message;
                _logger.LogError(actionName+DataBaseLogger.SPLITTER+exceptionMessage);
                context.ExceptionHandled = true; 
        }
    }
}
