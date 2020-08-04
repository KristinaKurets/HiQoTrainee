using DB.Entity;
using DB.EntityStatus;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.BookingService.Realization
{
    class BookingManagementService:BookingBaseService,IBookingManagementService
    {
        protected readonly IRepository<Order> _repository;
        public BookingManagementService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public bool CreateBooking(User user, Desk desc, DateTime time) {
            var dayOrders = _repository.ReadAll(x => x.DateTime == time && x.Desk.Id == desc.Id);
            if (dayOrders.Where(x=>x.Status==BookingStatus.Booked).Count() == 0) {
                var dayWaitOrders = dayOrders.Where(x=>x.Status==BookingStatus.Waiting );
                if (user.WorkPlan.Priority == 1)
                {
                    foreach (var order in dayWaitOrders)
                    {
                        order.Status = BookingStatus.Rejected;
                        _repository.Update(order);
                    }
                    _repository.Create(new Order()
                    {
                        Status = BookingStatus.Booked,
                        Desk = desc,
                        User = user,
                        DateTime = time
                    });
                    UnitOfWork.Save();
                    return true;
                }
                else if (user.WorkPlan.Priority == 2 && dayWaitOrders.Count()==0) {
                    _repository.Create(new Order()
                    {
                        Status = BookingStatus.Waiting,
                        Desk = desc,
                        User = user,
                        DateTime = time
                    });
                    UnitOfWork.Save();
                    return true;
               }
                return false;
            }else { 
                return false; 
            }
        }
        
        // temp int cast
        public bool СancelИooking(User user,long orderID) {
            var order =_repository.Read((int)orderID);
            if (order != null && order.User == user) {

                order.Status = BookingStatus.Cancelled;
                _repository.Update(order);
                UnitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
