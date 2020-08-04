using System.Collections.Generic;
using System.Linq;
using DB.Context;
using DB.Entity;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.Realization;

namespace Service.Tests
{
    public class AllDesksServiceTests
    {
        private IQueryable<Desk> GetTestDesks()
        {
            return new Desk[]
            {
                new Desk { Id=1, Title= "Tom"},
                new Desk { Id=2, Title="Alice"},
                new Desk { Id=3, Title="Sam"},
                new Desk { Id=4, Title="Kate"}
            }.AsQueryable();
        }

        private Mock<IUnitOfWork> unitOfWorkMock;

        [SetUp]
        // вызывается перед каждым тестовым методом
        public void Setup()
        {
            // мы их мокаем для того чтоб мы могли написать поведение методов, которые используется в самом классе
            unitOfWorkMock = new Mock<IUnitOfWork>();
            var desksRepositoryMock = new Mock<IRepository<Desk>>();
            
            // написали что должен вернуть метод класса IRepository<Desk>.RedAll.
            desksRepositoryMock.Setup(r => r.ReadAll()).Returns(GetTestDesks());
            unitOfWorkMock.Setup(x => x.Save());
            unitOfWorkMock.Setup(x => x.GetRepository<Desk>()).Returns(desksRepositoryMock.Object);
        }

        [Test]
        public void ReadAll_ReturnDesks()
        {
            // Класс для тестирования.
            AllDesksService allDesksService = new AllDesksService(unitOfWorkMock.Object);

            // то что тестируем
            var result = allDesksService.ReadAll();

            // проверка
            Assert.Equals(result.Count(), GetTestDesks().Count());
        }
    }
}