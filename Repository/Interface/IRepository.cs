using Microsoft.EntityFrameworkCore;

namespace Repository.Interface
{
    public interface IRepository<TSource> where TSource : class
    {
        TSource Read(int id);
        TSource Create(TSource item);
        DbSet<TSource> GetDbSet();

    }
}
