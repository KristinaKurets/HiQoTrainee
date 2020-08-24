using Microsoft.Extensions.DependencyInjection;
using Service.NotificationService.Interfaces;
using Service.NotificationService.Realization;


namespace HiQo_Remote_Booking.ServiceProviderExtensions
{
    public static class NotificationServiceServiceProviderExtensions
    {
        public static void AddNotificationService(this IServiceCollection services)
        {
            services.AddSingleton<EmailService.Interfaces.IEmailService, EmailService.Service.EmailService>();
            services.AddSingleton<HiQoKerioConnectCalendarApiClient.Interfaces.ICalendrAPIClient, HiQoKerioConnectCalendarApiClient.Client.HiQoCalendarApiClient>();
            services.AddSingleton<IOrderNotification, OrderNotificationService>();
        }
    }
}
