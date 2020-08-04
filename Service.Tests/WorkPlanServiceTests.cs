using DB.Entity;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests
{
    public class WorkPlanServiceTests
    {
        private IQueryable<WorkPlan> GetTestUsers()
        {
            return new WorkPlan[]
            {
                new WorkPlan {Id = 1},
                new WorkPlan {Id = 2 },
                new WorkPlan {Id = 3}

            }.AsQueryable();
        }
        private Mock<IUnitOfWork> unitOfWorkMock;

        [SetUp]
        public void SetUp()
        {
            var userSetupServiceMock = new Mock<IRepository<WorkPlan>>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            userSetupServiceMock.Setup(x => x.ReadAll()).Returns(GetTestUsers());
            userSetupServiceMock.Setup(x => x.Create(It.IsAny<WorkPlan>()));
            unitOfWorkMock.Setup(x => x.Save());
            unitOfWorkMock.Setup(x => x.GetRepository<WorkPlan>()).Returns(userSetupServiceMock.Object);
        }

        [Test]
        public void ReadAll_Test()
        {
            var userSetupService = new UserSetupService(unitOfWorkMock.Object);
            var result = userSetupService.ReadAll();
            Assert.Equals(result.Count(), userSetupService.ReadAll().Count());
        }
    }
}
