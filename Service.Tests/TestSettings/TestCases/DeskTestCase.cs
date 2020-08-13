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
        private static readonly IList<Desk> Desks = new Desk[] {
            new Desk
            {
                Id=1,
                Title= "Tom",
                Orders = new List<Order>(),
                RoomId = 1,
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            },
            new Desk
            {
                Id=2,
                Title="Alice",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            },
            new Desk
            {
                Id=3,
                Title="Sam",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            },
            new Desk
            {
                Id=4,
                Title="Kate",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            }
        };

        private static readonly IList<DeskStatusLookup> deskStatusLookups = new DeskStatusLookup[]
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
                yield return new TestCaseData(new List<Desk>()).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null).Returns(typeof(NullReferenceException));
            }
        }

        public static IEnumerable<TestCaseData> DesksCreateCase
        {
            get
            {
                yield return new TestCaseData(Desks).Returns(Desks.Count + 1);
                yield return new TestCaseData(new List<Desk>()).Returns(1);
                yield return new TestCaseData(null).Returns(1);
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

