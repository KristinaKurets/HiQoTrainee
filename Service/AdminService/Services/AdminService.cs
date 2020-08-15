﻿using AutoMapper;
using DB.Entity;
using Repository.UnitOfWork;
using Service.AdminService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DB.LookupTable;

namespace Service.AdminService.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork DataBase { get; }

        public AdminService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }

        private bool CheckNull<T>(IEnumerable<T> source)
        {
            return source != null;
        }

        private bool CheckNull<T>(T source)
        {
            return source != null;
        }

        public List<User> GetUsers()
        {
            return DataBase.UserRepository.ReadAll().ToList();
        }

        public List<User> OrderUsersBy<TKey>(Func<User, TKey> key)
        {
            return GetUsers().OrderBy(key).ToList();
        }
        //добавлена проверка на null
        public List<User> FilterBy(Func<User, bool> predicate, List<User> users)
        {
            if(CheckNull(users))
                return users.Where(predicate).ToList();
            return new List<User>();
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
                //я хз, как тут правильно сделать
                //Desk deskUp = DeskChanger.ChangeFromDto(DataBase.DeskRepository.Read(desk.Id), desk);
                DataBase.DeskRepository.Update(desk);
                DataBase.Save();
                return GetDesks();
            }
            return null;
        }

        public List<Desk> CreateDesk(Desk desk)
        {
            Desk result = desk;
            //тут могут быть вопросы, там нет поля для id, чтобы не создавать двойную связь
            result.User = DataBase.UserRepository.Read(u => desk.User != null && u.Id == desk.User.Id);
            DataBase.DeskRepository.Create(result);
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
            BookingInfo bookingInfo = (BookingInfo)booking;
            DataBase.BookingInfoRepository.Create(bookingInfo);
            DataBase.Save();
            return GetBookingInfo();
        }
        //проверить и дописать
        public List<BookingInfo> UpdateBookingInfo(BookingInfo booking)
        {

            DataBase.BookingInfoRepository.Update(booking);
            DataBase.Save();
            return GetBookingInfo();
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
            DataBase.UserRepository.Update(user);
            DataBase.Save();
            return GetUsers();
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
            return GetDesks(u => u.Room.Id == room.Id);
        }

        private List<Desk> GetDesks(Func<Desk, bool> predicate)
        {
            return DataBase.DeskRepository.ReadAll(predicate).ToList();
        }

        public BookingInfo GetBookingInfoAboutOneRoom(Room room)
        {
            return DataBase.BookingInfoRepository.Read(u=>u.Id==room.BookingInfoId);
        }

        public List<WorkPlan> UpdateWorkPlan(WorkPlan workPlan)
        {
            //WorkPlan plan = WorkPlanChanger.ChangeFromDto(DataBase.WorkPlanRepository.Read(workPlanDto.Id), workPlanDto);
            DataBase.WorkPlanRepository.Update(workPlan);
            DataBase.Save();
            return GetWorkPlans();
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
            var cal = DataBase.CalendarRepository.Read(calendar.Id);
            cal.IsOff = true;
            DataBase.CalendarRepository.Update(cal);
            DataBase.Save();
            return GetWorkingDayCalendars();
        }
    }
}
