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
    public class UserSetupService:IUserSetupService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public UserSetupService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IQueryable<UserDto> CreateUsersDto()
        {
            var repository = UnitOfWork.GetRepository<User>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<User,
                UserDto>()).CreateMapper();
            return mapper.Map<IQueryable<UserDto>>(repository.ReadAll());
        }

        protected IQueryable<UserPositionDto> CreatePositionDto()
        {
            var repository = UnitOfWork.GetRepository<UserPosition>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<UserPosition,
                UserPositionDto>()).CreateMapper();
            return mapper.Map<IQueryable<UserPositionDto>>(repository.ReadAll());
        }

        protected IQueryable<UserRoleLookUpDto> CreateRolesDto()
        {
            var repository = UnitOfWork.GetRepository<UserRoleLookup>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<UserRoleLookup, 
                UserRoleLookUpDto>()).CreateMapper();
            return mapper.Map<IQueryable<UserRoleLookUpDto>>(repository.ReadAll());
        }

        protected IQueryable<WorkPlanDto> CreateWorkPlansDto()
        {
            var repository = UnitOfWork.GetRepository<WorkPlan>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<WorkPlan,
                WorkPlanDto>()).CreateMapper();
            return mapper.Map<IQueryable<WorkPlanDto>>(repository.ReadAll());
        }

        protected IQueryable<DeskDto> CreateDesksDto()
        {
            var repository = UnitOfWork.GetRepository<Desk>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<IQueryable<DeskDto>>(repository.ReadAll());
        }

        protected IQueryable<RoomDto> CreateRoomsDto()
        {
            var repository = UnitOfWork.GetRepository<Room>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<Room, RoomDto>()).CreateMapper();
            return mapper.Map<IQueryable<RoomDto>>(repository.ReadAll());
        }
        public IQueryable<UserDto> ReadAll()
        {
            return CreateUsersDto();
        }

        public IQueryable<UserDto> Create(UserDto user)
        {
            var repository = UnitOfWork.GetRepository<User>();
            repository.Create((User) user);
            UnitOfWork.Save();
            return CreateUsersDto();
        }

        public IQueryable<UserDto> Update(UserDto user)
        {
            var repository = UnitOfWork.GetRepository<User>();
            repository.Update((User)user);
            UnitOfWork.Save();
            return CreateUsersDto();
        }

        public IQueryable<UserDto> Delete(UserDto user)
        {
            var repository = UnitOfWork.GetRepository<User>();
            repository.Delete((User)user);
            UnitOfWork.Save();
            return CreateUsersDto();
        }

        public IQueryable<UserPositionDto> GetPositions()
        {
            return CreatePositionDto();
        }

        public IQueryable<UserRoleLookUpDto> GetRoles()
        {
            return CreateRolesDto();
        }

        public IQueryable<WorkPlanDto> GetWorkPlans()
        {
            return CreateWorkPlansDto();
        }

        public IQueryable<RoomDto> GetRooms()
        {
            return CreateRoomsDto();
        }

        public IQueryable<DeskDto> GetDesks(RoomDto room)
        {
            return CreateDesksDto().Where(u => u.Room.Equals(room));
        }
    }
}