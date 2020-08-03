using System.Linq;
using AutoMapper;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
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

        protected IQueryable<UserDto> CreateDto()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<User,
                UserDto>()).CreateMapper();
            return mapper.Map<IQueryable<UserDto>>(Repository.ReadAll());
        }

        public IQueryable<UserDto> ReadAll()
        {
            return CreateDto();
        }

        public IQueryable<UserDto> Create(UserDto user)
        {
            Repository.Create((User) user);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<UserDto> Update(UserDto user)
        {
            Repository.Update((User)user);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<UserDto> Delete(UserDto user)
        {
            Repository.Delete((User)user);
            UnitOfWork.Save();
            return CreateDto();
        }
    }
}