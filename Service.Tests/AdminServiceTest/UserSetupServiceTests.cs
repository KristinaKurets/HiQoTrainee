using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using NUnit.Framework;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class UserSetupServiceTests
    {
        private AdminService.Services.AdminService _adminService;
        private RepositoryMockResult _mockResult;

        public void Setup(IList<User> users, IList<UserPosition> userPositions=null, IList<WorkPlan> workPlans=null, IList<Desk> desks=null, IList<Room> rooms = null)
        {

            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                UsersPosition = userPositions,
                WorkPlans = workPlans,
                Desks = desks,
                Rooms = rooms,
            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);
            _adminService = new AdminService.Services.AdminService(_mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(UserTestCase), nameof(UserTestCase.UsersReadAllCase))]
        public int ReadAll_Users(IList<User> users)
        {
            Setup(users);
            var result = _adminService.GetUsers();
            return result.Count;
        }

        [Test, TestCaseSource(typeof(UserTestCase), nameof(UserTestCase.UsersUpdateCase))]
        public string Update_Users(IList<User> users)
        {
            Setup(users);
            var testUser = new User()
            {
                FirstName = "Nicola",
                LastName = "Tesla",
            };
            var result = _adminService.UpdateUser(testUser);
            return result.First(i => i.Id == testUser.Id).Email;
        }

        [Test, TestCaseSource(typeof(UserTestCase), nameof(UserTestCase.UsersCreateCase))]
        public int Create_User(IList<User> users, IList<UserPosition> userPositions, IList<WorkPlan> workPlans, IList<Desk> desks, IList<Room> rooms)
        {
            Setup(users, userPositions, workPlans, desks, rooms);
            var testUser = new User()
            {
                FirstName = "Nicola",
                LastName = "Tesla",
                RoomId = 1,
                DeskId = 1,
                WorkPlanId = 1,
            };
            var result = _adminService.CreateUser(testUser);
            return result.Count;
        }
    }
}
