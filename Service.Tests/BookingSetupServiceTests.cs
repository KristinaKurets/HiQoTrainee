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

namespace Service.Tests
{
    public class BookingSetupServiceTests
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private BookingSetupService bookingSetupService;
        private TestCaseClass t;
       
        
        [SetUp]
        public void Setup()
        {
            t = new TestCaseClass();
            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                Rooms = t.RoomList(),
                BookingInfo = t.BookingInfoList(),
                
            };

            ServiceTestHelper.MockRepository(out unitOfWorkMock, repositoryDescriptor);
            bookingSetupService = new BookingSetupService(unitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(TestCaseClass), "BookingInfoList")]
        public void Read_MockObject()
        {
            var bookingInfos = t.BookingInfoList();
            var result = bookingSetupService.Read(bookingInfos[0].Room);
            Assert.AreEqual(result.RoomId, bookingInfos[0].RoomId);
        }
        
    }
}
