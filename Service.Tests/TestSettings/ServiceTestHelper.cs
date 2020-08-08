using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DB.Entity;
using Moq;
using Repository.Interface;
using Repository.UnitOfWork;

namespace Service.Tests.TestSettings
{
    public class RepositoryDescriptor
    {
        public IList<User> Users { get; set; }

        public IList<Desk> Desks { get; set; }

        public IList<BookingInfo> BookingInfo { get; set; }

        public IList<Room> Rooms { get; set; }

        public IList<UserPosition> UsersPosition { get; set; }

        public IList<Order> Orders { get; set; }

        public IList<WorkingDaysCalendar> WorkingDaysCalendar { get; set; }

        public IList<WorkPlan> WorkPlans { get; set; }

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
                void SetupItems<T>(Mock<IRepository<T>> repositoryMock, IList<T> items) where T : class
                {
                    if (items != null)
                    {
                        repositoryMock.Setup(x => x.ReadAll()).
                            Returns(items.AsQueryable());
                        repositoryMock.Setup(x => x.ReadAll(It.IsAny<Func<T, bool>>())).
                            Returns<Func<T, bool>> (f => items.Where(f).AsQueryable());

                        repositoryMock.Setup(x => x.Read(It.IsAny<object[]>())).
                            Returns<object[]>(p => items[(int) p[0]]);
                        repositoryMock.Setup(x => x.Read(It.IsAny<Func<T, bool>>())).
                            Returns<Func<T, bool>>(items.FirstOrDefault);

                        repositoryMock.Setup(x => x.Update(It.IsAny<T>()));
                        
                        repositoryMock.Setup(x => x.Create(It.IsAny<T>())).
                            Returns<T>(t => 
                            {
                                items.Add(t);
                                return t;
                            });
                        repositoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<T>>())).
                            Callback<IEnumerable<T>>( x =>
                            {
                                foreach (var item in x)
                                {
                                    items.Add(item);
                                }
                            }).Verifiable();

                        repositoryMock.Setup(x => x.Delete(It.IsAny<T>())).
                            Callback<T>(x => items.Remove(x)).
                            Verifiable();

                        repositoryMock.Setup(x => x.DeleteAll()).Callback(items.Clear).Verifiable();
                    }
                }

                SetupItems(userRepositoryMock, descriptor.Users);
                SetupItems(bookingInfoRepositoryMock, descriptor.BookingInfo);
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

            //bookingInfoRepositoryMock.Setup(r => r.Read(It.IsAny<BookingInfo[]>())).Callback<BookingInfo[]>(d =>
            //{
            //    foreach (var book in d)
            //    {
            //        return descriptor.BookingInfo;
            //    }
            //});
        }
    }
}
