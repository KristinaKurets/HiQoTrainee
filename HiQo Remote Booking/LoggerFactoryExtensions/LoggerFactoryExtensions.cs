using Microsoft.Extensions.Logging;
using RequestLogger.RequestLoggerProvider;

namespace HiQo_Remote_Booking.LoggerFactoryExtensions
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory AddRequestLogger(this ILoggerFactory factory)
        {
            factory.AddProvider(new RequestLoggerProvider());
            return factory;
        }
    }
}
