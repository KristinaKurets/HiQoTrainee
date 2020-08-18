using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using NUnit.Framework;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class BookingSetupServiceTests
    {
        private AdminService.Services.AdminService _adminService;
        private RepositoryMockResult _mockResult;

        public void Setup(IList<BookingInfo> bookingInfos, IList<Room> rooms = null)
        {
            
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Rooms = rooms,
                BookingInfo = bookingInfos,

            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);
            _adminService = new AdminService.Services.AdminService(_mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingReadCase))]
        public int GetBookingInfoAboutOneRoom_MockObject(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var result = _adminService.GetBookingInfoAboutOneRoom(bookingInfos[0].Rooms.First());
            return result.Rooms.First().Id;
        }

        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingCreateCase))]
        public int Create_BookingInfo(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var testBookingInfo = new BookingInfo()
            {
                Id = 1
            };
            var result = _adminService.CreateBookingInfo(testBookingInfo);
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
            var result = _adminService.DeleteBookingInfo(testBookingInfo);
            return result.Count;
        }

        [Test, TestCaseSource(typeof(BookingTestCase), nameof(BookingTestCase.BookingUpdateCase))]
        public int? Update_BookingInfo(IList<BookingInfo> bookingInfos)
        {
            Setup(bookingInfos);
            var testBookingInfo = new BookingInfo()
            {
                Id = 1,
                DaysCloseForBooking = 1
            };
            var result = _adminService.UpdateBookingInfo(testBookingInfo);
            return result?.First(i => i.Id == testBookingInfo.Id).DaysCloseForBooking;
        }

    }
}
