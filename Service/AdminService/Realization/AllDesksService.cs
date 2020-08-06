using System.Collections.Generic;
using AutoMapper;
using DB.Entity;
using DB.LookupTable;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.Changers;
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

        protected List<DeskDto> CreateDto()
        {
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<List<DeskDto>>(Repository.ReadAll());
        }

        protected List<DeskStatusLookUpDto> CreateDeskStatusesDto()
        {
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<DeskStatusLookup, 
                DeskStatusLookUpDto>()).CreateMapper();
            return mapper.Map<List<DeskStatusLookUpDto>>(Repository.ReadAll());
        }

        public List<DeskDto> ReadAll()
        {
            return CreateDto();
        }

        public List<DeskDto> UpdateDesks(DeskDto desk)
        {
            Desk deskUp = DeskChanger.ChangeFromDto(Repository.Read(desk.Id), desk);
            var repository = UnitOfWork.GetRepository<Room>();
            deskUp.Room = repository.Read(desk.RoomId);
            Repository.Update(deskUp);
            UnitOfWork.Save();
            return CreateDto();
        }

        public List<DeskDto> CreateDesk(DeskDto desk)
        {
            Desk result = (Desk) desk;
            result.Room = UnitOfWork.GetRepository<Room>().Read(desk.RoomId);
            Repository.Create(result);
            UnitOfWork.Save();
            return CreateDto();
        }

        public List<DeskDto> DeleteDesk(DeskDto desk)
        {
            Repository.Delete(Repository.Read(desk.Id));
            UnitOfWork.Save();
            return CreateDto();
        }

        public List<DeskStatusLookUpDto> GetDesksStatuses()
        {
            return CreateDeskStatusesDto();
        }
    }
}