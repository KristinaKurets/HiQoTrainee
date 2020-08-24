using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using DB.Entity;
using DB.LookupTable;
using RequestLogger.Entities;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> _repositories;
        private readonly DbContext _db;


        private IRepository<User> _userRepository;
        public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(_db);

        private IRepository<WorkingDaysCalendar> _calendarRepository;

        public IRepository<WorkingDaysCalendar> CalendarRepository =>
            _calendarRepository ??= new Repository<WorkingDaysCalendar>(_db);

        private IRepository<Desk> _deskRepository;
        public IRepository<Desk> DeskRepository => _deskRepository ??= new Repository<Desk>(_db);

        private IRepository<BookingInfo> _bookingInfoRepository;

        public IRepository<BookingInfo> BookingInfoRepository =>
            _bookingInfoRepository ??= new Repository<BookingInfo>(_db);

        private IRepository<UserPosition> _userPositionRepository;

        public IRepository<UserPosition> UserPositionRepository =>
            _userPositionRepository ??= new Repository<UserPosition>(_db);

        private IRepository<UserRoleLookup> _userRoleLookupRepository;

        public IRepository<UserRoleLookup> UserRoleLookupRepository =>
            _userRoleLookupRepository ??= new Repository<UserRoleLookup>(_db);

        private IRepository<WorkPlan> _workPlanRepository;
        public IRepository<WorkPlan> WorkPlanRepository => 
            _workPlanRepository ??= new Repository<WorkPlan>(_db);

        private IRepository<Room> _roomRepository;
        public IRepository<Room> RoomRepository => _roomRepository ??= new Repository<Room>(_db);

        private IRepository<DeskStatusLookup> _deskStatusRepository;

        public IRepository<DeskStatusLookup> DeskStatusRepository =>
            _deskStatusRepository ??= new Repository<DeskStatusLookup>(_db);

        private IRepository<Order> _orderRepository;
        public IRepository<Order> OrderRepository => _orderRepository ??= new Repository<Order>(_db);

        private IRepository<BadRequestEntity> _badRequestEntities;
        public IRepository<BadRequestEntity> BadRequestRepository => 
            _badRequestEntities ??= new Repository<BadRequestEntity>(_db);

        private IRepository<RequestProcessingEntity> _requestProccessingEnities;
        public IRepository<RequestProcessingEntity> RequestProccessingRepository
            => _requestProccessingEnities ??= new Repository<RequestProcessingEntity>(_db);


        public UnitOfWork(DbContext dbContext)
        {
            _db = dbContext;
        }
        
        private bool disposed = false;
       
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }
                
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TSource> GetRepository<TSource>() where TSource : class
        {
            _repositories ??= new Dictionary<string, object>();
            var type = typeof(TSource).Name;

            if (_repositories.ContainsKey(type)) return (IRepository<TSource>)_repositories[type];
            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TSource)), _db);
            _repositories.Add(type, repositoryInstance);
            return (IRepository<TSource>)_repositories[type];
        }

        public void Save()
        {
            using var transaction = _db.Database.BeginTransaction();
            _db.Database.ExecuteSqlRaw(string.Format(RepositoryResources.UsersIdentityInsertOn));
            _db.SaveChanges();
            _db.Database.ExecuteSqlRaw(string.Format(RepositoryResources.UsersIdentityInsertOff));
            transaction.Commit();
        }
    }
}
