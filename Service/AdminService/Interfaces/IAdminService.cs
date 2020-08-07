using Service.AdminService.DTO;
using Service.AdminService.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using DB.Entity;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Interfaces
{
    public interface IAdminService
    {
        List<WorkingDaysCalendarDto> GetWorkingDayCalendars();
        List<UserDto> GetUsers();
        List<UserDto> OrderUsersBy<TKey>(Func<UserDto, TKey> key);
        List<UserDto> FilterBy(Func<UserDto, bool> predicate, List<UserDto> users);
        List<DeskDto> GetDesks();
        List<DeskDto> UpdateDesks(DeskDto desk);
        List<DeskDto> CreateDesk(DeskDto desk);
        List<DeskDto> DeleteDesk(DeskDto desk);
        List<DeskStatusLookUpDto> GetDesksStatuses();
        List<BookingInfoDto> GetBookingInfo();
        List<BookingInfoDto> CreateBookingInfo(BookingInfoDto booking);
        List<BookingInfoDto> UpdateBookingInfo(BookingInfoDto booking);
        List<BookingInfoDto> DeleteBookingInfo(BookingInfoDto booking);
        List<UserDto> CreateUser(UserDto user);
        List<UserDto> UpdateUser(UserDto user);
        List<UserDto> DeleteUser(UserDto user);
        List<UserPositionDto> GetPositions();
        List<UserRoleLookUpDto> GetRoles();
        List<WorkPlanDto> GetWorkPlans();
        List<RoomDto> GetRooms();
        List<DeskDto> GetDesks(RoomDto room);
        BookingInfoDto GetBookingInfoAboutOneRoom(RoomDto room);
        List<WorkPlanDto> UpdateWorkPlan(WorkPlanDto workPlanDto);
        List<WorkPlanDto> DeleteWorkPlan(WorkPlanDto workPlanDto);
        void UpdateWorkPlan(UserDto user, WorkPlanDto workPlan);
        void UpdateDesk(UserDto user, DeskDto desk);
        void SetDayOff(WorkingDaysCalendarDto calendar);
    }
}
