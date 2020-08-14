using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace HiQo_Remote_Booking.ServiceProviderExtensions
{
    public static class UnitOfWokrServiceProviderExtensions
    {
        public static void AddUnitOfWorkAndRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }
    }
}
