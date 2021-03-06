﻿using System;
using DB.EntityStatus;
using DB.LookupTable;

namespace DtoCommon.DTO.LookUps
{
    public class BookingStatusLookUpDto
    {
        public short Id { get; set; }
        public string Description { get; set; }

        public static implicit operator BookingStatusLookUpDto(BookingStatusLookup status)
        {
            return new BookingStatusLookUpDto()
            {
                Id = status.ID,
                Description = status.Description
            };
        }

        public static explicit operator BookingStatusLookup(BookingStatusLookUpDto status)
        {
            return new BookingStatusLookup()
            {
                ID = status.Id,
                Description = status.Description
            };
        }

        public static explicit operator BookingStatus(BookingStatusLookUpDto status)
        {
            return Enum.Parse<BookingStatus>(status.Description, true);
        }
    }
}