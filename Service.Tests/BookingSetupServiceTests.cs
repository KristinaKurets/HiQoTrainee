using DB.Entity;
using DB.EntityStatus;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.Interfaces;
using Service.AdminService.Realization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tests
{
    public class BookingSetupServiceTests
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private BookingSetupService bookingSetupService;
        private RoomDto room = new RoomDto()
        {
            Id = 1
        };

        [SetUp]
        public void Setup()
        {
            Room room = new Room();
            var rooms = new List<Room>()
            {
                room,
            };

            var bookingInfo = new BookingInfo()
            {
                Id = 1,
                Room = room,
            };

            var bookingInfos = new List<BookingInfo>()
            {
                bookingInfo
            };
            room.BookingInfo = bookingInfo;

            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                BookingInfo = bookingInfos,
                Rooms = rooms,
            };

            ServiceTestHelper.MockRepository(out unitOfWorkMock, repositoryDescriptor);
            bookingSetupService = new BookingSetupService(unitOfWorkMock.Object);


            //    unitOfWorkMock = new Mock<IUnitOfWork>();

            //    var bookingInfoMock = new Mock<IRepository<BookingInfo>>();
            //    bookingInfoMock.Setup(r => r.Read(room)).Returns(new BookingInfo() { RoomId = 1 });

            //    unitOfWorkMock.Setup(x => x.Save());
            //    unitOfWorkMock.Setup(x => x.GetRepository<BookingInfo>()).Returns(bookingInfoMock.Object);
            //    bookingSetupService = new BookingSetupService(unitOfWorkMock.Object);
        }

            [Test]
        public void Read_MockObject()
        {
            
            var result = bookingSetupService.Read(room);
            Assert.Equals(result.Id, bookingSetupService.Read(room).Id);
        }

    }
}
