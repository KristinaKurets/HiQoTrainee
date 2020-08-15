using System;
using System.Collections.Generic;
using DB.Entity;
using NUnit.Framework;

namespace Service.Tests.TestSettings.TestCases
{
    public class BookingTestCase
    {
        private static readonly Room room = new Room
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
                Rooms = RoomList()
            };
            var bookingInfos = new List<BookingInfo>()
            {
                bookingInfo
            };

            room.BookingInfo = bookingInfo;
            return bookingInfos;
        }

         public static IEnumerable<TestCaseData> BookingReadCase
         {
             get
             {
                 yield return new TestCaseData(BookingInfos()).Returns(1);
             }
         }

        public static IEnumerable<TestCaseData> BookingCreateCase
        {
            get
            {
                yield return new TestCaseData(BookingInfos()).Returns(BookingInfos().Count+1);
                yield return new TestCaseData(new List<BookingInfo>()).Returns(1);
                yield return new TestCaseData(null).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> BookingDeleteCase
        {
            get
            {
                yield return new TestCaseData(BookingInfos()).Returns(BookingInfos().Count - 1);
                yield return new TestCaseData(new List<BookingInfo>()).Returns(0);
                yield return new TestCaseData(null).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> BoolingUpdateCase
        {
            get
            {
                yield return new TestCaseData(BookingInfos()).Returns(1);
                yield return new TestCaseData(new List<BookingInfo>()).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null).Returns(typeof(NullReferenceException));
            }
        }
    }
}
