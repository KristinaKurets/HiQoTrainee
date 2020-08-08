using DB.Entity;
using DB.EntityStatus;
using Microsoft.Extensions.Options;
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
using Service.Tests.TestSettings;

namespace Service.Tests
{
    public class BookingSetupServiceTests
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private BookingSetupService bookingSetupService;

        [SetUp]
        public void Setup()
        {
            
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Rooms = TestCaseClass.RoomList(),
                BookingInfo = TestCaseClass.BookingInfos(),

            };

            ServiceTestHelper.MockRepository(out unitOfWorkMock, repositoryDescriptor);
            bookingSetupService = new BookingSetupService(unitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(TestCaseClass), nameof(TestCaseClass.BookingInfoTest))]
        public int Read_MockObject(IList<BookingInfo> bookingInfos)
        {
            var result = bookingSetupService.Read(bookingInfos[0].Room);
            return result.RoomId;
        }
        
    }
}
