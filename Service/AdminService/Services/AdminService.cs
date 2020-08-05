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
        private IUnitOfWork DataBase { get; set; }

        public AdminService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
            _userRepository = DataBase.GetRepository<User>();
            _calendarRepository = DataBase.GetRepository<WorkingDaysCalendar>();
            _deskRepository = DataBase.GetRepository<Desk>();
            _bookingInfoRepository = DataBase.GetRepository<BookingInfo>();
            _userPositionRepository = DataBase.GetRepository<UserPosition>();
            _userRoleLookupRepository=DataBase.GetRepository<UserRoleLookup>();
            _workPlanRepository = DataBase.GetRepository<WorkPlan>();
            _roomRepository = DataBase.GetRepository<Room>();
            _deskStatusRepository = DataBase.GetRepository<DeskStatusLookup>();
        }

        public List<UserDto> GetUsers()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = configuration.CreateMapper();
            return mapper.Map<List<UserDto>>(_userRepository.ReadAll().ToList());
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
            var mapper = new MapperConfiguration(cm => cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<List<DeskDto>>(_deskRepository.ReadAll());
        }

        public List<DeskDto> UpdateDesks(DeskDto desk)
        {
            Desk deskUp = DeskChanger.ChangeFromDto(_deskRepository.Read(desk.Id), desk);
            deskUp.Room = _roomRepository.Read(desk.RoomId);
            _deskRepository.Update(deskUp);
            DataBase.Save();
            return GetDesks();
        }

        public List<DeskDto> CreateDesk(DeskDto desk)
        {
            Desk result = (Desk)desk;
            result.Room = _roomRepository.Read(desk.RoomId);
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
            var mapper = new MapperConfiguration(cm => cm.CreateMap<DeskStatusLookup,
                DeskStatusLookUpDto>()).CreateMapper();
            return mapper.Map<List<DeskStatusLookUpDto>>(_deskStatusRepository.ReadAll());
        }

        public List<BookingInfoDto> GetBookingInfo()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<BookingInfo,
                BookingInfoDto>()).CreateMapper();
            return mapper.Map<List<BookingInfoDto>>(_bookingInfoRepository.ReadAll());
        }
        public List<BookingInfoDto> CreateBookingInfo(BookingInfoDto booking)
        {
            BookingInfo bookingInfo = (BookingInfo)booking;
            bookingInfo.Room = _roomRepository.Read(booking.RoomId);
            _bookingInfoRepository.Create(bookingInfo);
            DataBase.Save();
            return GetBookingInfo();
        }

        public List<BookingInfoDto> UpdateBookingInfo(BookingInfoDto booking)
        {
            BookingInfo info = BookingInfoChanger.ChangeFromDto(_bookingInfoRepository.Read(booking.Id), booking);
            info.Room = _roomRepository.Read(booking.RoomId);
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
            result.Room = _roomRepository.Read(user.RoomId);
            result.Position = _userPositionRepository.Read(user.UserPositionId);
            result.WorkPlan = _workPlanRepository.Read(user.WorkPlanId);
            result.Desk = _deskRepository.Read(user.DeskId);
            _userRepository.Create(result);
            DataBase.Save();
            return GetUsers();
        }

        public List<UserDto> UpdateUser(UserDto user)
        {
            User result = UserChanger.ChangeFromDto(_userRepository.Read(user.Id), user);
            result.Room = _roomRepository.Read(user.RoomId);
            result.Position = _userPositionRepository.Read(user.UserPositionId);
            result.WorkPlan = _workPlanRepository.Read(user.WorkPlanId);
            result.Desk = _deskRepository.Read(user.DeskId);
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
            var mapper = new MapperConfiguration(cm => cm.CreateMap<UserPosition,
                UserPositionDto>()).CreateMapper();
            return mapper.Map<List<UserPositionDto>>(_userPositionRepository.ReadAll());
        }

        public List<UserRoleLookUpDto> GetRoles()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<UserRoleLookup,
                UserRoleLookUpDto>()).CreateMapper();
            return mapper.Map<List<UserRoleLookUpDto>>(_userPositionRepository.ReadAll());
        }

        public List<WorkPlanDto> GetWorkPlans()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<WorkPlan,
                WorkPlanDto>()).CreateMapper();
            return mapper.Map<List<WorkPlanDto>>(_workPlanRepository.ReadAll());
        }

        public List<RoomDto> GetRooms()
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<Room, RoomDto>()).CreateMapper();
            return mapper.Map<List<RoomDto>>(_roomRepository.ReadAll());
        }

        public List<DeskDto> GetDesks(RoomDto room)
        {
            return GetDesks(u => u.Room.Id == room.Id);
        }

        private List<DeskDto> GetDesks(Func<Desk, bool> predicate)
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<Desk, DeskDto>()).CreateMapper();
            return mapper.Map<List<DeskDto>>(_deskRepository.ReadAll(predicate));
        }

        public BookingInfoDto GetBookingInfoAboutOneRoom(RoomDto room)
        {
            var mapper = new MapperConfiguration(cm => cm.CreateMap<BookingInfo,
                BookingInfoDto>()).CreateMapper();
            return mapper.Map<BookingInfoDto>(_bookingInfoRepository.ReadAll(u => u.Room.Equals((Room)room)));
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
            var mapper = new MapperConfiguration(confiExpression =>
            confiExpression.CreateMap<User, UserDto>()).CreateMapper();
            return mapper.Map<List<WorkingDaysCalendar>, List<WorkingDaysCalendarDto>>(_calendarRepository.ReadAll().ToList());
        }

        public void SetDayOff(WorkingDaysCalendarDto calendar)
        {
            var cal = _calendarRepository.Read(calendar.Id);
            cal.IsOff = true;
            _calendarRepository.Update(cal);
        }
    }
}
