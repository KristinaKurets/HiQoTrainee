using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace HiQo_Remote_Booking.IEndpointsRouteBuilderExtensions
{
    public static class AdminPanelEndpointsConfigure
    {
        public static void ConfigureAdminPanelEndpoints(this IEndpointRouteBuilder endpoints)
        {
            #region UsersWork

            endpoints.MapControllerRoute(
                name: "allUsersRoles",
                pattern: "/admin/users/roles",
                defaults: new { controller = "AdminPanel", action = "GetRoles" });

            endpoints.MapControllerRoute(
                name: "allUserPositions",
                pattern: "/admin/users/positions",
                defaults: new { controller = "AdminPanel", action = "GetPositions" });

            endpoints.MapControllerRoute(
                name: "allUsers",
                pattern: "/admin/users/all",
                defaults: new { controller = "AdminPanel", action = "AllUsers" });

            endpoints.MapControllerRoute(
                name: "newcomers",
                pattern: "/admin/users/newcomers",
                defaults: new { controller = "AdminPanel", action = "NewComers" });

            endpoints.MapControllerRoute(
                name: "newUser",
                pattern: "/admin/users/new",
                defaults: new { controller = "AdminPanel", action = "CreateUser" });

            endpoints.MapControllerRoute(
                name: "newUser",
                pattern: "/admin/users/remove",
                defaults: new { controller = "AdminPanel", action = "DeleteUser" });

            endpoints.MapControllerRoute(
                name: "newUser",
                pattern: "/admin/users/update",
                defaults: new { controller = "AdminPanel", action = "UpdateUser" });

            #endregion

            #region DeskWork

            endpoints.MapControllerRoute(
                name: "allDesksStatuses",
                pattern: "/admin/desk/statuses",
                defaults: new { controller = "AdminPanel", action = "GetDesksStatuses" });

            endpoints.MapControllerRoute(
                name: "allDesks",
                pattern: "/admin/desk/all",
                defaults: new { controller = "AdminPanel", action = "GetDesks" });

            endpoints.MapControllerRoute(
                name: "roomDesks",
                pattern: "/admin/desk/all-of-one-room",
                defaults: new { controller = "AdminPanel", action = "GetDesksOfOneRoom" });

            endpoints.MapControllerRoute(
                name: "newDesk",
                pattern: "/admin/desk/new",
                defaults: new { controller = "AdminPanel", action = "CreateDesk" });

            endpoints.MapControllerRoute(
                name: "removeDesk",
                pattern: "/admin/desk/remove",
                defaults: new { controller = "AdminPanel", action = "DeleteDesk" });

            endpoints.MapControllerRoute(
                name: "updateDesk",
                pattern: "/admin/desk/update",
                defaults: new { controller = "AdminPanel", action = "UpdateDesks" });

            #endregion

            #region BookingInfoWork

            endpoints.MapControllerRoute(
                name: "deleteBookingInfo",
                pattern: "/admin/booking-info/delete",
                defaults: new { controller = "AdminPanel", action = "DeleteBookingInfo" });

            endpoints.MapControllerRoute(
                name: "newBookingInfo",
                pattern: "/admin/booking-info/new",
                defaults: new { controller = "AdminPanel", action = "CreateBookingInfo" });

            endpoints.MapControllerRoute(
                name: "allBookingInfo",
                pattern: "/admin/booking-info/all",
                defaults: new { controller = "AdminPanel", action = "GetBookingInfo" });
            
            endpoints.MapControllerRoute(
                name: "updateBookingInfo",
                pattern: "/admin/booking-info/update",
                defaults: new { controller = "AdminPanel", action = "UpdateBookingInfo" });

            endpoints.MapControllerRoute(
                name: "BookingInfoAboutOneRoom",
                pattern: "/admin/booking-info/of-one-room",
                defaults: new { controller = "AdminPanel", action = "GetBookingInfoAboutOneRoom" });

            #endregion

            #region WorkPlanWork

            endpoints.MapControllerRoute(
                name: "deleteWorkPlan",
                pattern: "/admin/work-plan/delete",
                defaults: new { controller = "AdminPanel", action = "DeleteWorkPlan" });

            endpoints.MapControllerRoute(
                name: "allWorkPlans",
                pattern: "/admin/work-plan/all",
                defaults: new { controller = "AdminPanel", action = "GetWorkPlans" });

            endpoints.MapControllerRoute(
                name: "updateWorkPlan",
                pattern: "/admin/work-plan/update",
                defaults: new { controller = "AdminPanel", action = "UpdateWorkPlan" });

            #endregion

            #region WorkingDaysCalendarWork

            endpoints.MapControllerRoute(
                name: "newWorkingDaysCalendar",
                pattern: "/admin/working-days-calendar/all",
                defaults: new { controller = "AdminPanel", action = "GetWorkingDayCalendars" });

            endpoints.MapControllerRoute(
                name: "setDayOff",
                pattern: "/admin/working-days-calendar/set-day-off",
                defaults: new { controller = "AdminPanel", action = "SetDayOff" });

            #endregion

            #region RoomWork

            endpoints.MapControllerRoute(
                name: "allRooms",
                pattern: "/admin/rooms/all",
                defaults: new { controller = "AdminPanel", action = "GetRooms" });

            #endregion
        }
    }
}