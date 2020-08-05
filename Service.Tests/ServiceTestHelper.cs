using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB.Entity;
using Moq;
using Repository.Interface;
using Repository.UnitOfWork;

namespace Service.Tests
{
    public class RepositoryDescriptor
    {
        public ICollection<User> Users { get; set; }

        public ICollection<Desk> Desks { get; set; }

        public ICollection<BookingInfo> BookingInfo { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<UserPosition> UsersPosition { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<WorkingDaysCalendar> WorkingDaysCalendar { get; set; }

        public ICollection<WorkPlan> WorkPlans { get; set; }

    }


    public class ServiceTestHelper
    {
        public static void MockRepository(out Mock<IUnitOfWork> unitOfWorkMock, RepositoryDescriptor descriptor = null)
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
           
            var desksRepositoryMock = new Mock<IRepository<Desk>>();
            var bookingInfoRepositoryMock = new Mock<IRepository<BookingInfo>>();
            var roomRepositoryMock = new Mock<IRepository<Room>>();
            var userRepositoryMock = new Mock<IRepository<User>>();
            var userPositionRepositoryMock = new Mock<IRepository<UserPosition>>();
            var orderRepositoryMock = new Mock<IRepository<Order>>();
            var calendarRepositoryMock = new Mock<IRepository<WorkingDaysCalendar>>();
            var workPlanRepositoryMock = new Mock<IRepository<WorkPlan>>();

            if (descriptor != null)
            {
                void SetupItems<T>(Mock<IRepository<T>> repositoryMock, ICollection<T> items) where T: class
                {
                    if (items != null)
                    {
                        repositoryMock.Setup(x => x.ReadAll()).
                            Returns(items.AsQueryable());
                    }
                }
                
                SetupItems(userRepositoryMock, descriptor.Users);
                SetupItems(desksRepositoryMock, descriptor.Desks);
                SetupItems(roomRepositoryMock, descriptor.Rooms);
                SetupItems(userPositionRepositoryMock, descriptor.UsersPosition);
                SetupItems(orderRepositoryMock, descriptor.Orders);
                SetupItems(calendarRepositoryMock, descriptor.WorkingDaysCalendar);
                SetupItems(workPlanRepositoryMock, descriptor.WorkPlans);
            }

            unitOfWorkMock.Setup(x => x.Save());
           
            unitOfWorkMock.Setup(x => x.GetRepository<Desk>()).Returns(desksRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<Room>()).Returns(roomRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<BookingInfo>()).Returns(bookingInfoRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<User>()).Returns(userRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<UserPosition>()).Returns(userPositionRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<Order>()).Returns(orderRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<WorkPlan>()).Returns(workPlanRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.GetRepository<WorkingDaysCalendar>()).Returns(calendarRepositoryMock.Object);

            desksRepositoryMock.Setup(x => x.Update(It.IsAny<Desk>())).Callback<Desk>(d => descriptor.Desks.Add(d));
        }
    }
}
