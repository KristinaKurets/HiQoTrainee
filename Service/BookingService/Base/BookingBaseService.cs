using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.Base
{
    class BookingBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BookingBaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
