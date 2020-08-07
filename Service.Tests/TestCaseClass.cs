using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tests
{
    public class TestCaseClass
    {
        private Room room = new Room
        {
            Id = 1
        };
            
        public List<Room> RoomList()
        {
            var rooms = new List<Room>()
            {
                room,
            };
            return rooms;
        }

         public List<BookingInfo> BookingInfoList()
            {
            var bookingInfo = new BookingInfo()
            {
                Id = 1,
                RoomId = room.Id,
                Room = room,
            };
            var bookingInfos = new List<BookingInfo>()
                {
                    bookingInfo
                };

            room.BookingInfo = bookingInfo;
            return bookingInfos;
         }




        //}

    }
}
