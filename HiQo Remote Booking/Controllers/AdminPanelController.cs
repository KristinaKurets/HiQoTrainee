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

    /// <summary>Class controller which contains admin function.</summary>
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


        /// <summary>  Get only newcomers.</summary>
        /// <returns>List of newcomers </returns>
        [HttpGet]
        public JsonResult NewComers()
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.FilterBy(u => u.Room == null, _adminService.GetUsers())));
        }

        /// <summary> Get all users.</summary>
        /// <returns>List of user .</returns>
        [HttpGet]
        public JsonResult AllUsers()
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.GetUsers()));
        }

        /// <summary>Creates the user.</summary>
        /// <param name="user">
        /// <para>The user.</para>
        /// <remarks>It's view for entity <see cref="User"/></remarks>
        /// </param>
        /// <returns>List of exist user . </returns>
        [HttpPost]
        public JsonResult CreateUser(UserDto user)
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.CreateUser(_mapper.Map<User>(user))));
        }

        /// <summary>Deletes the user.</summary>
        /// <param name="user">
        /// <para>The user.</para>
        /// <remarks>It's view for entity <see cref="User"/></remarks>
        /// </param>
        /// <returns>List of exist user </returns>
        [HttpPost]
        public JsonResult DeleteUser(UserDto user)
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.DeleteUser(_mapper.Map<User>(user))));
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">
        /// <para> The user.</para>
        /// <remarks>It's view for entity <see cref="User"/> </remarks>
        /// </param>
        /// <returns>List of exist user </returns>
        [HttpPost]
        public JsonResult UpdateUser(UserDto user)
        {
            return Json(_mapper.Map<List<UserDto>>(_adminService.UpdateUser(_mapper.Map<User>(user))));
        }

        #endregion

        #region DesksWork

        /// <summary>Gets all desks.</summary>
        /// <returns>List of desks.</returns>
        [HttpGet]
        public JsonResult GetDesks()
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.GetDesks()));
        }

        /// <summary>Gets the desks of one room.</summary>
        /// <param name="room">
        /// <para>
        ///  The room.
        /// </para>
        /// <remarks>It's view for entity <see cref="Room"/></remarks>
        /// </param>
        /// <returns>List of desk in the room .</returns>
        [HttpPost]
        public JsonResult GetDesksOfOneRoom(RoomDto room)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.GetDesks(_mapper.Map<Room>(room))));
        }

        /// <summary>Creates the desk.</summary>
        /// <param name="desk">
        /// <para>
        ///     The desk.
        /// </para>
        /// <remarks>It's view for entity <see cref="Desk"/></remarks>
        /// </param>
        /// <returns>List of desks.</returns>
        [HttpPost]
        public JsonResult CreateDesk(DeskDto desk)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.CreateDesk(_mapper.Map<Desk>(desk))));
        }

        /// <summary>Delete the desk.</summary>
        /// <param name="desk">
        /// <para>
        ///  The desk.
        /// </para>
        /// <remarks>It's view for entity <see cref="Desk"/></remarks>
        /// </param>
        /// <returns>List of desks.</returns>
        [HttpPost]
        public JsonResult DeleteDesk(DeskDto desk)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.DeleteDesk(_mapper.Map<Desk>(desk))));
        }

        /// <summary>Updates the desk.</summary>
        /// <param name="desk">
        /// <para>The new desk.</para>
        /// <remarks>It's view for entity <see cref="Desk"/></remarks>
        /// </param>
        /// <returns>List of desks.</returns>
        [HttpPost]
        public JsonResult UpdateDesks(DeskDto desk)
        {
            return Json(_mapper.Map<List<DeskDto>>(_adminService.UpdateDesks(_mapper.Map<Desk>(desk))));
        }

        #endregion

        #region BookingInfoWork


        /// <summary>Delete the booking information.</summary>
        /// <param name="bookingInfo">
        /// <para>The booking information.</para>
        /// <remarks>It's view for entity <see cref="BookingInfo"/></remarks>
        /// </param>
        /// <returns>List of booking information.</returns>
        [HttpPost]
        public JsonResult DeleteBookingInfo(BookingInfoDto bookingInfo)
        {
            return Json(
                _mapper.Map<List<BookingInfoDto>>(
                    _adminService.DeleteBookingInfo(_mapper.Map<BookingInfo>(bookingInfo))));
        }

        /// <summary>Gets the booking information.</summary>
        /// <returns>List of booking information. </returns>
        [HttpGet]
        public JsonResult GetBookingInfo()
        {
            return Json(
                _mapper.Map<List<BookingInfoDto>>(_adminService.GetBookingInfo()));
        }

        /// <summary>Creates the booking information.</summary>
        /// <param name="bookingInfo">
        /// <para>The booking information.</para>
        /// <remarks>It's view for entity <see cref="BookingInfo"/></remarks>
        /// </param>
        /// <returns>List of booking information.</returns>
        [HttpPost]
        public JsonResult CreateBookingInfo(BookingInfoDto bookingInfo)
        {
            return Json(
                _mapper.Map<List<BookingInfo>>(_adminService.CreateBookingInfo(_mapper.Map<BookingInfo>(bookingInfo))));
        }

        /// <summary>Updates the booking information.</summary>
        /// <param name="booking">
        /// <para>The booking information.</para>
        /// <remarks>It's view for entity <see cref="BookingInfo"/></remarks>
        /// </param>
        /// <returns>List of the booking information.</returns>
        [HttpPost]
        public JsonResult UpdateBookingInfo(BookingInfoDto booking)
        {
            return Json(
                _mapper.Map<List<BookingInfoDto>>(_adminService.UpdateBookingInfo(_mapper.Map<BookingInfo>(booking))));
        }

        /// <summary>Gets the booking information about one room.</summary>
        /// <param name="room">
        /// <para>The room.</para>
        /// <remarks>It's view for entity <see cref="Room"/></remarks>
        /// </param>
        /// <returns>Booking information about the room.</returns>
        [HttpPost]
        public JsonResult GetBookingInfoAboutOneRoom(RoomDto room)
        {
            return Json(_mapper.Map<BookingInfo>(_adminService.GetBookingInfoAboutOneRoom(_mapper.Map<Room>(room))));
        }

        #endregion

        #region WorkPlanWork

        /// <summary>Gets all work plans.</summary>
        /// <returns>List of Work plans.</returns>
        [HttpGet]
        public JsonResult GetWorkPlans()
        {
            return Json(_mapper.Map<List<WorkPlanDto>>(_adminService.GetWorkPlans()));
        }

        /// <summary>Updates the work plan.</summary>
        /// <param name="workPlan">
        /// <para>The work plan for updating.</para>
        /// <remarks>It's view for entity <see cref="WorkPlan"/></remarks>
        /// </param>
        /// <returns>List of work plans.</returns>
        [HttpPost]
        public JsonResult UpdateWorkPlan(WorkPlanDto workPlan)
        {
            return Json(_mapper.Map<List<WorkPlanDto>>(_adminService.UpdateWorkPlan(_mapper.Map<WorkPlan>(workPlan))));
        }

        /// <summary>Deletes the work plan.</summary>
        /// <param name="workPlan">
        /// <para>The work plan for removal.</para>
        /// <remarks>It's view for entity <see cref="WorkPlan"/></remarks>
        /// </param>
        /// <returns>List of work plans.</returns>
        [HttpPost]
        public JsonResult DeleteWorkPlan(WorkPlanDto workPlan)
        {
            return Json(_mapper.Map<List<WorkPlanDto>>(_adminService.DeleteWorkPlan(_mapper.Map<WorkPlan>(workPlan))));
        }

        #endregion

        #region WorkingDaysCalendarWork

        /// <summary>Gets the working day calendars.</summary>
        /// <returns>List of working day calendars.</returns>
        [HttpGet]
        public JsonResult GetWorkingDayCalendars()
        {
            return Json(_mapper.Map<List<WorkingDaysCalendarDto>>(_adminService.GetWorkingDayCalendars()));
        }

        /// <summary>Sets the day off.</summary>
        /// <param name="workingDaysCalendar">
        /// <para>The working days calendar.</para>
        /// <remarks>It's view for entity <see cref="WorkingDaysCalendar"/>.</remarks>
        /// </param>
        /// <returns>List of working days calendar.</returns>
        [HttpPost]
        public JsonResult SetDayOff(WorkingDaysCalendarDto workingDaysCalendar)
        {
            return Json(_mapper.Map<List<WorkingDaysCalendarDto>>(
                _adminService.SetDayOff(_mapper.Map<WorkingDaysCalendar>(workingDaysCalendar))));
        }

        #endregion

        /// <summary>Gets the desks statuses.</summary>
        /// <returns>List of desks status.</returns>
        [HttpGet]
        public JsonResult GetDesksStatuses()
        {
            return Json(_mapper.Map<List<DeskStatusLookup>>(_adminService.GetDesksStatuses()));
        }

        /// <summary>Gets the user positions.</summary>
        /// <returns>List of user positions.</returns>
        [HttpGet]
        public JsonResult GetPositions()
        {
            return Json(_mapper.Map<UserPositionDto>(_adminService.GetPositions()));
        }

        /// <summary>Gets the user roles.</summary>
        /// <returns>List of user roles.</returns>
        [HttpGet]
        public JsonResult GetRoles()
        {
            return Json(_mapper.Map<List<UserRoleLookUpDto>>(_adminService.GetRoles()));
        }

        /// <summary>Gets the rooms.</summary>
        /// <returns>List of rooms.</returns>
        [HttpGet]
        public JsonResult GetRooms()
        {
            return Json(_mapper.Map<RoomDto>(_adminService.GetRooms()));
        }

    }
}
