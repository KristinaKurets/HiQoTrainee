using System;
using Microsoft.Extensions.Logging;
using RequestLogger.Entities;

namespace RequestLogger.Logger
{
    public class RequestLogger:ILogger
    {
        protected NLog.Logger _logger;
        private static object _lock = new object();
        public RequestLogger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        protected void LogBadRequest(BadRequestEntity badRequest)
        {
            if (badRequest != null)
            {
                NLog.LogEventInfo theEvent = new NLog.LogEventInfo(NLog.LogLevel.Error, "", "");
                theEvent.Properties["Method"] = badRequest.Method;
                theEvent.Properties["Exeption"] = badRequest.Exeption;
                _logger.Error(theEvent);
            }
            
        }

        protected void LogProcessingInfo(RequestProcessingEntity requestProcessing)
        {
            if (requestProcessing != null)
            {
                NLog.LogEventInfo theEvent = new NLog.LogEventInfo(NLog.LogLevel.Info, "", "");
                theEvent.Properties["HTTPMethod"] = requestProcessing.Method;
                theEvent.Properties["Path"] = requestProcessing.Path;
                theEvent.Properties["StatusCode"] = requestProcessing.StatusCode;
                _logger.Info(theEvent);
            }
         
        }

      

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {

                    switch (logLevel)
                    {
                        case LogLevel.Information:
                            LogProcessingInfo(state as RequestProcessingEntity);

                            break;
                        case LogLevel.Error:
                            LogBadRequest(state as BadRequestEntity);
                            break;
                    }
                }

            }
        }
    }
}
