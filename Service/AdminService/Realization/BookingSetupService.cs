using System.Collections.Generic;
using AutoMapper;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.Changers;
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
        
        protected List<BookingInfoDto> CreateDto()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<BookingInfo, 
                BookingInfoDto>()).CreateMapper();
            return mapper.Map<List<BookingInfoDto>>(Repository.ReadAll());
        }
        protected BookingInfoDto CreateDto(RoomDto room)
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<BookingInfo,
                BookingInfoDto>()).CreateMapper();
            var result = Repository.Read(u => u.RoomId == room.Id);
            return mapper.Map<BookingInfoDto>(result);
        }
        public List<BookingInfoDto> Create(BookingInfoDto booking)
        {
            BookingInfo bookingInfo = (BookingInfo) booking;
            bookingInfo.Room = UnitOfWork.GetRepository<Room>().Read(booking.RoomId);
            Repository.Create(bookingInfo);
            UnitOfWork.Save();
            return CreateDto();
        }

        public List<BookingInfoDto> Update(BookingInfoDto booking)
        {
            BookingInfo info = BookingInfoChanger.ChangeFromDto(Repository.Read(booking.Id), booking);
            var repository = UnitOfWork.GetRepository<Room>();
            info.Room = repository.Read(booking.RoomId);
            Repository.Update(info);
            UnitOfWork.Save();
            return CreateDto();
        }

        public List<BookingInfoDto> Delete(BookingInfoDto booking)
        {
            Repository.Delete(Repository.Read(booking.Id));
            UnitOfWork.Save();
            return CreateDto();
        }

        public BookingInfoDto Read(RoomDto room)
        {
            return CreateDto(room);
        }
    }
}