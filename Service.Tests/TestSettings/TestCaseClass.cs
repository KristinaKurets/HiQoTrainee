using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Service.Tests
{
    public class TestCaseClass
    {
        private static Room room = new Room
        {
            Id = 1
        };
            
        public static IList<Room> RoomList()
        {
            var rooms = new List<Room>()
            {
                room,
            };
            return rooms;
        }

        public static IList<BookingInfo> BookingInfos()
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

         public static IEnumerable<TestCaseData> BookingInfoTest
         {
             get
             {
                 yield return new TestCaseData(BookingInfos()).Returns(1);
             }
         }
    }
}
