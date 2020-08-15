using System;
using System.Collections.Generic;
using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
using NUnit.Framework;

namespace Service.Tests.TestSettings.TestCases
{
    public class DeskTestCase
    {
        private static readonly IList<Desk> Desks = new List<Desk> {
            new Desk
            {
                Id=1,
                Title= "Tom",
                Orders = new List<Order>(),
                RoomId = 1,
                Status = DeskStatus.Fixed,
                User =  new User(),
            },
            new Desk
            {
                Id=2,
                Title="Alice",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                User =  new User(),
            },
            new Desk
            {
                Id=3,
                Title="Sam",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                User =  new User(),
            },
            new Desk
            {
                Id=4,
                Title="Kate",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                User =  new User(),
            }
        };
        private static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "dskjdjsk@gmail.com",
                FirstName = "Di",
                LastName = "Aristova",
                UserPositionId = 2,
                Role = UserRole.User,

            },
            new User()
            {
                Id = 2,
                Email = "dskjdjsk12@gmail.com",
                FirstName = "Dima",
                LastName = "Aristov",
                UserPositionId = 1,
                Role = UserRole.User,
            }
        };

        private static readonly IList<DeskStatusLookup> deskStatusLookups = new List<DeskStatusLookup>
        {
            new DeskStatusLookup()
            {
                Desks = Desks,
                ID = 1,
                Status = "Fix",
            }
        };

        public static IEnumerable<TestCaseData> DesksReadAllCase
        {
             get
             {
                 yield return new TestCaseData(Desks).Returns(Desks.Count);
                 yield return new TestCaseData(new List<Desk>()).Returns(0);
                 yield return new TestCaseData(null).Returns(0);
             }
        }

        public static IEnumerable<TestCaseData> DesksUpdateCase
        {
            get
            {
                yield return new TestCaseData(Desks).Returns("title");
                yield return new TestCaseData(new List<Desk>()).Returns(null);
                yield return new TestCaseData(null).Returns(null);
            }
        }

        public static IEnumerable<TestCaseData> DesksCreateCase
        {
            get
            {
                yield return new TestCaseData(Desks, users).Returns(Desks.Count + 1);
                yield return new TestCaseData(new List<Desk>(), users).Returns(1);
                yield return new TestCaseData(null, users).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> DeskDeleteCase
        {
            get
            {
                yield return new TestCaseData(Desks).Returns(Desks.Count - 1);
                yield return new TestCaseData(new List<Desk>()).Returns(0);
                yield return new TestCaseData(null).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> DeskGetDesksLookupCase
        {
            get
            {
                yield return new TestCaseData(Desks, deskStatusLookups).Returns(deskStatusLookups.Count);
                yield return new TestCaseData(new List<Desk>(), new List<DeskStatusLookup>()).Returns(0);
                yield return new TestCaseData(null, null).Returns(0);
            }
        }
    }
}

