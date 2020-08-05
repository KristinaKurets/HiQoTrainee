using DB.Entity;
using DB.EntityStatus;
using System;

namespace Service.AdminService.DTO
{
    public class OrderDto
    {
        public long Id { get; set; }
        public BookingStatus Status { get; set; }
        public DeskDto Desk { get; set; }
        public UserDto User { get; set; }
        public DateTime? DateTime { get; set; }

        public static implicit operator Order(OrderDto order)
        {
            return new Order
            {
                Id = order.Id,
                Status = order.Status,
                Desk = order.Desk,
                //User = order.User,
                DateTime = (DateTime)order.DateTime
            };
        }

        public static implicit operator OrderDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Status = order.Status,
                Desk = order.Desk,
                //User = order.User,
                DateTime = order.DateTime
            };
        }
    }
}
