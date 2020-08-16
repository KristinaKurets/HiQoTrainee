using DB.Entity;
using DB.EntityStatus;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.Interfaces;
using System;
using System.Linq;

namespace Service.BookingService.Realization
{
    public class BookingManagementService:BookingBaseService,IBookingManagementService
    {

        public BookingManagementService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        { }


        protected void CreateOrder(BookingStatus status,User user, Desk desc, DateTime time) 
        {
            UnitOfWork.OrderRepository.Create(new Order()
            {
                Status = status,
                Desk = desc,
                User = user,
                DateTime = time
            });
        }

        protected void RejectOrders(IQueryable<Order> orders) 
        {
            foreach (var order in orders)
            {
                order.Status = BookingStatus.Rejected;
                UnitOfWork.OrderRepository.Update(order);
            }
        }
        protected bool CreateBooking(User user, Desk desc, DateTime time) 
        {
            var dayOrders = UnitOfWork.OrderRepository.ReadAll(x => x.DateTime == time && x.Desk.Id == desc.Id);
            if (dayOrders.Where(x => x.Status == BookingStatus.Booked).Any())
            {
                var dayWaitOrders = dayOrders.Where(x => x.Status == BookingStatus.Waiting);
                if (user.WorkPlan.Priority == 1)
                {
                    RejectOrders(dayWaitOrders);
                    CreateOrder(BookingStatus.Booked, user, desc, time);
                    UnitOfWork.Save();
                    return true;
                }
                else if (user.WorkPlan.Priority == 2 && dayWaitOrders.Count() == 0)
                {
                    CreateOrder(BookingStatus.Waiting, user, desc, time);
                    UnitOfWork.Save();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CreateBooking(int userID, int descID, DateTime time) 
        {
            User user = UnitOfWork.UserRepository.Read(userID);
            Desk desk = UnitOfWork.DeskRepository.Read(descID);
            if (user != null && desk != null){
               // тут еще нужна проверка на рабочий день и правила букинга 
                return CreateBooking(user, desk, time);
            }
            return false;
        }
        
        public bool СancelBooking(int userID,long orderID)
        {
            var order = UnitOfWork.OrderRepository.Read(orderID);
            if (order != null && order.User.Id == userID) {
                order.Status = BookingStatus.Cancelled;
                UnitOfWork.OrderRepository.Update(order);
                UnitOfWork.Save();
                return true;
            }
            return false;
        }

    
    }
}
