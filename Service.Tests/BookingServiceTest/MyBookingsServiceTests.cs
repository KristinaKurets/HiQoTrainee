using DB.Entity;
using NUnit.Framework;
using Service.BookingService.Realization;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases.BookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests.BookingServiceTest
{
    public class MyBookingsServiceTests
    {
        private RepositoryMockResult _mockResult;
        private MyBookingsService _myBookingsService;

        public void Setup(IList<Order> orders = null, IList<User> users = null, IList < Desk> desks = null,  IList<Room> rooms = null )
        {
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                Rooms = rooms,
                Desks = desks,
                Orders = orders
            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            _myBookingsService = new MyBookingsService(_mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(MyBookingsServiceTestCase), nameof(MyBookingsServiceTestCase.GetActiveBookings))]
        public int GetDeskAvailability(IList<Order> orders)
        {
            Setup(orders);
            var userId = 1;
            var result = _myBookingsService.GetActiveBookings(userId);

            return result.Count();
        }

        [Test, TestCaseSource(typeof(MyBookingsServiceTestCase), nameof(MyBookingsServiceTestCase.GetHistoryBookings))]
        public int GetBookingsHistory(IList<Order> orders, IList<User> users)
        {
            Setup(orders, users);
            
            var start = DateTime.Today.AddDays(-30);
            var end = DateTime.Today;
            var userId = 1;

            var result = _myBookingsService.GetBookingsHistory(userId, start, end);

            return result.Count();
        }
    }
}
