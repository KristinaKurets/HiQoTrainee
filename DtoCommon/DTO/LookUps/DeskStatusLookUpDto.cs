using System;
using DB.EntityStatus;
using DB.LookupTable;

namespace DtoCommon.DTO.LookUps
{
    public class DeskStatusLookUpDto
    {
        public short Id { get; set; }
        public string Status { get; set; }

        public static implicit operator DeskStatusLookUpDto(DeskStatusLookup status)
        {
            return new DeskStatusLookUpDto()
            {
                Id = status.ID,
                Status = status.Status
            };
        }

        public static explicit operator DeskStatusLookup(DeskStatusLookUpDto status)
        {
            return new DeskStatusLookup()
            {
                ID = status.Id,
                Status = status.Status
            };
        }

        public static explicit operator DeskStatus(DeskStatusLookUpDto status)
        {
            return Enum.Parse<DeskStatus>(status.Status, true);
        }
    }
}