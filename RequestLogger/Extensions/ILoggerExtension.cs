using Microsoft.Extensions.Logging;
using RequestLogger.Entities;
using System;

namespace RequestLogger.Extensions
{
    public static class ILoggerExtension
    {
        public static void Log(this ILogger logger ,RequestProcessingEntity request) {
            if (logger.GetType()==typeof(Logger<Logger.RequestLogger>))
            {
                logger.Log(LogLevel.Information, new EventId(), request, null,(x,y)=>"");
            }
            else
            {
                logger.LogInformation("Method: {0} Path: {1}  Status code: {2}", request.Method, request.Path, request.StatusCode);
            }
        }

        public static void Log(this ILogger logger, BadRequestEntity request)
        {  if (logger.GetType() == typeof(Logger<Logger.RequestLogger>))
            {
                logger.Log(LogLevel.Information, new EventId(), request, null, (x, y) => "");
            }
            else
            {
                logger.LogError("Method: {0}  Exeption: {1}", request.Method, request.Exeption);
            }
        }

    }
}
