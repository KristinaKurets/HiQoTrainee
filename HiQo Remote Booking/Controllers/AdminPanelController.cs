using System.Collections.Generic;
using AutoMapper;
using DB.Entity;
using DB.LookupTable;
using DtoCommon.DTO.Entities;
using DtoCommon.DTO.LookUps;
using Microsoft.AspNetCore.Mvc;
using Service.AdminService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    [Controller]
    public class AdminPanelController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminPanelController(IAdminService service, IMapper mapper)
        {
            _adminService = service;
            _mapper = mapper;
        }

        #region UsersWork

        [HttpGet]
        public JsonResult NewComers()
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.FilterBy(u => u.Room == null, _adminService.GetUsers())));
        }

        [HttpGet]
        public JsonResult AllUsers()
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.GetUsers()));
        }

        [HttpPost]
        public JsonResult CreateUser(UserDto user)
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.CreateUser(_mapper.Map<User>(user))));
        }

        [HttpPost]
        public JsonResult DeleteUser(UserDto user)
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.DeleteUser(_mapper.Map<User>(user))));
        }
        [HttpPost]
        public JsonResult UpdateUser(UserDto user)
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.UpdateUser(_mapper.Map<User>(user))));
        }

        #endregion

        #region DesksWork

        [HttpGet]
        public JsonResult GetDesks()
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.GetDesks()));
        }

        [HttpPost]
        public JsonResult GetDesksOfOneRoom(RoomDto room)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.GetDesks(_mapper.Map<Room>(room))));
        }

        [HttpPost]
        public JsonResult CreateDesk(DeskDto desk)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.CreateDesk(_mapper.Map<Desk>(desk))));
        }

        [HttpPost]
        public JsonResult DeleteDesk(DeskDto desk)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.DeleteDesk(_mapper.Map<Desk>(desk))));
        }
        [HttpPost]
        public JsonResult UpdateDesks(DeskDto desk)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.UpdateDesks(_mapper.Map<Desk>(desk))));
        }

        #endregion

        #region BookingInfoWork

        [HttpPost]
        public JsonResult DeleteBookingInfo(BookingInfoDto bookingInfo)
        {
            return Json(
                _mapper.Map<List<BookingInfoDto>>(
                    _adminService.DeleteBookingInfo(_mapper.Map<BookingInfo>(bookingInfo))));
        }

        [HttpGet]
        public JsonResult GetBookingInfo()
        {
            return Json(
                _mapper.Map<List<BookingInfoDto>>(_adminService.GetBookingInfo()));
        }

        [HttpPost]
        public JsonResult CreateBookingInfo(BookingInfoDto bookingInfo)
        {
            return Json(
                _mapper.Map<List<BookingInfo>>(_adminService.CreateBookingInfo(_mapper.Map<BookingInfo>(bookingInfo))));
        }
        [HttpPost]
        public JsonResult UpdateBookingInfo(BookingInfoDto booking)
        {
            return Json(
                _mapper.Map<List<BookingInfoDto>>(_adminService.UpdateBookingInfo(_mapper.Map<BookingInfo>(booking))));
        }

        [HttpPost]
        public JsonResult GetBookingInfoAboutOneRoom(RoomDto room)
        {
            return Json(_mapper.Map<BookingInfo>(_adminService.GetBookingInfoAboutOneRoom(_mapper.Map<Room>(room))));
        }

        #endregion

        #region WorkPlanWork
        
        [HttpGet]
        public JsonResult GetWorkPlans()
        {
            return Json(_mapper.Map<WorkPlanDto>(_adminService.GetWorkPlans()));
        }

        [HttpPost]
        public JsonResult UpdateWorkPlan(WorkPlanDto workPlan)
        {
            return Json(_mapper.Map<List<WorkPlanDto>>(_adminService.UpdateWorkPlan(_mapper.Map<WorkPlan>(workPlan))));
        }

        [HttpPost]
        public JsonResult DeleteWorkPlan(WorkPlanDto workPlan)
        {
            return Json(_mapper.Map<List<WorkPlanDto>>(_adminService.DeleteWorkPlan(_mapper.Map<WorkPlan>(workPlan))));
        }

        #endregion

        #region WorkingDaysCalendarWork

        [HttpGet]
        public JsonResult GetWorkingDayCalendars()
        {
            return Json(_mapper.Map<List<WorkingDaysCalendarDto>>(_adminService.GetWorkingDayCalendars()));
        }

        [HttpPost]
        public JsonResult SetDayOff(WorkingDaysCalendarDto workingDaysCalendar)
        {
            return Json(_mapper.Map<List<WorkingDaysCalendarDto>>(
                _adminService.SetDayOff(_mapper.Map<WorkingDaysCalendar>(workingDaysCalendar))));
        }

        #endregion

        [HttpGet]
        public JsonResult GetDesksStatuses()
        {
            return Json(_mapper.Map<List<DeskStatusLookup>>(_adminService.GetDesksStatuses()));
        }

        [HttpGet]
        public JsonResult GetPositions()
        {
            return Json(_mapper.Map<UserPositionDto>(_adminService.GetPositions()));
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            return Json(_mapper.Map<UserRoleLookUpDto>(_adminService.GetRoles()));
        }

        [HttpGet]
        public JsonResult GetRooms()
        {
            return Json(_mapper.Map<RoomDto>(_adminService.GetRooms()));
        }

    }
}
