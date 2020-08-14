using AutoMapper;
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
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Service.BookingService.Realization
{
    public class DeskAvailabilityService : BookingBaseService, IDeskAvailabilityService
    {
        protected readonly IRepository<Desk> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;


   
        public DeskAvailabilityService(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Desk>();
            _mapper = mapper;
             
        }

        protected IEnumerable<BookingDeskDTO> CountDesksStatus(IEnumerable<Desk> desks,DateTime time) {
            var statusCounter = new DeskStatusHelper(_mapper,time);
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
