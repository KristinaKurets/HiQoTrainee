using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
using NUnit.Framework;
using Service.AdminService.Realization;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class AllDesksServiceTests
    {
        private AllDesksService allDesksService;
        private RepositoryMockResult mockResult;

        public void Setup(IList<Desk> desks, IList<DeskStatusLookup> deskStatusLookups = null)
        {

            RepositoryDescriptor repositoryDescriptor = new RepositoryDescriptor()
            {
                Desks = desks,
                DeskStatusLookup = deskStatusLookups,
            };

            mockResult = ServiceTestHelper.MockRepository(repositoryDescriptor);

            allDesksService = new AllDesksService(mockResult.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DesksReadAllCase))]
        public int ReadAll_ReturnDesks(IList<Desk> desks)
        {
            Setup(desks);
            var result = allDesksService.ReadAll();

            return result.Count();
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DesksUpdateCase))]
        public string UpdateDesk_Desk_ListDesks(IList<Desk> desks)
        {
            Setup(desks);
            var testDesk = new Desk
            {
                Title = "title",
                Id = 1,
            };

            var result = allDesksService.UpdateDesks(testDesk);


            return result.First(i => i.Id == testDesk.Id).Title;
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DesksCreateCase))]
        public int CreateDesk_Desk_ListDesks(IList<Desk> desks)
        {
            Setup(desks);
            var testDesk = new Desk
            {
                Title = "title",
                Id = 5,
            };

            var result = allDesksService.CreateDesk(testDesk);


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
                Users = new List<User>(),
            };
            var result = allDesksService.DeleteDesk(desk);
            return result.Count;
        }

        [Test, TestCaseSource(typeof(DeskTestCase), nameof(DeskTestCase.DeskGetDesksLookupCase))]
        public int GetDeskStatus_Desk_ListDesks( List<Desk> desks, List<DeskStatusLookup> deskStatusLookup)
        {
            Setup(desks, deskStatusLookup);

            var result = allDesksService.GetDesksStatuses();
            return result.Count;
        }
    }
}

   