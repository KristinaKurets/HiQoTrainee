using Repository.UnitOfWork;

namespace Service.BookingService.Base
{
    public class BookingBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BookingBaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
