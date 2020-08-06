using System;
using DB.Context;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.AdminService.Services;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connection = "Server=tcp:hqrb.database.windows.net,1433;Initial Catalog=hqrbSolutions;Persist Security Info=False;User ID=HiQo;Password=Solutions2007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Console.WriteLine("Hello World!");
            var options = new DbContextOptionsBuilder<HqrbContext>().UseSqlServer(connection);
            var context = new HqrbContext(options.Options);
            using var unit = new UnitOfWork(context);
            var service = new AdminService(unit);
            var users = service.GetRooms();
            Console.ReadKey();
        }
    }
}
