using System;
using System.Collections.Generic;
using DB.Entity;
using DB.LookupTable;

namespace Service.AdminService.Interfaces
{
    public interface IAdminService
    {
        List<User> GetUsers();
        List<User> CreateUser(User user);
        List<User> UpdateUser(User user);
        List<User> DeleteUser(User user);
        List<User> OrderUsersBy<TKey>(Func<User, TKey> key);
        List<User> FilterBy(Func<User, bool> predicate, List<User> users);
        List<Desk> GetDesks();
        List<Desk> UpdateDesks(Desk desk);
        List<Desk> CreateDesk(Desk desk);
        List<Desk> DeleteDesk(Desk desk);
        List<Desk> GetDesks(Room room);
        List<DeskStatusLookup> GetDesksStatuses();
        List<BookingInfo> GetBookingInfo();
        List<BookingInfo> CreateBookingInfo(BookingInfo booking);
        List<BookingInfo> UpdateBookingInfo(BookingInfo booking);
        List<BookingInfo> DeleteBookingInfo(BookingInfo booking);
        BookingInfo GetBookingInfoAboutOneRoom(Room room);
        List<UserPosition> GetPositions();
        List<UserRoleLookup> GetRoles();
        List<Room> GetRooms();
        List<WorkPlan> GetWorkPlans();
        List<WorkPlan> UpdateWorkPlan(WorkPlan workPlanDto);
        List<WorkPlan> DeleteWorkPlan(WorkPlan workPlanDto);
        void UpdateWorkPlan(User user, WorkPlan workPlan);
        void UpdateDesk(User user, Desk desk);
        List<WorkingDaysCalendar> GetWorkingDayCalendars();
        List<WorkingDaysCalendar> SetDayOff(WorkingDaysCalendar calendar);
    }
}
