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
                
            }
           

        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                 
                    var aleksey = formatter(state, exception);
                    switch (logLevel) {
                        case LogLevel.Information:
                            _logger.Info(aleksey);
                          
                            break;          
                        case LogLevel.Error:
                            _logger.Error(aleksey);
                            break;
                    }
                }
            
            }
        }
    }
}
