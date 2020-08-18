using HiQo_Remote_Booking.LoggerFactoryExtensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using RequestLogger.Entities;
using RequestLogger.Extensions;
using System;


namespace HiQo_Remote_Booking.Filters
{
    public class BadRequestExceptionFilterAttribute: Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;
        public BadRequestExceptionFilterAttribute(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.AddRequestLogger().CreateLogger<RequestLogger.Logger.RequestLogger>();
        }
        public void OnException(ExceptionContext context)
        {   
            _logger.Log(new BadRequestEntity()
            {
                Method = context.ActionDescriptor.DisplayName,
                Exeption = context.Exception.Message
            }); 
               
        }
    }
}
