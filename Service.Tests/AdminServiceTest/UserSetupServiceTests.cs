using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using DB.LookupTable;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.Realization;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class UserSetupServiceTests
    {
        private UserSetupService userSetupService;
        private RepositoryMockResult mockResult;

        public void Setup(IList<User> users, IList<UserPosition> userPositions=null, IList<WorkPlan> workPlans=null, IList<Desk> desks=null)
        {

            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                UsersPosition = userPositions,
                WorkPlans = workPlans,
                Desks = desks
            };

            mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);
            userSetupService = new UserSetupService(mockResult.UnitOfWorkMock.Object);
        }

       [Test, TestCaseSource(typeof(UserTestCase), nameof(UserTestCase.UsersReadAllCase))]
        public int ReadAll_Users(IList<User> users)
        {
            Setup(users);
            var result = userSetupService.ReadAll();
            return result.Count();
        }

        [Test, TestCaseSource(typeof(UserTestCase), nameof(UserTestCase.UsersUpdateCase))]
        public string Update_Users(IList<User> users)
        {
            Setup(users);
            var testUser = new User()
            {
                FirstName = "Nicola",
                LastName = "Tesla"
            };
            var result = userSetupService.Update(testUser);
            return result.First(i => i.Id == testUser.Id).Email;
        }

        [Test, TestCaseSource(typeof(UserTestCase), nameof(UserTestCase.UsersCreateCase))]
        public int Create_User(IList<User> users, IList<UserPosition> userPositions, IList<WorkPlan> workPlans, IList<Desk> desks)
        {
            Setup(users, userPositions, workPlans, desks);
            var testUser = new User()
            {
                FirstName = "Nicola",
                LastName = "Tesla"
            };
            var result = userSetupService.Create(testUser);
            return result.Count;
        }
    }
}
