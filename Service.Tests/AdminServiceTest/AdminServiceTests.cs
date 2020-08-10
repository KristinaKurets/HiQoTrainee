using DB.Entity;
using NUnit.Framework;
using Service.AdminService.DTO.Entities;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests.AdminServiceTest
{
    class AdminServiceTests
    {
        private RepositoryMockResult mockResult;
        private AdminService.Services.AdminService adminService;

        public void Setup(IList<User> users = null, IList<WorkingDaysCalendar> workingDays = null)
        {
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                WorkingDaysCalendar = workingDays,
            };

            mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            adminService = new AdminService.Services.AdminService(mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.GetAllUsers))]
        public int GetUsersTest(IList<User> users)
        {
            Setup(users);

            var result = adminService.GetUsers();

            return result.Count;
        }


        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.OrderUsersBySomeKey))]
        public int? OrderUsersBySomeKey(IList<User> users, Func<UserDto, int> predicate)
        {
            Setup(users);

            var result = adminService.OrderUsersBy(predicate);

            return result.First()?.Id;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.FilterBySomeKey))]
        public int? FilterBySomeKey(Func<UserDto, bool> func, List<UserDto> usersDto, List<User> users)
        {
            Setup(users);

            var result = adminService.FilterBy(func, usersDto);

            return result.Count;

        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.UpdateWorkPlan))]
        public string UpdateWorkPlan(List<User> users,WorkPlan workPlan)
        {
            Setup(users);
           
            adminService.UpdateWorkPlan(users[0], workPlan);

            return users[0].WorkPlan.Plan;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.UpdateDesk))]
        public string UpdateDesk(List<User> users, Desk desk)
        {
            Setup(users);

            adminService.UpdateDesk(users[0], desk);

            return users[0].Desk.Title;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.GetWorkingDayCalendars))]
        public int GetWorkingDayCalendars(List<User> users, List<WorkingDaysCalendar> workingDays)
        {
            Setup(users, workingDays);

            var result = adminService.GetWorkingDayCalendars();

            return result.Count;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.SetDayOff))]
        public bool SetDayOff(List<User> users, List<WorkingDaysCalendar> workingDays)
        {
            Setup(users, workingDays);

            adminService.SetDayOff(workingDays[0]);

            return workingDays[0].IsOff;
        }
    }
}
