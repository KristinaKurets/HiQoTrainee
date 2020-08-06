using DB.Entity;
using DB.EntityStatus;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.DTO;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.BookingService.Realization
{
    class BookingManagementService:BookingBaseService,IBookingManagementService
    {
        protected readonly IRepository<Order> _orderRepository;
        protected readonly IRepository<User> _userRepository;
        protected readonly IRepository<Desk> _deskRepository;
        protected readonly IRepository<BookingInfo> _BookingSetingsRepository;
        protected readonly IRepository<WorkingDaysCalendar> _CalendarRepository;

        public BookingManagementService(
            IUnitOfWork unitOfWork,
            IRepository<Order> orderRepository,
            IRepository<User> userRepository,
            IRepository<Desk> deskRepository,
            IRepository<BookingInfo> BookingSetingsRepository,
            IRepository<WorkingDaysCalendar> CalendarRepository) : base(unitOfWork)
        {
            _orderRepository = orderRepository;
            _deskRepository = deskRepository;
            _userRepository = userRepository;
            _BookingSetingsRepository = BookingSetingsRepository;
            _CalendarRepository = CalendarRepository;
        }

        protected void CreateOrder(BookingStatus status,User user, Desk desc, DateTime time) {
            _orderRepository.Create(new Order()
            {
                Status = status,
                Desk = desc,
                User = user,
                DateTime = time
            });
        }

        protected void RejectOrders(IQueryable<Order> orders) {
            foreach (var order in orders)
            {
                order.Status = BookingStatus.Rejected;
                _orderRepository.Update(order);
            }
        }
        protected bool CreateBooking(User user, Desk desc, DateTime time) {
            var dayOrders = _orderRepository.ReadAll(x => x.DateTime == time && x.Desk.Id == desc.Id);
            if (dayOrders.Where(x => x.Status == BookingStatus.Booked).Count() == 0)
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

        public bool CreateBooking(BookingUserDTO userDTO, BookingDeskDTO descDTO, DateTime time) {
            User user = _userRepository.Read(userDTO.Id);
            Desk desk = _deskRepository.Read(descDTO.Id);
            if (user != null && desk != null){
               // тут еще нужна проверка на рабочий день и правила букинга 
                return CreateBooking(user, desk, time);
            }
            return false;
        }
        
        public bool СancelBooking(BookingUserDTO user,long orderID) {
            var order =_orderRepository.Read(orderID);
            if (order != null && order.User.Id == user.Id) {

                order.Status = BookingStatus.Cancelled;
                _orderRepository.Update(order);
                UnitOfWork.Save();
                return true;
            }
            return false;
        }

    
    }
}
