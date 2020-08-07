using System.Collections.Generic;
using System.Linq;
using DB.Context;
using DB.Entity;
using DB.EntityStatus;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.EntitiesStatuses;
using Service.AdminService.Realization;

namespace Service.Tests
{
    public class AllDesksServiceTests
    {
        private IList<Desk> desks = new Desk[] {
            new Desk
            {
                Id=1, 
                Title= "Tom", 
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            },
            new Desk
            {
                Id=2, 
                Title="Alice",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            },
            new Desk 
            { 
                Id=3, 
                Title="Sam",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            },
            new Desk
            {
                Id=4, 
                Title="Kate",
                Orders = new List<Order>(),
                Room = new Room(),
                Status = DeskStatus.Fixed,
                Users =  new List<User>(),
            }
        };
       

        private Mock<IUnitOfWork> unitOfWorkMock;
        private AllDesksService allDesksService;

        [SetUp]
        public void Setup()
        {
            Room room = new Room();

            var rooms = new List<Room>()
            {
                room,
            };

            var bookingInfo = new BookingInfo()
            {
                Id = 1,
                Room = room,
            };

            var bookingInfos = new List<BookingInfo>()
            {
                bookingInfo
            };
            room.BookingInfo = bookingInfo;

            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                Desks = desks,
                BookingInfo = bookingInfos,
                Rooms = rooms,
            };

      
            ServiceTestHelper.MockRepository(out unitOfWorkMock, repositoryDescriptor);


            allDesksService = new AllDesksService(unitOfWorkMock.Object);
        }


        [Test]
        public void ReadAll_ReturnDesks()
        {
            var result = (List<DeskDto>) allDesksService.ReadAll();
            
            Assert.AreEqual(result.Count(), desks.Count());
        }

        [Test]
        public void UpdateDesk_Desk_ListDesks()
        {
            var testDesk = desks[0];
            testDesk.Title = "test";
            var result = allDesksService.UpdateDesks(testDesk);


            Assert.AreEqual(result.First(i => i.Id == testDesk.Id).Title, testDesk.Title);
        }
    }
}