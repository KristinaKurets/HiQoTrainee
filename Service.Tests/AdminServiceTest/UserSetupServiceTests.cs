using System.Linq;
using DB.Entity;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.Realization;

namespace Service.Tests.AdminServiceTest
{
    public class UserSetupServiceTests
    {
        private IQueryable<User> GetTestUsers()
        {
            return new User[]
            {
                new User {Id = 1, FirstName = "James", LastName = "Brown", Email = "jamesBrown@gmail.com"},
                new User {Id = 2, FirstName = "Eddie", LastName = "Murphy", Email = "eddieMurphy@gmail.com"},
                new User {Id = 3, FirstName = "Freddie", LastName = "Merqury", Email = "freddieMercury@gmail.com"}

            }.AsQueryable();
        }
        private Mock<IUnitOfWork> unitOfWorkMock;

        [SetUp]
        public void SetUp()
        {
            var userSetupServiceMock = new Mock<IRepository<User>>();
            unitOfWorkMock = new Mock<IUnitOfWork>();

            userSetupServiceMock.Setup(x => x.ReadAll()).Returns(GetTestUsers());
            unitOfWorkMock.Setup(x => x.Save());
            unitOfWorkMock.Setup(x => x.GetRepository<User>()).Returns(userSetupServiceMock.Object);
        }

        [Test]
        public void ReadAll_Test()
        {
            var userSetupService = new UserSetupService(unitOfWorkMock.Object);
            var result = userSetupService.ReadAll();
            Assert.AreEqual(result.Count(), userSetupService.ReadAll().Count());
        }
    }
}
