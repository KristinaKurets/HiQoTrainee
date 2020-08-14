using AutoMapper;
using DB.Entity;
using DB.EntityStatus;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.DTO;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.Realization
{
    public class MyBookingsService:BookingBaseService,IMyBookingsService
    {  
        protected readonly IMapper _mapper;
        public MyBookingsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

      


        public IEnumerable<BookingOrderDTO> GetActiveBookings(BookingUserDTO user) {
            return _mapper.Map<IEnumerable<BookingOrderDTO>> (UnitOfWork.OrderRepository.ReadAll(x=> x.User.Id==user.Id &&(x.Status==BookingStatus.Waiting || x.Status==BookingStatus.Booked) ));
        }

        public IEnumerable<BookingOrderDTO> GetBookingsHistory(BookingUserDTO user, DateTime start, DateTime end) {
            return _mapper.Map<IEnumerable<BookingOrderDTO>>(UnitOfWork.OrderRepository.ReadAll(x =>
            x.User.Id == user.Id
            && x.DateTime >= start
            && x.DateTime <= end
            && (x.Status != BookingStatus.Waiting && x.Status != BookingStatus.Booked)));
        }


    }
}
