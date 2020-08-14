using AutoMapper;
using DB.Entity;
using DB.EntityStatus;
using Service.BookingService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.BookingService.Helpers
{
    class DeskStatusHelper
    {
        protected readonly DateTime _time;
        protected readonly IMapper _mapper;
        public DeskStatusHelper(IMapper mapper,DateTime dateTime)
        {
            _mapper = mapper;         
            _time = dateTime;
        }

        public BookingDeskDTO Count(Desk desk)
        {
            BookingDeskDTO resultDesk = _mapper.Map<Desk,BookingDeskDTO>(desk);
            if (desk.Status != DeskStatus.Fixed)
            {
                var orders = desk.Orders.Where(x => x.Desk==desk && x.DateTime == _time && (x.Status == BookingStatus.Booked || x.Status == BookingStatus.Used));
                if (orders.Count() != 0)
                {
                    resultDesk.User = _mapper.Map <User,BookingUserDTO> (orders.ToList()[0].User);
                    resultDesk.Status = DeskStatus.Booked;
                }
            }
            return resultDesk;
        }
    }
}
