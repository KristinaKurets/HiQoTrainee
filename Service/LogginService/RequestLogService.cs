using Repository.UnitOfWork;
using RequestLogger.Entities;
using System;
using System.Linq;

namespace Service.LogginService
{
    public class RequestLogService : ILogService<RequestProcessingEntity>
    {
        private IUnitOfWork DataBase { get; }

        public RequestLogService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }

        public IQueryable<RequestProcessingEntity> GetLog()
        {
            return DataBase.RequestProccessingRepository.ReadAll();
        }

        public IQueryable<RequestProcessingEntity> GetLog(int number)
        {
            return DataBase.RequestProccessingRepository.ReadAll().Take(number);
        }

        public IQueryable<RequestProcessingEntity> GetLog(Func<RequestProcessingEntity, bool> predicate)
        {
            return DataBase.RequestProccessingRepository.ReadAll(predicate);
        }
    }
}
