using System;
using System.Collections.Generic;
using System.Text;

namespace PortalApiCheck.Entity
{
    public class PortalAuthorizationInfo
    {
        public string Token { get; set; }

        public string TokenType { get; set; }

        public string ExpiresIn { get; set; }
    }
}
