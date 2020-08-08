using System;
using System.Collections.Generic;
using System.Text;

namespace PortalApiCheck.Entity
{
    public class PortalProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Birthday { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
    }
}
