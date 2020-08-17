using Microsoft.Extensions.Logging;
using System;

namespace RequestLogger.RequestLoggerProvider
{
    public class RequestLoggerProvider: ILoggerProvider
    {
        private bool disposedValue;

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger.RequestLogger();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

  
        public void Dispose()
        {
       
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
