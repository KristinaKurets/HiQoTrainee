using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.LoggerProvider
{
    public class DataBaseLoggerProvider : ILoggerProvider
    {
    

        public ILogger CreateLogger(string categoryName)
        {
            return new DataBaseLogger();
        }

        public void Dispose()
        {
           // no
        }
    }
}
