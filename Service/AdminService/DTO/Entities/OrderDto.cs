using System;
using DB.Entity;
using DB.EntityStatus;
using Service.AdminService.DTO.EntitiesStatuses;

namespace Service.AdminService.DTO.Entities
{
    public class OrderDto
    {
        public long Id { get; set; }
        public BookingStatusDto Status { get; set; }
        public DeskDto Desk { get; set; }
        public UserDto User { get; set; }
        public DateTime DateTime { get; set; }

        public static implicit operator OrderDto(Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Desk = order.Desk,
                User = order.User,
                DateTime = order.DateTime, 
                Status = (BookingStatusDto)order.Status
            };
        }

        public static explicit operator Order(OrderDto order)
        {
            return new Order()
            {
                Id = order.Id,
                Desk = (Desk) order.Desk,
                User = (User) order.User,
                DateTime = order.DateTime, 
                Status = (BookingStatus)order.Status
            };
        }
    }
}