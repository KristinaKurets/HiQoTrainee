using System.Configuration;
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
using Repository.UnitOfWork;

namespace DbScheduler
{
    public class Program
    {
        private static readonly string url = Resource.url;
        private static readonly string login = Resource.login.EncodeToBase64();
        private static readonly string password = Resource.password.EncodeToBase64();
        private static readonly string connection = Resource.connection;


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
                    services.AddSingleton<IUnitOfWork, UnitOfWork>(provider => 
                        new UnitOfWork(new HqrbContext(new DbContextOptionsBuilder<HqrbContext>().UseSqlServer(connection).Options)));
                    services.AddHostedService<Worker>();
                })
                .UseWindowsService();
    }
}
