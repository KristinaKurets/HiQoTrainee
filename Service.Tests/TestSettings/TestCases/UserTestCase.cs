using DB.Entity;
using DB.EntityStatus;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Service.Tests.TestSettings.TestCases
{
    public class UserTestCase
    {
        private static readonly IList<Desk> Desks = new List<Desk>
        {
            new Desk
            {
                Id=1,
                Title= "Tom",
                Orders = new List<Order>(),
                RoomId = 1,
                Status = DeskStatus.Fixed,
            },
            new Desk
            {
                Id=2,
                Title="Alice",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
            },
            new Desk
            {
                Id=3,
                Title="Sam",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
            },
        };

        private static readonly IList<Room> Rooms = new List<Room>
        {
            new Room()
            {
                Id = 1,
                BookingCalendars =  new List<WorkingDaysCalendar>(),
                Desks = Desks,
                Floor = 1,
            }
        };

        private static readonly IList<WorkPlan> WorkPlansList = new List<WorkPlan>()
        {
            new WorkPlan()
            {
                Id = 1,
                DeskGuaranteed = true,
                MaxOfficeDay = 30,
                MinOfficeDay = 12,
                Plan = "plan",
                PlanDescription = "desc",
                Priority = 1
            },
            new WorkPlan()
            {
                Id = 2,
                DeskGuaranteed = false,
                MaxOfficeDay = 30,
                MinOfficeDay = 12,
                Plan = "plan",
                PlanDescription = "desc",
                Priority = 2
            }
        };

        private static readonly IList<UserPosition> userPositions = new List<UserPosition>()
        {
            new UserPosition()
            {
                Id = 1,
                Type = "Bla",

            },
            new UserPosition()
            {
                Id = 2,
                Type = "La",
            },
            new UserPosition()
            {
                Id = 3,
                Type = "Lala",
            }
        };
        private static readonly IList<User> TestUsers = new List<User>
        {
             new User 
             {
                 Id = 1, 
                 FirstName = "James", 
                 LastName = "Brown", 
                 Email = "jamesBrown@gmail.com",
                 UserPositionId = 1,
                 Role = UserRole.User,
                 WorkPlan = WorkPlansList[1],
                 Orders = new List<Order>(),
                 Room = Rooms[0],
                 DeskId = 1,

             },
             new User 
             {
                 Id = 2, 
                 FirstName = "Eddie", 
                 LastName = "Murphy", 
                 Email = "eddieMurphy@gmail.com",
                 UserPositionId = 2,
                 Role = UserRole.User,
                 WorkPlan = WorkPlansList[0],
                 Orders = new List<Order>(),
                 Room = Rooms[0],
                 DeskId = 2,
             },
             new User 
             {
                 Id = 3, 
                 FirstName = "Freddie", 
                 LastName = "Merqury", 
                 Email = "freddieMercury@gmail.com",
                 UserPositionId = 2,
                 Role = UserRole.User,
                 WorkPlan = WorkPlansList[1],
                 Orders = new List<Order>(),
                 Room = Rooms[0],
                 DeskId = 3,
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
                yield return new TestCaseData(TestUsers, userPositions, WorkPlansList, Desks, Rooms).Returns(TestUsers.Count + 1);
                yield return new TestCaseData(new List<User>(), new List<UserPosition>(), new List<WorkPlan>(), new List<Desk>(), new List<Room>()).Returns(1);
                yield return new TestCaseData(null, null, null, null, null).Returns(1);
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
