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
    public class UserSetupService:IUserSetupService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<User> Repository;
        public UserSetupService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GetRepository<User>();
        }

        protected List<UserDto> CreateUsersDto()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<User,
                UserDto>()).CreateMapper();
            return mapper.Map<List<UserDto>>(Repository.ReadAll());
        }

        protected List<UserPositionDto> CreatePositionDto()
        {
            var repository = UnitOfWork.GetRepository<UserPosition>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<UserPosition,
                UserPositionDto>()).CreateMapper();
            return mapper.Map<List<UserPositionDto>>(repository.ReadAll());
        }

        protected List<UserRoleLookUpDto> CreateRolesDto()
        {
            var repository = UnitOfWork.GetRepository<UserRoleLookup>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<UserRoleLookup, 
                UserRoleLookUpDto>()).CreateMapper();
            return mapper.Map<List<UserRoleLookUpDto>>(repository.ReadAll());
        }

        protected List<WorkPlanDto> CreateWorkPlansDto()
        {
            var repository = UnitOfWork.GetRepository<WorkPlan>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<WorkPlan,
                WorkPlanDto>()).CreateMapper();
            return mapper.Map<List<WorkPlanDto>>(repository.ReadAll());
        }

        protected List<DeskDto> CreateDesksDto()
        {
            var repository = UnitOfWork.GetRepository<Desk>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<List<DeskDto>>(repository.ReadAll());
        }
        protected List<DeskDto> CreateDesksDto(RoomDto room)
        {
            var repository = UnitOfWork.GetRepository<Desk>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<List<DeskDto>>(repository.ReadAll(u=>u.Room.Equals((Room)room)));
        }

        protected List<RoomDto> CreateRoomsDto()
        {
            var repository = UnitOfWork.GetRepository<Room>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<Room, RoomDto>()).CreateMapper();
            return mapper.Map<List<RoomDto>>(repository.ReadAll());
        }
        public List<UserDto> ReadAll()
        {
            return CreateUsersDto();
        }

        public List<UserDto> Create(UserDto user)
        {
            User result = (User) user;
            result.Room = UnitOfWork.GetRepository<Room>().Read(user.RoomId);
            result.Position = UnitOfWork.GetRepository<UserPosition>().Read(user.UserPositionId);
            result.WorkPlan = UnitOfWork.GetRepository<WorkPlan>().Read(user.WorkPlanId);
            result.Desk = UnitOfWork.GetRepository<Desk>().Read(user.DeskId);
            Repository.Create(result);
            UnitOfWork.Save();
            return CreateUsersDto();
        }

        public List<UserDto> Update(UserDto user)
        {
            User result = UserChanger.ChangeFromDto(Repository.Read(user.Id), user);
            result.Room = UnitOfWork.GetRepository<Room>().Read(user.RoomId);
            result.Position = UnitOfWork.GetRepository<UserPosition>().Read(user.UserPositionId);
            result.WorkPlan = UnitOfWork.GetRepository<WorkPlan>().Read(user.WorkPlanId);
            result.Desk = UnitOfWork.GetRepository<Desk>().Read(user.DeskId);
            Repository.Update(result);
            UnitOfWork.Save();
            return CreateUsersDto();
        }

        public List<UserDto> Delete(UserDto user)
        {
            Repository.Delete(Repository.Read(user.Id));
            UnitOfWork.Save();
            return CreateUsersDto();
        }

        public List<UserPositionDto> GetPositions()
        {
            return CreatePositionDto();
        }

        public List<UserRoleLookUpDto> GetRoles()
        {
            return CreateRolesDto();
        }

        public List<WorkPlanDto> GetWorkPlans()
        {
            return CreateWorkPlansDto();
        }

        public List<RoomDto> GetRooms()
        {
            return CreateRoomsDto();
        }

        public List<DeskDto> GetDesks(RoomDto room)
        {
            return CreateDesksDto(room);
        }
    }
}