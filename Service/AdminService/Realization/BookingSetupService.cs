using System.Linq;
using AutoMapper;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.Interfaces;

namespace Service.AdminService.Realization
{
    public class BookingSetupService:IBookingSetupService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<BookingInfo> Repository;

        public BookingSetupService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GetRepository<BookingInfo>();
        }

        protected IQueryable<BookingInfoDto> CreateDto()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<BookingInfo, 
                BookingInfoDto>()).CreateMapper();
            return mapper.Map<IQueryable<BookingInfoDto>>(Repository.ReadAll());
        }

        public IQueryable<BookingInfoDto> Create(BookingInfoDto booking)
        {
            Repository.Create((BookingInfo) booking);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<BookingInfoDto> Update(BookingInfoDto booking)
        {
            Repository.Update((BookingInfo)booking);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<BookingInfoDto> Delete(BookingInfoDto booking)
        {
            Repository.Delete((BookingInfo)booking);
            UnitOfWork.Save();
            return CreateDto();
        }

        public BookingInfoDto Read(RoomDto room)
        {
            return CreateDto().FirstOrDefault(u => u.Room.Equals(room));
        }
    }
}