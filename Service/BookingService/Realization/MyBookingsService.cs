using DB.Entity;
using DB.EntityStatus;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.BookingService.Realization
{
    public class MyBookingsService:BookingBaseService,IMyBookingsService
    {  
        
        public MyBookingsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Order> GetActiveBookings(int userID) {
            return UnitOfWork.OrderRepository.ReadAll(x => x.User.Id == userID
            && (x.Status == BookingStatus.Waiting || x.Status == BookingStatus.Booked)).ToList();
        }

        public IEnumerable<Order> GetBookingsHistory(int userID, DateTime start, DateTime end) {
            return UnitOfWork.OrderRepository.ReadAll(x =>
            x.User.Id == userID
            && x.DateTime >= start
            && x.DateTime <= end
            && (x.Status != BookingStatus.Waiting && x.Status != BookingStatus.Booked)).ToList();
        }


    }
}
