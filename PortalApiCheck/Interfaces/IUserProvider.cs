using System;
using System.Collections.Generic;
using System.Text;
using PortalApiCheck.Entity;

namespace PortalApiCheck.Interfaces
{
    internal interface IUserProvider
    {

        public IEnumerable<UserInfo> GetAllUsers();

        public UserInfo GetUserByCredentials(string email, string password);

        public UserInfo GetUserByGuid(string guid);
    }
}
