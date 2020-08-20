using Repository.UnitOfWork;
using RequestLogger.Entities;
using System;
using System.Linq;

namespace Service.LogginService
{
    public class BadRequestLogService : ILogService<BadRequestEntity>
    {
        private IUnitOfWork DataBase { get; }

        public BadRequestLogService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }
        public IQueryable<BadRequestEntity> GetLog()
        {
            return DataBase.BadRequestRepository.ReadAll();
        }

        public IQueryable<BadRequestEntity> GetLog(int number)
        {
            return DataBase.BadRequestRepository.ReadAll().Take(number);
        }

        public IQueryable<BadRequestEntity> GetLog(Func<BadRequestEntity, bool> predicate)
        {
            return DataBase.BadRequestRepository.ReadAll(predicate);
        }
    }
}
