using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests.TestSettings.TestCases
{
    public class UserTestCase
    {
        private IQueryable<User> GetTestUsers()
        {
            return new User[]
            {
                new User {Id = 1, FirstName = "James", LastName = "Brown", Email = "jamesBrown@gmail.com"},
                new User {Id = 2, FirstName = "Eddie", LastName = "Murphy", Email = "eddieMurphy@gmail.com"},
                new User {Id = 3, FirstName = "Freddie", LastName = "Merqury", Email = "freddieMercury@gmail.com"}

            }.AsQueryable();
        }
    }
}
