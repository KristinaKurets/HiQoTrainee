using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
using NUnit.Framework;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class AllDesksServiceTests
    {
        private AdminService.Services.AdminService _adminService;
        private RepositoryMockResult _mockResult;

        public void Setup(IList<Desk> desks, IList<DeskStatusLookup> deskStatusLookups = null, IList<User> users=null)
        {

            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                Desks = desks,
                DeskStatusLookup = deskStatusLookups,
                Users = users,
            };

            _mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            _adminService = new AdminService.Services.AdminService(_mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DesksReadAllCase))]
        public int ReadAll_ReturnDesks(IList<Desk> desks)
        {
            Setup(desks);
            var result = _adminService.GetDesks();

            return result.Count;
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DesksUpdateCase))]
        public string UpdateDesk_Desk_ListDesks(IList<Desk> desks, IList<User> users)
        {
            Setup(desks);
            //var testDesk = new Desk
            //{
            //    Title = "title",
            //    Id = 1,
            //};

            var result = _adminService.UpdateDesks(desks[1]);


            return result.First(i => i.Id == desks[1].Id).Title;
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DesksCreateCase))]
        public int CreateDesk_Desk_ListDesks(IList<Desk> desks, IList<User> users)
        {
            Setup(desks, null, users);
            var testDesk = new Desk
            {
                Title = "title",
                Id = 5,
            };

            var result = _adminService.CreateDesk(testDesk);


            return result.Count;
        }


        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DeskDeleteCase))]
        public int DeleteDesk_Desk_ListDesks(IList<Desk> desks)
        {
            Setup(desks);
            var desk = new Desk
            {
                Id = 1,
                Title = "Tom",
                Orders = new List<Order>(),
                RoomId = 1,
                Status = DeskStatus.Fixed,
                User = new User(),
            };
            var result = _adminService.DeleteDesk(desk);
            return result.Count;
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DeskGetDesksLookupCase))]
        public int GetDeskStatus_Desk_ListDesks( List<Desk> desks, List<DeskStatusLookup> deskStatusLookup)
        {
            Setup(desks, deskStatusLookup);

            var result = _adminService.GetDesksStatuses();
            return result.Count;
        }
    }
}

   