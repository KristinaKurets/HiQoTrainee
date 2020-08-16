using DB.Entity;
using DB.EntityStatus;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.Helpers;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.BookingService.Realization
{
    public class DeskAvailabilityService : BookingBaseService, IDeskAvailabilityService
    {
     

        public DeskAvailabilityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
       
        }

        protected IEnumerable<Desk> CountDesksStatus(IEnumerable<Desk> desks,DateTime time) {
            var statusCounter = new DeskStatusHelper(time);
            return desks.Select(x=> statusCounter.Count(x));
        }
        public IEnumerable<Desk> GetDeskAvailability(DateTime dateTime)
        {
            return CountDesksStatus(UnitOfWork.DeskRepository.ReadAll().AsNoTracking(),dateTime);
        }
        public IEnumerable<Desk> GetDeskAvailability(DateTime dateTime, DeskStatus status)
        {
            return CountDesksStatus(UnitOfWork.DeskRepository.ReadAll(x=>x.Status==status).AsNoTracking(), dateTime);
        }
    }
}
