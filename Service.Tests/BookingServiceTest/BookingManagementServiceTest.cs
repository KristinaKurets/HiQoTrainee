using System;
using System.Collections.Generic;
using System.Text;
using DB.Entity;
using Moq;
using NUnit.Framework;
using Service.BookingService.Realization;
using Service.NotificationService.Interfaces;
using Service.NotificationService.Realization;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;
using Service.Tests.TestSettings.TestCases.BookingService;

namespace Service.Tests.BookingServiceTest
{
    class BookingManagementTest
    {
        private RepositoryMockResult _mockResult;
        private BookingManagementService _bookingManagementService;

        public void Setup(IList<User> users = null,  IList<Desk> desks = null, IList<Room> rooms = null,IList<Order> orders = null, IList<BookingInfo> bookingInfos = null)
        {
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                Rooms = rooms,
                Desks = desks,
                Orders = orders,
                BookingInfo = bookingInfos,
            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            var orderNotificationMock = new Mock<IOrderNotification>();
            orderNotificationMock.Setup(o => o.BookingConfirmed(It.IsAny<Order>()));
            _bookingManagementService = new BookingManagementService(_mockResult.UnitOfWorkMock.Object, orderNotificationMock.Object);
                
        }

        [Test, TestCaseSource(typeof(BookingManagementTestCase), nameof(BookingManagementTestCase.CreteTestCase))]
        public bool CreateBooking_CreteTestCase(IList<User> users, IList<Desk> desks,
                                                IList<Room> rooms, IList<Order> orders,
                                                IList<BookingInfo> bookingInfos)
        {
            Setup(users, desks, rooms, orders, bookingInfos);

            var result = _bookingManagementService.CreateBooking(2, 2, DateTime.Today.AddDays(1));

            return result;
        }

        [Test, TestCaseSource(typeof(BookingManagementTestCase), nameof(BookingManagementTestCase.CancelTestCase))]
        public bool CancelBooking_CancelTestCase(IList<User> users, IList<Desk> desks,
            IList<Room> rooms, IList<Order> orders)
        {
            Setup(users, desks, rooms, orders);

            var result = _bookingManagementService.CancelBooking(users == null ? 0 : 1, 1);
            return result;
        }
    }
}
