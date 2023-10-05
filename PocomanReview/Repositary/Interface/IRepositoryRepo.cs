using System.Linq.Expressions;

namespace Shopping.Repository.Interface
{

    public interface IRepositoryRepo<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        T GetT(Expression<Func<T, bool>>? predicate, string? includeProperties = null);

        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);

        decimal GetRating(int id);
    }


}
