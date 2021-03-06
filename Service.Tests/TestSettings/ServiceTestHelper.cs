﻿using System;
using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
using Moq;
using Repository.Interface;
using Repository.UnitOfWork;

namespace Service.Tests.TestSettings
{
    public class RepositoryDescriptor
    {
        public IList<User> Users { get; set; }

        public IList<Desk> Desks { get; set; }

        public IList<DeskStatusLookup> DeskStatusLookup { get; set; }
        public IList<DeskStatus> DeskStatuses { get; set; }

        public IList<BookingInfo> BookingInfo { get; set; }

        public IList<Room> Rooms { get; set; }

        public IList<UserPosition> UsersPosition { get; set; }

        public IList<Order> Orders { get; set; }

        public IList<WorkingDaysCalendar> WorkingDaysCalendar { get; set; }

        public IList<WorkPlan> WorkPlans { get; set; }

    }

    public class RepositoryMockResult
    {
        public Mock<IUnitOfWork> UnitOfWorkMock { get; set; }

        public Mock<IRepository<User>> UserRepositoryMock { get; set; }

        public Mock<IRepository<Desk>> DeskRepositoryMock { get; set; }

        public Mock<IRepository<Room>> RoomRepositoryMock { get; set; }

        public Mock<IRepository<BookingInfo>> BookingInfoRepositoryMock { get; set; }

        public Mock<IRepository<UserPosition>> UserPositionRepositoryMock { get; set; }

        public Mock<IRepository<WorkingDaysCalendar>> WorkingDaysCalendarRepositoryMock { get; set; }

        public Mock<IRepository<WorkPlan>> WorkPlanRepositoryMock { get; set; }

        public Mock<IRepository<Order>> OrderRepositoryMock { get; set; }

        public Mock<IRepository<DeskStatusLookup>> DeskStatusLookupRepositoryMock { get; set; }

    }

    public class ServiceTestHelper
    {
        public static RepositoryMockResult MockRepository(RepositoryDescriptor descriptor = null)
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.Save());

            Mock<IRepository<T>> SetupRepositoryWithLongId<T>(Func<RepositoryDescriptor, IList<T>> itemsGetter, Func<T, long> idGetter) where T : class
            {
                var repositoryMock = new Mock<IRepository<T>>();
                unitOfWorkMock.Setup(x => x.GetRepository<T>()).Returns(repositoryMock.Object);

                var items = descriptor != null ? itemsGetter(descriptor) : null;
                items = items != null ? new List<T>(items) : new List<T>();

                repositoryMock.Setup(x => x.ReadAll()).
                    Returns(items.AsQueryable());
                repositoryMock.Setup(x => x.ReadAll(It.IsAny<Func<T, bool>>())).
                    Returns<Func<T, bool>>(f => items.Where(f).AsQueryable());

                repositoryMock.Setup(x => x.Read(It.IsAny<object[]>())).
                    Returns<object[]>(p =>
                    {
                        var id = (long) p[0];
                        return items.FirstOrDefault(x => idGetter(x) == id);
                    });
                repositoryMock.Setup(x => x.Read(It.IsAny<Func<T, bool>>())).
                    Returns<Func<T, bool>>(items.FirstOrDefault);

                repositoryMock.Setup(x => x.Update(It.IsAny<T>())).Callback<T>(x =>
                {
                    var id = idGetter(x);
                    var existingItem = items.First(v => idGetter(v) == id);
                    items.Remove(existingItem);
                    items.Add(x);
                }).Verifiable();
                repositoryMock.Setup(x => x.Create(It.IsAny<T>())).
                    Returns<T>(t =>
                    {
                        items.Add(t);
                        return t;
                    });
                repositoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<T>>())).
                    Callback<IEnumerable<T>>(x =>
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
  
                return repositoryMock;
            }

            Mock<IRepository<T>> SetupRepositoryWithIntId<T>(Func<RepositoryDescriptor, IList<T>> itemsGetter, Func<T, int> idGetter) where T : class
            {
                var repositoryMock = new Mock<IRepository<T>>();
                unitOfWorkMock.Setup(x => x.GetRepository<T>()).Returns(repositoryMock.Object);

                var items = descriptor != null ? itemsGetter(descriptor) : null;
                items = items != null ? new List<T>(items) : new List<T>();

                repositoryMock.Setup(x => x.ReadAll()).
                    Returns(items.AsQueryable());
                repositoryMock.Setup(x => x.ReadAll(It.IsAny<Func<T, bool>>())).
                    Returns<Func<T, bool>>(f => items.Where(f).AsQueryable());

                repositoryMock.Setup(x => x.Read(It.IsAny<object[]>())).
                    Returns<object[]>(p =>
                    {
                        var id = (int)p[0];
                        return items.FirstOrDefault(x => idGetter(x) == id);
                    });
                repositoryMock.Setup(x => x.Read(It.IsAny<Func<T, bool>>())).
                    Returns<Func<T, bool>>(items.FirstOrDefault);

                repositoryMock.Setup(x => x.Update(It.IsAny<T>())).Callback<T>(x =>
                {
                    var id = idGetter(x);
                    var existingItem = items.First(v => idGetter(v) == id);
                    items.Remove(existingItem);
                    items.Add(x);
                }).Verifiable();
                repositoryMock.Setup(x => x.Create(It.IsAny<T>())).
                    Returns<T>(t =>
                    {
                        items.Add(t);
                        return t;
                    });
                repositoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<T>>())).
                    Callback<IEnumerable<T>>(x =>
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

                return repositoryMock;
            }

            var repository = new RepositoryMockResult
            {
                UnitOfWorkMock = unitOfWorkMock,
                DeskRepositoryMock = SetupRepositoryWithIntId(x => x.Desks, x => x.Id),
                UserRepositoryMock = SetupRepositoryWithIntId(x => x.Users, x => x.Id),
                RoomRepositoryMock = SetupRepositoryWithIntId(x => x.Rooms, x => x.Id),
                BookingInfoRepositoryMock = SetupRepositoryWithIntId(x => x.BookingInfo, x => x.Id),
                UserPositionRepositoryMock = SetupRepositoryWithIntId(x => x.UsersPosition, x => x.Id),
                WorkingDaysCalendarRepositoryMock = SetupRepositoryWithLongId(x => x.WorkingDaysCalendar, x => x.Id),
                WorkPlanRepositoryMock = SetupRepositoryWithIntId(x => x.WorkPlans, x => x.Id),
                OrderRepositoryMock = SetupRepositoryWithLongId(x => x.Orders, x => x.Id),
                DeskStatusLookupRepositoryMock = SetupRepositoryWithIntId(x => x.DeskStatusLookup, x => x.ID)
            };

            unitOfWorkMock.Setup(u => u.UserRepository).Returns(repository.UserRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.DeskRepository).Returns(repository.DeskRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.RoomRepository).Returns(repository.RoomRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.BookingInfoRepository).Returns(repository.BookingInfoRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.WorkPlanRepository).Returns(repository.WorkPlanRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.CalendarRepository).Returns(repository.WorkingDaysCalendarRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.OrderRepository).Returns(repository.OrderRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.DeskStatusRepository).Returns(repository.DeskStatusLookupRepositoryMock.Object);

            return repository;

        }

    }
}
