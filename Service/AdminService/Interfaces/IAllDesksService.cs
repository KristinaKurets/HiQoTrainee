﻿using System.Linq;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Interfaces
{
    public interface IAllDesksService
    {
        IQueryable<DeskDto> ReadAll();
        IQueryable<DeskDto> UpdateDesks(DeskDto desk);
        IQueryable<DeskDto> CreateDesk(DeskDto desk);
        IQueryable<DeskDto> DeleteDesk(DeskDto desk);
        IQueryable<DeskStatusLookUpDto> GetDesksStatuses();
    }
}