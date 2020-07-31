using System;
using System.Collections.Generic;
using System.Text;

namespace PortalApiCheck.Entity
{
    public class UserInfo
    {
        public string Guid { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Birthdate { get; set; }

        public string Category { get; set; }

        public string Level { get; set; }

        public string Status { get; set; }

        public UserInfo(string guid, string email, string firstName, string lastName, string birthdate, string category, string level, string status)
        {
            Guid = guid;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Category = category;
            Level = level;
            Status = status;
        }
    }
}
