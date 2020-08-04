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

        public BookingSetupService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IQueryable<BookingInfoDto> CreateDto()
        {
            var repository= UnitOfWork.GetRepository<BookingInfo>();
            var mapper = new MapperConfiguration(cm => cm.CreateMap<BookingInfo, 
                BookingInfoDto>()).CreateMapper();
            return mapper.Map<IQueryable<BookingInfoDto>>(repository.ReadAll());
        }
        public IQueryable<BookingInfoDto> Create(BookingInfoDto booking)
        {
            var repository = UnitOfWork.GetRepository<BookingInfo>();
            repository.Create((BookingInfo) booking);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<BookingInfoDto> Update(BookingInfoDto booking)
        {
            var repository = UnitOfWork.GetRepository<BookingInfo>();
            repository.Update((BookingInfo)booking);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<BookingInfoDto> Delete(BookingInfoDto booking)
        {
            var repository = UnitOfWork.GetRepository<BookingInfo>();
            repository.Delete((BookingInfo)booking);
            UnitOfWork.Save();
            return CreateDto();
        }

        public BookingInfoDto Read(RoomDto room)
        {
            return CreateDto().FirstOrDefault(u => u.Room.Equals(room));
        }
    }
}