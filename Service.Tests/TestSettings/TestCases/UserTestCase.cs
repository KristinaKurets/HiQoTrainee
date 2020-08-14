using DB.Entity;
using DB.EntityStatus;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests.TestSettings.TestCases
{
    public class UserTestCase
    {
        private static readonly IList<User> TestUsers = new User[]
        {
             new User 
             {
                 Id = 1, 
                 FirstName = "James", 
                 LastName = "Brown", 
                 Email = "jamesBrown@gmail.com",
                 Position = new UserPosition(),
                 Role = UserRole.User,
                 WorkPlan = new WorkPlan(),
                 Orders = new List<Order>(),
                 Room = new Room()
             },
             new User 
             {
                 Id = 2, 
                 FirstName = "Eddie", 
                 LastName = "Murphy", 
                 Email = "eddieMurphy@gmail.com",
                 Position = new UserPosition(),
                 Role = UserRole.User,
                 WorkPlan = new WorkPlan(),
                 Orders = new List<Order>(),
                 Room = new Room()
             },
             new User 
             {
                 Id = 3, 
                 FirstName = "Freddie", 
                 LastName = "Merqury", 
                 Email = "freddieMercury@gmail.com",
                 Position = new UserPosition(),
                 Role = UserRole.User,
                 WorkPlan = new WorkPlan(),
                 Orders = new List<Order>(),
                 Room = new Room()
             }

        };
        public static IEnumerable<TestCaseData> UsersReadAllCase
        {
            get
            {
                yield return new TestCaseData(TestUsers).Returns(TestUsers.Count);
                yield return new TestCaseData(new List<User>()).Returns(0);
                yield return new TestCaseData(null).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> UsersUpdateCase
        {
            get
            {
                yield return new TestCaseData(TestUsers).Returns("example@gmail.com");
                yield return new TestCaseData(new List<User>()).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null).Returns(typeof(NullReferenceException));
            }
        }

        public static IEnumerable<TestCaseData> UsersCreateCase
        {
            get
            {
                yield return new TestCaseData(TestUsers).Returns(TestUsers.Count + 1);
                yield return new TestCaseData(new List<User>()).Returns(1);
                yield return new TestCaseData(null).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> UserDeleteCase
        {
            get
            {
                yield return new TestCaseData(TestUsers).Returns(TestUsers.Count - 1);
                yield return new TestCaseData(new List<User>()).Returns(0);
                yield return new TestCaseData(null).Returns(0);
            }
        }
    }
}
