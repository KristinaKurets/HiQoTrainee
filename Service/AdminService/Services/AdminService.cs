using DB.Entity;
using Repository.UnitOfWork;
using Service.AdminService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DB.LookupTable;
using Service.AdminService.Changers;

namespace Service.AdminService.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork DataBase { get; }

        public AdminService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }

        public List<User> GetNewcomers()
        {
            bool IsNewcomer(User user) => user.WorkPlan == null;
            return DataBase.UserRepository.ReadAll(IsNewcomer).ToList();
        }
        private bool CheckNull<T>(T source)
        {
            return source != null;
        }

        public List<User> GetUsers()
        {
            return DataBase.UserRepository.ReadAll().ToList();
        }

        public List<Room> CreateRoom(Room room)
        {
            DataBase.RoomRepository.Create(room);
            DataBase.Save();
            return GetRooms();
        }

        public List<User> OrderUsersBy<TKey>(Func<User, TKey> key)
        {
            return GetUsers().OrderBy(key).ToList();
        }
        //добавлена проверка на null
        public List<User> FilterBy(Func<User, bool> predicate, List<User> users)
        {
            return CheckNull(users) ? users.Where(predicate).ToList() : new List<User>();
            //добавить в логгер сообщение о null
        }

        public List<Desk> GetDesks()
        {
            return DataBase.DeskRepository.ReadAll().ToList();
        }
        //дописать
        public List<Desk> UpdateDesks(Desk desk)
        {
            if (CheckNull(desk))
            {
                var updatedDesk = DataBase.DeskRepository.Read(desk.Id);
                if (CheckNull(updatedDesk))
                {
                    DataBase.DeskRepository.Update(DeskChanger.ChangeFromDto(updatedDesk, desk));
                    DataBase.Save();
                    return GetDesks();
                }
            }
            return null;
        }

        public List<Desk> CreateDesk(Desk desk)
        {
            DataBase.DeskRepository.Create(desk);
            DataBase.Save();
            return GetDesks();
        }

        public List<Desk> DeleteDesk(Desk desk)
        {
            DataBase.DeskRepository.Delete(DataBase.DeskRepository.Read(desk.Id));
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskStatusLookup> GetDesksStatuses()
        {
            return DataBase.DeskStatusRepository.ReadAll().ToList();
        }

        public List<BookingInfo> GetBookingInfo()
        {
            return DataBase.BookingInfoRepository.ReadAll().ToList();
        }
        public List<BookingInfo> CreateBookingInfo(BookingInfo booking)
        {
            DataBase.BookingInfoRepository.Create(booking);
            DataBase.Save();
            return GetBookingInfo();
        }
        //проверить и дописать
        public List<BookingInfo> UpdateBookingInfo(BookingInfo booking)
        {
            if (CheckNull(booking))
            {
                var updatedBooking = DataBase.BookingInfoRepository.Read(booking.Id);
                if (CheckNull(updatedBooking))
                {
                    DataBase.BookingInfoRepository.Update(BookingInfoChanger.ChangeFromDto(updatedBooking, booking));
                    DataBase.Save();
                    return GetBookingInfo();
                }
            }

            return null;
        }

        public List<BookingInfo> DeleteBookingInfo(BookingInfo booking)
        {
            DataBase.BookingInfoRepository.Delete(DataBase.BookingInfoRepository.Read(booking.Id));
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<User> CreateUser(User user)
        {
            User result = (User)user;
            DataBase.UserRepository.Create(result);
            DataBase.Save();
            return GetUsers();
        }
        //проверить и дописать
        public List<User> UpdateUser(User user)
        {
            //User result = UserChanger.ChangeFromDto(DataBase.UserRepository.Read(user.Id), user);
            if (CheckNull(user))
            {
                var updatedUser = DataBase.UserRepository.Read(user.Id);
                if (CheckNull(updatedUser))
                {
                    DataBase.UserRepository.Update(UserChanger.ChangeFromDto(updatedUser, user));
                    DataBase.Save();
                    return GetUsers();
                }
            }
            return null;
        }

        public List<User> DeleteUser(User user)
        {
            DataBase.UserRepository.Delete(DataBase.UserRepository.Read(user.Id));
            DataBase.Save();
            return GetUsers();
        }

        public List<UserPosition> GetPositions()
        {
            return DataBase.UserPositionRepository.ReadAll().ToList();
        }

        public List<UserRoleLookup> GetRoles()
        {
            return DataBase.UserRoleLookupRepository.ReadAll().ToList();
        }

        public List<WorkPlan> GetWorkPlans()
        {
            return DataBase.WorkPlanRepository.ReadAll().ToList();
        }

        public List<Room> GetRooms()
        {
            return DataBase.RoomRepository.ReadAll().ToList();
        }

        public List<Desk> GetDesks(Room room)
        {
            return DataBase.DeskRepository.ReadAll(u => u.RoomId == room.Id).ToList();
        }

        public BookingInfo GetBookingInfoAboutOneRoom(Room room)
        {
            return CheckNull(room) ? DataBase.RoomRepository.Read(u=>u.Id==room.Id).BookingInfo : null;
        }

        public List<WorkPlan> UpdateWorkPlan(WorkPlan workPlan)
        {
            if (CheckNull(workPlan))
            {
                var updatedWorkPlan = DataBase.WorkPlanRepository.Read(workPlan.Id);
                if (CheckNull(updatedWorkPlan))
                {
                    DataBase.WorkPlanRepository.Update(WorkPlanChanger.ChangeFromDto(updatedWorkPlan, workPlan));
                    DataBase.Save();
                    return GetWorkPlans();
                }
            }

            return null;
        }

        public List<WorkPlan> DeleteWorkPlan(WorkPlan workPlanDto)
        {
            DataBase.WorkPlanRepository.Delete(DataBase.WorkPlanRepository.Read(workPlanDto.Id));
            DataBase.Save();
            return GetWorkPlans();
        }
        //проверить и дописать
        public void UpdateWorkPlan(User user, WorkPlan workPlan)
        {
            var repUser = DataBase.UserRepository.Read(user.Id);
            repUser.WorkPlan = (WorkPlan)workPlan;
            DataBase.UserRepository.Update(repUser);
        }
        //проверить и дописать
        public void UpdateDesk(User user, Desk desk)
        {
            var repUser = DataBase.UserRepository.Read(user.Id);
            repUser.Desk = (Desk)desk;
            DataBase.UserRepository.Update(repUser);
        }

        public List<WorkingDaysCalendar> GetWorkingDayCalendars()
        {
            return DataBase.CalendarRepository.ReadAll().ToList();
        }
        //проверить и дописать
        public List<WorkingDaysCalendar> SetDayOff(WorkingDaysCalendar calendar)
        {
            if (CheckNull(calendar))
            {
                DataBase.CalendarRepository.Create(calendar);
                DataBase.Save();
                return GetWorkingDayCalendars();
            }
            return null;
        }
    }
}
