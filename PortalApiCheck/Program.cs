using PortalApiCheck.Core;
using PortalApiCheck.Extensions;
using System;

namespace PortalApiCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var login = "portal-api-reader@hiqo-solutions.com".EncodeToBase64();
            var password = "bb#6qZwdUs2HG61Gh$5".EncodeToBase64();
            PortalUserProviders userProviders = new PortalUserProviders("https://portal-api.hiqo-solutions.com/api/", login, password);
            userProviders.GetAllUsers();
        }
    }
}
