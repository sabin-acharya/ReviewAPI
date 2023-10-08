using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repository.Interface;
using System.Linq.Expressions;
using System.Reflection;

namespace MoviesReview.Repository.Class
{
    public class RepositoryRepo<T> : IRepositoryRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
       

        public RepositoryRepo(ApplicationDbContext context)
        {
            IMapper _mapper;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
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

        decimal IRepositoryRepo<T>.GetRating(int entityId)
        {
            var review = _context.Reviews.ToList();
            if(review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());

        }
        void IRepositoryRepo<T>.Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            
        }
    }
}
