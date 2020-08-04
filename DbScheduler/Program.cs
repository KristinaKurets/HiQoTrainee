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
        private static readonly string url = "https://portal-api.hiqo-solutions.com/api/";
        private static readonly string login = "portal-api-reader@hiqo-solutions.com".EncodeToBase64();
        private static readonly string password = "bb#6qZwdUs2HG61Gh$5".EncodeToBase64();
        private static readonly string connection = "Server=tcp:hqrb.database.windows.net,1433;Initial Catalog=hqrbSolutions;Persist Security Info=False;User ID=HiQo;Password=Solutions2007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


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
