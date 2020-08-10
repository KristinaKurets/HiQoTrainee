using System.Collections.Generic;
using DB.Entity;
using NUnit.Framework;
using Service.AdminService.Realization;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class BookingSetupServiceTests
    {
        private BookingSetupService bookingSetupService;
        private RepositoryMockResult mockResult;

        [SetUp]
        public void Setup()
        {
            
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Rooms = BookingTestCase.RoomList(),
                BookingInfo = BookingTestCase.BookingInfos(),

            };

            mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            
            bookingSetupService = new BookingSetupService(mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingInfoTest))]
        public int Read_MockObject(IList<BookingInfo> bookingInfos)
        {
            var result = bookingSetupService.Read(bookingInfos[0].Room);
            return result.RoomId;
        }
        
    }
}
