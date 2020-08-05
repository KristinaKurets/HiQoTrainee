using DB.Entity;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.Realization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tests
{
    public class BookingSetupServiceTests
    {
        private Mock<IUnitOfWork> unitOfWorkMock;

        [SetUp]
        public void Setup()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookingInfoMock = new Mock<IRepository<BookingInfo>>();

            bookingInfoMock.Setup(r => r.Read(It.IsAny<int>())).Returns(new BookingInfo { Id = It.IsAny<int>() });
            unitOfWorkMock.Setup(x => x.Save());
            unitOfWorkMock.Setup(x => x.GetRepository<BookingInfo>()).Returns(bookingInfoMock.Object);
        }

        [Test]
        public void Read_MockObject()
        {
            var bookingSetupService = new BookingSetupService(unitOfWorkMock.Object);
            var room = new Room
            {
                Id = 1,
                Title = "title",

            };
            var result = bookingSetupService.Read(room);
            Assert.Equals(result.Id, bookingSetupService.Read(room).Id);
        }

    }
}
