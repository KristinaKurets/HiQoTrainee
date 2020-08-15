using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB.Entity;
using DB.EntityStatus;
using NUnit.Framework;
using Service.AdminService.DTO.Entities;

namespace Service.Tests.TestSettings.TestCases
{
    class AdminUserTestCase
    {
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

        private static List<UserDto> usersDto = new List<UserDto>()
        {
            new UserDto()
            {
                Id = 1,
                Email = "dskjdjsk@gmail.com",
                FirstName = "Di",
                LastName = "Aristova",
                UserPositionId = 2,
            },
            new UserDto()
            {
                Id = 2,
                Email = "dskjdjsk12@gmail.com",
                FirstName = "Dima",
                LastName = "Aristov",
                UserPositionId = 1,
            }
        };

        private static List<WorkingDaysCalendar> workingDays = new List<WorkingDaysCalendar>()
        {
            new WorkingDaysCalendar()
            {
                Date = DateTime.Now,
                Id = 1,
                IsOff = false,
            },
            new WorkingDaysCalendar()
            {
                Date = new DateTime(2020,07,01),
                Id = 2,
                IsOff = true

            }
        };

        public static IEnumerable<TestCaseData> GetAllUsers
        {
            get
            {
                yield return new TestCaseData(users).Returns(users.Count);
                yield return new TestCaseData(null).Returns(0);
                yield return new TestCaseData(new List<User>()).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> OrderUsersBySomeKey
        {
            get
            {
                Func<UserDto, int> p1 = (x) => x.Id;
                Func<UserDto, int> p2 = (x) => x.UserPositionId;

                yield return new TestCaseData(users, p1 ).Returns(users[0].Id);
                yield return new TestCaseData(users, p2 ).Returns(users[1].Id);
                yield return new TestCaseData(new List<User>(), p1).Returns(null);
                yield return new TestCaseData(null, p1).Returns(null);
            }
        }

        public static IEnumerable<TestCaseData> FilterBySomeKey
        {
            get
            {
                Func<UserDto, bool> p1 = (x) => x.Id == 1;
                Func<User, bool> pTest = (x) => x.Id == 1;
                yield return new TestCaseData(p1, usersDto, users).Returns(usersDto.Where(p1).Count());
                yield return new TestCaseData(p1, new List<UserDto>(), new List<User>()).Returns(0);
                yield return new TestCaseData(p1, null, null).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> UpdateWorkPlan
        {
            get
            {
                var workPlan = new WorkPlan()
                {
                    Id = 1,
                    DeskGuaranteed = true,
                    MaxOfficeDay = 10,
                    MinOfficeDay = 1,
                    PlanDescription = "desc",
                    Plan = "plan",
                };

                yield return new TestCaseData(users, workPlan).Returns(workPlan.Plan);
                yield return new TestCaseData(new List<User>(), workPlan).Returns(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(users, null).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null, workPlan).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null, null).Returns(typeof(NullReferenceException));
            }
        }

        public static IEnumerable<TestCaseData> UpdateDesk
        {
            get
            {
                var desk = new Desk
                {
                    Id = 1,
                    Title = "Tom",
                    Orders = new List<Order>(),
                    RoomId = 1,
                    Status = DeskStatus.Fixed,
                    Users = new List<User>(),
                };

                yield return new TestCaseData(users, desk).Returns(desk.Title);
                yield return new TestCaseData(new List<User>(), desk).Returns(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(users, null).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null, desk).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null, null).Returns(typeof(NullReferenceException)); 
            }
        }

        public static IEnumerable<TestCaseData> GetWorkingDayCalendars
        {
            get
            {
                yield return new TestCaseData(users, workingDays).Returns(workingDays.Count);
                yield return new TestCaseData(users, new List<WorkingDaysCalendar>()).Returns(0);
                yield return new TestCaseData(users, null).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> SetDayOff
        {
            get
            {
                yield return new TestCaseData(users, workingDays).Returns(workingDays[0].IsOff);
                yield return new TestCaseData(users, new List<WorkingDaysCalendar>()).Returns(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(users, null).Returns(typeof(NullReferenceException));
            }
        }
    }
}
