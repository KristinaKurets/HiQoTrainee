using AutoMapper;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO;
using Service.AdminService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.AdminService.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<WorkingDaysCalendar> calendarRepository;
        private IUnitOfWork DataBase { get; set; }

        public AdminService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
            userRepository = DataBase.GetRepository<User>();
            calendarRepository = DataBase.GetRepository<WorkingDaysCalendar>();
        }

        public List<UserDto> GetUsers()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = configuration.CreateMapper();
            var users = userRepository.ReadAll().ToList();
            var workPlan = users.First().WorkPlan;
            return mapper.Map<List<UserDto>>(users);
        }

        public List<UserDto> OrderUsersBy<TKey>(Func<UserDto, TKey> key)
        {
            return GetUsers().OrderBy(key).ToList();
        }

        public List<UserDto> FilterBy(Func<UserDto, bool> predicate, List<UserDto> users)
        {
            return users.Where(predicate).ToList();
        }

        public void UpdateWorkPlan(UserDto user, WorkPlanDto workPlan)
        {
            var repUser = userRepository.Read(user.Id);
            repUser.WorkPlan = workPlan;
            userRepository.Update(repUser);
        }

        public void UpdateDesk(UserDto user, DeskDto desk)
        {
            var repUser = userRepository.Read(user.Id);
            repUser.Desk = desk;
            userRepository.Update(repUser);
        }

        public List<WorkingDayCalendarDto> GetWorkingDayCalendars()
        {
            var mapper = new MapperConfiguration(confiExpression =>
            confiExpression.CreateMap<User, UserDto>()).CreateMapper();
            return mapper.Map<List<WorkingDaysCalendar>, List<WorkingDayCalendarDto>>(calendarRepository.ReadAll().ToList());
        }

        public void SetDayOff(WorkingDayCalendarDto calendar)
        {
            var cal = calendarRepository.Read(calendar.Id);
            cal.IsOff = true;
            calendarRepository.Update(cal);
        }
    }
}
