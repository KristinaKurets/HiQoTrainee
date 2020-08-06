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
        private IList<BookingInfo> bookingInfos;
        [SetUp]
        public void Setup()
        {
            Room room = new Room()
            {
                Id = 1
            };
            var rooms = new List<Room>()
            {
                room,
            };

            var bookingInfo = new BookingInfo()
            {
                Id = 1,
                RoomId = room.Id,
                Room = room,
            };

            bookingInfos = new List<BookingInfo>()
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
        }

            [Test]
        public void Read_MockObject()
        {
            var result = bookingSetupService.Read(bookingInfos[0].Room);
            Assert.AreEqual(result.RoomId, bookingInfos[0].RoomId);
        }
        
    }
}
