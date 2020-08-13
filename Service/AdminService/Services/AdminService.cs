using AutoMapper;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DB.LookupTable;
using Service.AdminService.Changers;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<WorkingDaysCalendar> _calendarRepository;
        private readonly IRepository<Desk> _deskRepository;
        private readonly IRepository<BookingInfo> _bookingInfoRepository;
        private readonly IRepository<UserPosition> _userPositionRepository;
        private readonly IRepository<UserRoleLookup> _userRoleLookupRepository;
        private readonly IRepository<WorkPlan> _workPlanRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<DeskStatusLookup> _deskStatusRepository;
        private IUnitOfWork DataBase { get; }
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            DataBase = unitOfWork;
            _userRepository = DataBase.UserRepository;
            _calendarRepository = DataBase.CalendarRepository;
            _deskRepository = DataBase.DeskRepository;
            _bookingInfoRepository = DataBase.BookingInfoRepository;
            _userPositionRepository = DataBase.UserPositionRepository;
            _userRoleLookupRepository = DataBase.UserRoleLookupRepository;
            _workPlanRepository = DataBase.WorkPlanRepository;
            _roomRepository = DataBase.RoomRepository;
            _deskStatusRepository = DataBase.DeskStatusRepository;
            _mapper = mapper;
        }

        public List<UserDto> GetUsers()
        {
            return _mapper.Map<List<UserDto>>(_userRepository.ReadAll().ToList());
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
            return _mapper.Map<List<DeskDto>>(_deskRepository.ReadAll());
        }

        public List<DeskDto> UpdateDesks(DeskDto desk)
        {
            Desk deskUp = DeskChanger.ChangeFromDto(_deskRepository.Read(desk.Id), desk);
            deskUp.Room = _roomRepository.Read(desk.Room.Id);
            _deskRepository.Update(deskUp);
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskDto> CreateDesk(DeskDto desk)
        {
            Desk result = (Desk)desk;
            //тут могут быть вопросы, там нет поля для id, чтобы не создавать двойную связь
            result.User = _userRepository.Read(u => u.Id == desk.User.Id);
            _deskRepository.Create(result);
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskDto> DeleteDesk(DeskDto desk)
        {
            _deskRepository.Delete(_deskRepository.Read(desk.Id));
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskStatusLookUpDto> GetDesksStatuses()
        {
            return _mapper.Map<List<DeskStatusLookUpDto>>(_deskStatusRepository.ReadAll());
        }

        public List<BookingInfoDto> GetBookingInfo()
        {
            return _mapper.Map<List<BookingInfoDto>>(_bookingInfoRepository.ReadAll());
        }
        public List<BookingInfoDto> CreateBookingInfo(BookingInfoDto booking)
        {
            BookingInfo bookingInfo = (BookingInfo)booking;
            _bookingInfoRepository.Create(bookingInfo);
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<BookingInfoDto> UpdateBookingInfo(BookingInfoDto booking)
        {
            BookingInfo info = BookingInfoChanger.ChangeFromDto(_bookingInfoRepository.Read(booking.Id), booking);
            _bookingInfoRepository.Update(info);
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<BookingInfoDto> DeleteBookingInfo(BookingInfoDto booking)
        {
            _bookingInfoRepository.Delete(_bookingInfoRepository.Read(booking.Id));
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<UserDto> CreateUser(UserDto user)
        {
            User result = (User)user;
            //result.Room = _roomRepository.Read(user.Room.Id);
            //result.Position = _userPositionRepository.Read(user.Position.Id);
            //result.WorkPlan = _workPlanRepository.Read(user.WorkPlan.Id);
            //result.Desk = _deskRepository.Read(user.Desk.Id);
            _userRepository.Create(result);
            DataBase.Save();
            return GetUsers();
        }

        public List<UserDto> UpdateUser(UserDto user)
        {
            User result = UserChanger.ChangeFromDto(_userRepository.Read(user.Id), user);
            _userRepository.Update(result);
            DataBase.Save();
            return GetUsers();
        }

        public List<UserDto> DeleteUser(UserDto user)
        {
            _userRepository.Delete(_userRepository.Read(user.Id));
            DataBase.Save();
            return GetUsers();
        }

        public List<UserPositionDto> GetPositions()
        {
            return _mapper.Map<List<UserPositionDto>>(_userPositionRepository.ReadAll());
        }

        public List<UserRoleLookUpDto> GetRoles()
        {
            return _mapper.Map<List<UserRoleLookUpDto>>(_userRoleLookupRepository.ReadAll());
        }

        public List<WorkPlanDto> GetWorkPlans()
        {
            return _mapper.Map<List<WorkPlanDto>>(_workPlanRepository.ReadAll());
        }

        public List<RoomDto> GetRooms()
        {
            return _mapper.Map<List<RoomDto>>(_roomRepository.ReadAll());
        }

        public List<DeskDto> GetDesks(RoomDto room)
        {
            return GetDesks(u => u.Room.Id == room.Id);
        }

        private List<DeskDto> GetDesks(Func<Desk, bool> predicate)
        {
            return _mapper.Map<List<DeskDto>>(_deskRepository.ReadAll(predicate));
        }

        public BookingInfoDto GetBookingInfoAboutOneRoom(RoomDto room)
        {
            return _mapper.Map<BookingInfoDto>(_bookingInfoRepository.Read(u=>u.Id==room.BookingInfoId));
        }

        public List<WorkPlanDto> UpdateWorkPlan(WorkPlanDto workPlanDto)
        {
            WorkPlan plan = WorkPlanChanger.ChangeFromDto(_workPlanRepository.Read(workPlanDto.Id), workPlanDto);
            _workPlanRepository.Update(plan);
            DataBase.Save();
            return GetWorkPlans();
        }

        public List<WorkPlanDto> DeleteWorkPlan(WorkPlanDto workPlanDto)
        {
            _workPlanRepository.Delete(_workPlanRepository.Read(workPlanDto.Id));
            DataBase.Save();
            return GetWorkPlans();
        }

        public void UpdateWorkPlan(UserDto user, WorkPlanDto workPlan)
        {
            var repUser = _userRepository.Read(user.Id);
            repUser.WorkPlan = (WorkPlan)workPlan;
            _userRepository.Update(repUser);
        }

        public void UpdateDesk(UserDto user, DeskDto desk)
        {
            var repUser = _userRepository.Read(user.Id);
            repUser.Desk = (Desk)desk;
            _userRepository.Update(repUser);
        }

        public List<WorkingDaysCalendarDto> GetWorkingDayCalendars()
        {
            return _mapper.Map<List<WorkingDaysCalendar>, List<WorkingDaysCalendarDto>>(_calendarRepository.ReadAll().ToList());
        }

        public void SetDayOff(WorkingDaysCalendarDto calendar)
        {
            var cal = _calendarRepository.Read(calendar.Id);
            cal.IsOff = true;
            _calendarRepository.Update(cal);
        }
    }
}
