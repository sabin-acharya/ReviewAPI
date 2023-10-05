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
            T entity = _dbSet.Find(id);

            if (entity == null)
            {
                throw new InvalidOperationException($"Entity with ID {id} not found.");
            }

            // Replace 'RatingProperty' with the actual property name for the rating in TEntity
            PropertyInfo ratingProperty = typeof(T).GetProperty("RatingProperty");

            if (ratingProperty == null || ratingProperty.PropertyType != typeof(decimal))
            {
                throw new InvalidOperationException($"Entity of type {typeof(T)} does not have a valid 'RatingProperty'.");
            }

            return (decimal)ratingProperty.GetValue(entity);
        }

        void IRepositoryRepo<T>.Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
