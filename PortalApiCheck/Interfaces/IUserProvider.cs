using System;
using System.Collections.Generic;
using System.Text;
using DB.Entity;
using PortalApiCheck.Entity;

namespace PortalApiCheck.Interfaces
{
    public interface IUserProvider
    {

        public IEnumerable<User> GetAllUsers();

        public User GetUserByCredentials(string email, string password);

        public User GetUserByID(string guide);
    }
}
