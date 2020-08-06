using DB.Entity;
using DB.LookupTable;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository.Repositories;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.ServiceProviderExtensions
{
    public static class UnitOfWorkServiceProviderExtensions
    {

        public static void AddUnitOfWorkAndRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<BookingInfo>, Repository<BookingInfo>>();
            services.AddScoped<IRepository<Desk>, Repository<Desk>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<Room>, Repository<Room>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<UserPosition>, Repository<UserPosition>>();
            services.AddScoped<IRepository<WorkingDaysCalendar>, Repository<WorkingDaysCalendar>>();
            services.AddScoped<IRepository<BookingStatusLookup>, Repository<BookingStatusLookup>>();
            services.AddScoped<IRepository<DeskStatusLookup>, Repository<DeskStatusLookup>>();
            services.AddScoped<IRepository<UserRoleLookup>, Repository<UserRoleLookup>>();
        }
    }
}
