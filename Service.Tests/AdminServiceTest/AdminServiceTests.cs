using DB.Entity;
using NUnit.Framework;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests.AdminServiceTest
{
    class AdminServiceTests
    {
        private RepositoryMockResult _mockResult;
        private AdminService.Services.AdminService _adminService;

        public void Setup(IList<User> users = null, IList<WorkingDaysCalendar> workingDays = null, IList<Desk> desks=null)
        {
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                WorkingDaysCalendar = workingDays
            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            _adminService = new AdminService.Services.AdminService(_mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.GetAllUsers))]
        public int GetUsersTest(IList<User> users)
        {
            Setup(users);

            var result = _adminService.GetUsers();

            return result.Count;
        }


        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.OrderUsersBySomeKey))]
        public int? OrderUsersBySomeKey(IList<User> users, Func<User, int> predicate)
        {
            Setup(users);

            var result = _adminService.OrderUsersBy(predicate);

            return result.First()?.Id;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.FilterBySomeKey))]
        public int? FilterBySomeKey(Func<User, bool> func, List<User> users)
        {
            Setup(users);

            var result = _adminService.FilterBy(func, users);

            return result.Count;

        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.UpdateWorkPlan))]
        public string UpdateWorkPlan(List<User> users,WorkPlan workPlan)
        {
            Setup(users);
           
            _adminService.UpdateWorkPlan(users[0], workPlan);

            return users[0].WorkPlan.Plan;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.UpdateDesk))]
        public string UpdateDesk(List<User> users, Desk desk)
        {
            Setup(users);

            _adminService.UpdateDesk(users[0], desk);

            return users[0].Desk.Title;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.GetWorkingDayCalendars))]
        public int GetWorkingDayCalendars(List<User> users, List<WorkingDaysCalendar> workingDays)
        {
            Setup(users, workingDays);

            var result = _adminService.GetWorkingDayCalendars();

            return result.Count;
        }

        [Test, TestCaseSource(typeof(AdminUserTestCase), nameof(AdminUserTestCase.SetDayOff))]
        public bool SetDayOff(List<User> users, List<WorkingDaysCalendar> workingDays)
        {
            Setup(users, workingDays);

            _adminService.SetDayOff(workingDays[0]);

            return workingDays[0].IsOff;
        }
    }
}
