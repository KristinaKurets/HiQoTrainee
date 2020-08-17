using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
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
    public class DeskAvailabilityServiceTests
    {
        private RepositoryMockResult _mockResult;
        private DeskAvailabilityService _deskAvailabilityService;

        public void Setup(IList<Desk> desks = null, IList<DeskStatus> deskStatuses = null, IList<User> users = null,  IList<Room> rooms = null, IList<Order> orders = null)
        {
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                Users = users,
                Rooms = rooms,
                Desks = desks,
                DeskStatuses = deskStatuses,
                Orders = orders
            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            _deskAvailabilityService = new DeskAvailabilityService(_mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(DeskAvailabilityTestCase), nameof(DeskAvailabilityTestCase.GetDeskAvailabilityByDate))]
        public int GetDeskAvailability(IList<Desk> desks)
        {
            Setup(desks);
            var result = _deskAvailabilityService.GetDeskAvailability(DateTime.Today);

            return result.Count();
        }
        [Test, TestCaseSource(typeof(DeskAvailabilityTestCase), nameof(DeskAvailabilityTestCase.GetDeskAvailabilityByStatus))]
        public int GetDeskAvailabilityByStatus(IList<Desk> desks)
        {
            Setup(desks);
            var status = DeskStatus.Fixed;
            var result = _deskAvailabilityService.GetDeskAvailability(DateTime.Today, status);
            return result.Count();


        }
    }
}
