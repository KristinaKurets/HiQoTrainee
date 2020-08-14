using System;
using DB.Entity;
using DB.EntityStatus;
using DtoCommon.DTO.EntitiesStatuses;

namespace DtoCommon.DTO.Entities
{
    public class OrderDto
    {
        public long Id { get; set; }
        public BookingStatusDto Status { get; set; }
        public int DeskId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public static implicit operator OrderDto(Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                DeskId = order.DeskId,
                UserId = order.UserId,
                DateTime = order.DateTime, 
                Status = (BookingStatusDto)order.Status
            };
        }

        public static explicit operator Order(OrderDto order)
        {
            return new Order()
            {
                DeskId = order.DeskId,
                UserId = order.UserId,
                DateTime = order.DateTime, 
                Status = (BookingStatus)order.Status
            };
        }
    }
}