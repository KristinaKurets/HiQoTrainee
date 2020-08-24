using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.NotificationService.Interfaces
{
    public interface IOrderNotification
    {
        public void BookingConfirmed(Order order);
    }
}
