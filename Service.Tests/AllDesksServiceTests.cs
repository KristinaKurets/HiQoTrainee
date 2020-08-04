using System.Collections.Generic;
using System.Linq;
using DB.Context;
using DB.Entity;
using DB.EntityStatus;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.EntitiesStatuses;
using Service.AdminService.Realization;

namespace Service.Tests
{
    public class AllDesksServiceTests
    {
        private IQueryable<Desk> desks = new Desk[] {
            new Desk { Id=1, Title= "Tom"},
            new Desk { Id=2, Title="Alice"},
            new Desk { Id=3, Title="Sam"},
            new Desk { Id=4, Title="Kate"}
        }.AsQueryable();

        private Mock<IUnitOfWork> unitOfWorkMock;
        private AllDesksService allDesksService;

        [SetUp]
        // вызывается перед каждым тестовым методом
        public void Setup()
        {
            // мы их мокаем для того чтоб мы могли написать поведение методов, которые используется в самом классе
            unitOfWorkMock = new Mock<IUnitOfWork>();
            var desksRepositoryMock = new Mock<IRepository<Desk>>();
            
            // написали что должен вернуть метод класса IRepository<Desk>.RedAll.
            desksRepositoryMock.Setup(r => r.ReadAll()).Returns(desks);
            desksRepositoryMock.Setup(r => r.Update(It.IsAny<Desk>()))
                .Callback<Desk>(d => desks.ToList().Add(d));

            unitOfWorkMock.Setup(x => x.Save());
            unitOfWorkMock.Setup(x => x.GetRepository<Desk>()).Returns(desksRepositoryMock.Object);

            // Класс для тестирования.
            allDesksService = new AllDesksService(unitOfWorkMock.Object);

        }


        [Test]
        public void ReadAll_ReturnDesks()
        {
            // то что тестируем
            var result = allDesksService.ReadAll();

            // проверка
            Assert.Equals(result.Count(), desks.Count());
        }

        [Test]
        public void UpdateDesk_Desk_ListDesks()
        {
            var room = new Room()
            {
                Id = 1,
                BookingCalendars = new List<WorkingDaysCalendar>(),
                Users = new List<User>(),
                Desks = new List<Desk>()
            };

            var bookingInfo = new BookingInfo
            {
                Id = 1,
                Room = room
            };

            room.BookingInfo = bookingInfo;

            var testDesk = new Desk
            {
                Id = 1,
                Title = "La",
                Room = room,
                Orders = new List<Order>(),
                Status = DeskStatus.Available,
                Users = new List<User>()
            };

           

            var testDeskDto = (DeskDto) testDesk;

            var result = allDesksService.UpdateDesks(testDeskDto);

            Assert.Equals(result.First(i => i.Id == 1).Title, testDesk.Title);
        }
    }
}