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
        private IQueryable<WorkPlan> GetTestWorkplans()
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
            var workPlanServiceMock = new Mock<IRepository<WorkPlan>>();
            unitOfWorkMock = new Mock<IUnitOfWork>();

            workPlanServiceMock.Setup(x => x.ReadAll()).Returns(GetTestWorkplans());
            unitOfWorkMock.Setup(x => x.Save());
            unitOfWorkMock.Setup(x => x.GetRepository<WorkPlan>()).Returns(workPlanServiceMock.Object);
        }

        [Test]
        public void ReadAll_Test()
        {
            var workPlanService = new WorkPlanService(unitOfWorkMock.Object);
            var result = workPlanService.ReadAll();
            Assert.AreEqual(result.Count(), workPlanService.ReadAll().Count());
        }
    }
}
