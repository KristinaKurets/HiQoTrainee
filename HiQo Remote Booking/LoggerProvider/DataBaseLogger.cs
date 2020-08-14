using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.LoggerProvider
{
    public class DataBaseLogger: ILogger
    {
        public static string SPLITTER ="|||";
        protected NLog.Logger _logger;
        private static object _lock = new object();
        public DataBaseLogger() { 
            _logger= NLog.LogManager.GetCurrentClassLogger();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        protected void LogBadRequest(string messege) {
            var ms = messege.Split(SPLITTER);
            if (ms.Length == 2) {
                NLog.LogEventInfo theEvent = new NLog.LogEventInfo(NLog.LogLevel.Error, "", "");
                theEvent.Properties["Method"] = ms[0];
                theEvent.Properties["Exeption"] = ms[1];
                _logger.Error(theEvent);
            }
       }

        protected void LogProcessingInfo(string messege) {
            var ms = messege.Split(SPLITTER);
            if (ms.Length == 3) {
                NLog.LogEventInfo theEvent = new NLog.LogEventInfo(NLog.LogLevel.Info, "", "");
                theEvent.Properties["HTTPMethod"] = ms[0];
                theEvent.Properties["Path"] = ms[1];
                theEvent.Properties["StatusCode"] = ms[2];
                _logger.Info(theEvent);
            }

        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                 
                    switch (logLevel) {
                        case LogLevel.Information:
                           LogProcessingInfo(formatter(state, exception));
                          
                            break;          
                        case LogLevel.Error:
                            LogBadRequest(formatter(state, exception));
                            break;
                    }
                }
            
            }
        }
    }
}
