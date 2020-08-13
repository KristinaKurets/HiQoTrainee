using AutoMapper;
using DB.Entity;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Service.AdminService.Changers;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork DataBase { get; }
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            DataBase = unitOfWork;
            _mapper = mapper;
        }

        public List<UserDto> GetUsers()
        {
            return _mapper.Map<List<UserDto>>(DataBase.UserRepository.ReadAll().ToList());
        }

        public List<UserDto> OrderUsersBy<TKey>(Func<UserDto, TKey> key)
        {
            return GetUsers().OrderBy(key).ToList();
        }

        public List<UserDto> FilterBy(Func<UserDto, bool> predicate, List<UserDto> users)
        {
            return users.Where(predicate).ToList();
        }

        public List<DeskDto> GetDesks()
        {
            return _mapper.Map<List<DeskDto>>(DataBase.DeskRepository.ReadAll());
        }

        public List<DeskDto> UpdateDesks(DeskDto desk)
        {
            Desk deskUp = DeskChanger.ChangeFromDto(DataBase.DeskRepository.Read(desk.Id), desk);
            DataBase.DeskRepository.Update(deskUp);
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskDto> CreateDesk(DeskDto desk)
        {
            Desk result = (Desk)desk;
            //тут могут быть вопросы, там нет поля для id, чтобы не создавать двойную связь
            result.User = DataBase.UserRepository.Read(u => u.Id == desk.User.Id);
            DataBase.DeskRepository.Create(result);
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskDto> DeleteDesk(DeskDto desk)
        {
            DataBase.DeskRepository.Delete(DataBase.DeskRepository.Read(desk.Id));
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskStatusLookUpDto> GetDesksStatuses()
        {
            return _mapper.Map<List<DeskStatusLookUpDto>>(DataBase.DeskStatusRepository.ReadAll());
        }

        public List<BookingInfoDto> GetBookingInfo()
        {
            return _mapper.Map<List<BookingInfoDto>>(DataBase.BookingInfoRepository.ReadAll());
        }
        public List<BookingInfoDto> CreateBookingInfo(BookingInfoDto booking)
        {
            BookingInfo bookingInfo = (BookingInfo)booking;
            DataBase.BookingInfoRepository.Create(bookingInfo);
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<BookingInfoDto> UpdateBookingInfo(BookingInfoDto booking)
        {
            BookingInfo info = BookingInfoChanger.ChangeFromDto(DataBase.BookingInfoRepository.Read(booking.Id), booking);
            DataBase.BookingInfoRepository.Update(info);
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<BookingInfoDto> DeleteBookingInfo(BookingInfoDto booking)
        {
            DataBase.BookingInfoRepository.Delete(DataBase.BookingInfoRepository.Read(booking.Id));
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<UserDto> CreateUser(UserDto user)
        {
            User result = (User)user;
            DataBase.UserRepository.Create(result);
            DataBase.Save();
            return GetUsers();
        }

        public List<UserDto> UpdateUser(UserDto user)
        {
            User result = UserChanger.ChangeFromDto(DataBase.UserRepository.Read(user.Id), user);
            DataBase.UserRepository.Update(result);
            DataBase.Save();
            return GetUsers();
        }

        public List<UserDto> DeleteUser(UserDto user)
        {
            DataBase.UserRepository.Delete(DataBase.UserRepository.Read(user.Id));
            DataBase.Save();
            return GetUsers();
        }

        public List<UserPositionDto> GetPositions()
        {
            return _mapper.Map<List<UserPositionDto>>(DataBase.UserPositionRepository.ReadAll());
        }

        public List<UserRoleLookUpDto> GetRoles()
        {
            return _mapper.Map<List<UserRoleLookUpDto>>(DataBase.UserRoleLookupRepository.ReadAll());
        }

        public List<WorkPlanDto> GetWorkPlans()
        {
            return _mapper.Map<List<WorkPlanDto>>(DataBase.WorkPlanRepository.ReadAll());
        }

        public List<RoomDto> GetRooms()
        {
            return _mapper.Map<List<RoomDto>>(DataBase.RoomRepository.ReadAll());
        }

        public List<DeskDto> GetDesks(RoomDto room)
        {
            return GetDesks(u => u.Room.Id == room.Id);
        }

        private List<DeskDto> GetDesks(Func<Desk, bool> predicate)
        {
            return _mapper.Map<List<DeskDto>>(DataBase.DeskRepository.ReadAll(predicate));
        }

        public BookingInfoDto GetBookingInfoAboutOneRoom(RoomDto room)
        {
            return _mapper.Map<BookingInfoDto>(DataBase.BookingInfoRepository.Read(u=>u.Id==room.BookingInfoId));
        }

        public List<WorkPlanDto> UpdateWorkPlan(WorkPlanDto workPlanDto)
        {
            WorkPlan plan = WorkPlanChanger.ChangeFromDto(DataBase.WorkPlanRepository.Read(workPlanDto.Id), workPlanDto);
            DataBase.WorkPlanRepository.Update(plan);
            DataBase.Save();
            return GetWorkPlans();
        }

        public List<WorkPlanDto> DeleteWorkPlan(WorkPlanDto workPlanDto)
        {
            DataBase.WorkPlanRepository.Delete(DataBase.WorkPlanRepository.Read(workPlanDto.Id));
            DataBase.Save();
            return GetWorkPlans();
        }

        public void UpdateWorkPlan(UserDto user, WorkPlanDto workPlan)
        {
            var repUser = DataBase.UserRepository.Read(user.Id);
            repUser.WorkPlan = (WorkPlan)workPlan;
            DataBase.UserRepository.Update(repUser);
        }

        public void UpdateDesk(UserDto user, DeskDto desk)
        {
            var repUser = DataBase.UserRepository.Read(user.Id);
            repUser.Desk = (Desk)desk;
            DataBase.UserRepository.Update(repUser);
        }

        public List<WorkingDaysCalendarDto> GetWorkingDayCalendars()
        {
            return _mapper.Map<List<WorkingDaysCalendar>, List<WorkingDaysCalendarDto>>(DataBase.CalendarRepository.ReadAll().ToList());
        }

        public void SetDayOff(WorkingDaysCalendarDto calendar)
        {
            var cal = DataBase.CalendarRepository.Read(calendar.Id);
            cal.IsOff = true;
            DataBase.CalendarRepository.Update(cal);
        }
    }
}
