using Microsoft.EntityFrameworkCore;
using PocomanReview.Data;
using Shopping.Repository.Interface;
using System.Linq.Expressions;
using System.Reflection;

namespace Shopping.Repository.Class
{
    public class RepositoryRepo<T> : IRepositoryRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryRepo(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet?.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

       
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public T GetT(Expression<Func<T, bool>>? predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }

        decimal IRepositoryRepo<T>.GetRating(int id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                return 0;
            }

            decimal averageRating = 0;

            // Assume your entity has a property named 'Rating' of type decimal
            PropertyInfo ratingProperty = typeof(T).GetProperty("Rating");

            if (ratingProperty != null && ratingProperty.PropertyType == typeof(decimal))
            {
                var ratings = _context.Set<T>().Select(e => (decimal)ratingProperty.GetValue(e));

                if (ratings.Any())
                {
                    averageRating = ratings.Average();
                }
            }

            return averageRating;
        }

        void IRepositoryRepo<T>.Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
