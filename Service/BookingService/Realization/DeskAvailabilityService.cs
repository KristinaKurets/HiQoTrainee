using DB.Entity;
using DB.EntityStatus;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.BookingService.Base;
using Service.BookingService.DTO;
using Service.BookingService.Helpers;
using Service.BookingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.BookingService.Realization
{
    public class DeskAvailabilityService : BookingBaseService, IDeskAvailabilityService
    {
        protected readonly IRepository<Desk> _repository;
        public DeskAvailabilityService(IUnitOfWork unitOfWork, IRepository<Desk> repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        protected IEnumerable<BookingDeskDTO> CountDesksStatus(IEnumerable<Desk> desks,DateTime time) {
            var statusCounter = new DeskStatusHelper(time);
            return desks.Select(x=> statusCounter.Count(x));
        }
        public IEnumerable<BookingDeskDTO> GetDeskAvailability(DateTime dateTime)
        {
            return CountDesksStatus(_repository.ReadAll(),dateTime);
        }
        public IEnumerable<BookingDeskDTO> GetDeskAvailability(DateTime dateTime, DeskStatus status)
        {
            return CountDesksStatus(_repository.ReadAll(x=>x.Status==status),dateTime);
        }
    }
}
