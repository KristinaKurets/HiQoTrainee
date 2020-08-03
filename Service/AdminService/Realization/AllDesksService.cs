using System.Linq;
using AutoMapper;
using DB.Entity;
using DB.LookupTable;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.LookUps;
using Service.AdminService.Interfaces;

namespace Service.AdminService.Realization
{
    public class AllDesksService:IAllDesksService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<Desk> Repository;
        public AllDesksService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GetRepository<Desk>();
        }

        protected IQueryable<DeskDto> CreateDto()
        {
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<IQueryable<DeskDto>>(Repository.ReadAll());
        }

        protected IQueryable<DeskStatusLookUpDto> CreateDeskStatusesDto()
        {
            var repository = UnitOfWork.GetRepository<DeskStatusLookup>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<DeskStatusLookup, 
                DeskStatusLookUpDto>()).CreateMapper();
            return mapper.Map<IQueryable<DeskStatusLookUpDto>>(repository.ReadAll());
        }

        public IQueryable<DeskDto> ReadAll()
        {
            return CreateDto();
        }

        public IQueryable<DeskDto> UpdateDesks(DeskDto desk)
        {
            Repository.Update((Desk)desk);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<DeskDto> CreateDesk(DeskDto desk)
        {
            Repository.Create((Desk) desk);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<DeskDto> DeleteDesk(DeskDto desk)
        {
            Repository.Delete((Desk)desk);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<DeskStatusLookUpDto> GetDesksStatuses()
        {
            return CreateDeskStatusesDto();
        }
    }
}