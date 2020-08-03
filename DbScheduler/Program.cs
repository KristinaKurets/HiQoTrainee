using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalApiCheck.Core;
using PortalApiCheck.Extensions;
using PortalApiCheck.Interfaces;
using Repository.Interface;
using Repository.Repositories;

namespace DbScheduler
{
    public class Program
    {
        private static readonly string url = "https://portal-api.hiqo-solutions.com/api/";
        private static readonly string login = "portal-api-reader@hiqo-solutions.com".EncodeToBase64();
        private static readonly string password = "bb#6qZwdUs2HG61Gh$5".EncodeToBase64();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IUserProvider, PortalUsersProvider>(x =>
                        new PortalUsersProvider(url, login, password));
                    services.AddSingleton<DbContext, HqrbContext>();
                    services.AddSingleton<IRepository<User>, UniqueUserRepository>(serviceProvider =>
                        new UniqueUserRepository(new Repository<User>(serviceProvider.GetRequiredService<DbContext>())));
                    services.AddHostedService<Worker>();
                });
    }
}
