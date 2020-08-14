using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.LoggerProvider
{
    public static class DataBaseLoggerExtensions
    {
        public static ILoggerFactory AddDataBaseLogger(this ILoggerFactory factory)
        {
            factory.AddProvider(new DataBaseLoggerProvider());
            return factory;
        }
    }
}
