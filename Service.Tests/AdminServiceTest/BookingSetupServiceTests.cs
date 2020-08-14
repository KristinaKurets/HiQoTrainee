using System.Collections.Generic;
using System.Linq;
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

        public void Setup(IList<BookingInfo> bookingInfos, IList<Room> rooms = null)
        {
            
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Rooms = rooms,
                BookingInfo = bookingInfos,

            };

            mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            
            bookingSetupService = new BookingSetupService(mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingReadCase))]
        public int Read_MockObject(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var result = bookingSetupService.Read(bookingInfos[0].Room);
            return result.RoomId;
        }

        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingCreateCase))]
        public int Create_BookingInfo(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var testBookingInfo = new BookingInfo()
            {
                Id = 1
            };
            var result = bookingSetupService.Create(testBookingInfo);
            return result.Count;
        }
        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingDeleteCase))]
        public int Delete_BookingInfo(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var testBookingInfo = new BookingInfo()
            {
                Id = 1
            };
            var result = bookingSetupService.Delete(testBookingInfo);
            return result.Count;
        }
        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BoolingUpdateCase))]
        public int Update_BookingInfo(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var testBookingInfo = new BookingInfo()
            {
                Id = 1,
                DaysCloseForBooking = 1
            };
            var result = bookingSetupService.Update(testBookingInfo);
            return result.First(i => i.Id == testBookingInfo.Id).DaysCloseForBooking;
        }

    }
}
