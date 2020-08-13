using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using DB.Entity;
using DB.LookupTable;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //private Dictionary<string, object> repositories;
        private readonly DbContext db;


        private IRepository<User> _userRepository;
        public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(db);

        private IRepository<WorkingDaysCalendar> _calendarRepository;

        public IRepository<WorkingDaysCalendar> CalendarRepository =>
            _calendarRepository ??= new Repository<WorkingDaysCalendar>(db);

        private IRepository<Desk> _deskRepository;
        public IRepository<Desk> DeskRepository => _deskRepository ??= new Repository<Desk>(db);

        private IRepository<BookingInfo> _bookingInfoRepository;

        public IRepository<BookingInfo> BookingInfoRepository =>
            _bookingInfoRepository ??= new Repository<BookingInfo>(db);

        private IRepository<UserPosition> _userPositionRepository;

        public IRepository<UserPosition> UserPositionRepository =>
            _userPositionRepository ??= new Repository<UserPosition>(db);

        private IRepository<UserRoleLookup> _userRoleLookupRepository;

        public IRepository<UserRoleLookup> UserRoleLookupRepository =>
            _userRoleLookupRepository ??= new Repository<UserRoleLookup>(db);

        private IRepository<WorkPlan> _workPlanRepository;
        public IRepository<WorkPlan> WorkPlanRepository => 
            _workPlanRepository ??= new Repository<WorkPlan>(db);

        private IRepository<Room> _roomRepository;
        public IRepository<Room> RoomRepository => _roomRepository ??= new Repository<Room>(db);

        private IRepository<DeskStatusLookup> _deskStatusRepository;

        public IRepository<DeskStatusLookup> DeskStatusRepository =>
            _deskStatusRepository ??= new Repository<DeskStatusLookup>(db);

        private IRepository<Order> _orderRepository;
        public IRepository<Order> OrderRepository => _orderRepository ??= new Repository<Order>(db);

        public UnitOfWork(DbContext dbContext)
        {
            db = dbContext;
        }
        
        private bool disposed = false;
       
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
                
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public IRepository<TSource> GetRepository<TSource>() where TSource : class
        //{
        //    repositories ??= new Dictionary<string, object>();
        //    var type = typeof(TSource).Name;

        //    if (repositories.ContainsKey(type)) return (IRepository<TSource>) repositories[type];
        //    var repositoryType = typeof(Repository<>);
        //    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TSource)), db);
        //    repositories.Add(type, repositoryInstance);
        //    return (IRepository<TSource>)repositories[type];
        //}

        public void Save()
        {
            using var transaction = db.Database.BeginTransaction();
            db.Database.ExecuteSqlRaw(string.Format(RepositoryResources.UsersIdentityInsertOn));
            db.SaveChanges();
            db.Database.ExecuteSqlRaw(string.Format(RepositoryResources.UsersIdentityInsertOff));
            transaction.Commit();
        }
    }
}
