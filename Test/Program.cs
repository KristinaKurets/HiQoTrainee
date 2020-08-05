using DB.Context;
using DB.Entity;
using DB.EntityStatus;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.UnitOfWork;
using Service.AdminService.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Server=tcp:hqrb.database.windows.net,1433;Initial Catalog=hqrbSolutions;Persist Security Info=False;User ID=HiQo;Password=Solutions2007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            var options = new DbContextOptionsBuilder<HqrbContext>().UseSqlServer(connection);
            var context = new HqrbContext(options.Options);
            using (var unit = new UnitOfWork(context))
            {

                //var adminService = new AdminService(unit);
                //var users = adminService.GetUsers();
                //var position = new UserPosition()
                //{
                //    Type = "Jora"
                //};
                var repository = unit.GetRepository<User>();
                var users = repository.ReadAll().ToList();
                //repository.Create(position);
                //unit.Save();
            }
            Console.ReadKey();
        }
    }
}
