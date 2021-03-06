﻿using System;
using System.Collections.Generic;
using System.Text;
using DB.Entity;
using DB.EntityStatus;
using NUnit.Framework;

namespace Service.Tests.TestSettings.TestCases.BookingService
{
    class BookingManagementTestCase
    {
        private static readonly IList<Room> Rooms = new List<Room>
        {
            new Room()
            {
                Id = 1,
                BookingCalendars =  new List<WorkingDaysCalendar>()
                {
                    new WorkingDaysCalendar()
                    {
                        Id = 1,
                        Date = DateTime.Today.AddDays(1),
                        IsOff = false,
                        RoomId = 1
                    }
                },
                Floor = 1,
            }
        };

        private static readonly IList<Desk> Desks = new List<Desk>
        {
            new Desk
            {
                Id=1,
                Title= "Tom",
                Orders = new List<Order>(),
                RoomId = 1,
                Room = Rooms[0],
                Status = DeskStatus.Fixed,
            },
            new Desk
            {
                Id=2,
                Title="Alice",
                Orders = new List<Order>(),
                RoomId = 1,
                Room = Rooms[0],
                Status = DeskStatus.Fixed,
            },
            new Desk
            {
                Id=3,
                Title="Sam",
                Orders = new List<Order>(),
                RoomId = 1,
                Room = Rooms[0],
                Status = DeskStatus.Fixed,
            },
        };

        private static readonly IList<User> Users = new List<User>
        {
             new User
             {
                 Id = 1,
                 FirstName = "James",
                 LastName = "Brown",
                 Email = "jamesBrown@gmail.com",
                 UserPositionId = 1,
                 Role = UserRole.User,
                 Orders = new List<Order>(),
                 Room = Rooms[0],
                 DeskId = 1,
                 WorkPlan = new WorkPlan()
                 {
                     DeskGuaranteed = true, 
                     Id = 1,
                     Plan = "Office",
                     PlanDescription = "Mostly work from office",
                     Priority = 1
                 }
             },
             new User
             {
                 Id = 2,
                 FirstName = "Eddie",
                 LastName = "Murphy",
                 Email = "eddieMurphy@gmail.com",
                 UserPositionId = 2,
                 Role = UserRole.User,
                 Orders = new List<Order>(),
                 Room = Rooms[0],
                 DeskId = 2,
                 WorkPlan = new WorkPlan()
                 {
                     DeskGuaranteed = true,
                     Id = 1,
                     Plan = "Office",
                     PlanDescription = "Mostly work from office",
                     Priority = 1
                 }
             },
             new User
             {
                 Id = 3,
                 FirstName = "Freddie",
                 LastName = "Merqury",
                 Email = "freddieMercury@gmail.com",
                 UserPositionId = 2,
                 Role = UserRole.User,
                 Orders = new List<Order>(),
                 Room = Rooms[0],
                 DeskId = 3,
                 WorkPlan = new WorkPlan()
                 {
                     DeskGuaranteed = true,
                     Id = 1,
                     Plan = "Office",
                     PlanDescription = "Mostly work from office",
                     Priority = 1
                 }
             }

        };

        private static readonly IList<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                DeskId = 1,
                Status = BookingStatus.Booked,
                DateTime = DateTime.Today.AddDays(-1),
                UserId = 1,
                User = Users[0],
            }
        };

        private static readonly IList<BookingInfo> bookingInfos = new List<BookingInfo>
        {
            new BookingInfo()
            {
                Id = 1,
                DaysCloseForBooking = 1,
                DaysOpenForBooking = 5,
                TimeCloseForBooking = new TimeSpan(22,00,0),
                TimeOpenForBooking = new TimeSpan(10, 00, 0),
            }
        };

        public static IEnumerable<TestCaseData> CreteTestCase
        {
            get
            {
                yield return new TestCaseData(Users, Desks, Rooms, Orders, bookingInfos).Returns(true);
                yield return new TestCaseData(null, Desks, Rooms, Orders, bookingInfos).Returns(false);
                yield return new TestCaseData(Users, null, Rooms, Orders, bookingInfos).Returns(false);
                yield return new TestCaseData(Users, Desks, Rooms, new List<Order>(), bookingInfos).Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> CancelTestCase
        {
            get
            {
                yield return new TestCaseData(Users, Desks, Rooms, Orders).Returns(true);
                yield return new TestCaseData(null, Desks, Rooms, Orders).Returns(false);
                yield return new TestCaseData(Users, Desks, Rooms, null).Returns(false);
            }
        }
    }
}
