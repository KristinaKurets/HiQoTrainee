using Repository.Interface;
using System;
using DB.Entity;
using DB.LookupTable;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<WorkingDaysCalendar> CalendarRepository { get; }
        IRepository<Desk> DeskRepository { get; }
        IRepository<BookingInfo> BookingInfoRepository { get; }
        IRepository<UserPosition> UserPositionRepository { get; }
        IRepository<UserRoleLookup> UserRoleLookupRepository { get; }
        IRepository<WorkPlan> WorkPlanRepository { get; }
        IRepository<Room> RoomRepository { get; }
        IRepository<DeskStatusLookup> DeskStatusRepository { get; }
        IRepository<Order> OrderRepository { get; }
        void Save();
    }
}
