using System;
using System.Collections.Generic;
using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.DTO.LookUps
{
    public class DeskStatusLookUpDto
    {
        public short Id { get; set; }
        public string Status { get; set; }
        public virtual ICollection<DeskDto> Desks { get; set; }

        public static implicit operator DeskStatusLookUpDto(DeskStatusLookup status)
        {
            return new DeskStatusLookUpDto()
            {
                Id = status.ID,
                Status = status.Status,
                Desks = (ICollection<DeskDto>) status.Desks
            };
        }

        public static explicit operator DeskStatusLookup(DeskStatusLookUpDto status)
        {
            return new DeskStatusLookup()
            {
                ID = status.Id,
                Status = status.Status,
                Desks = (ICollection<Desk>) status.Desks
            };
        }

        public static explicit operator DeskStatus(DeskStatusLookUpDto status)
        {
            return Enum.Parse<DeskStatus>(status.Status, true);
        }
    }
}