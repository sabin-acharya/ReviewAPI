using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class OwnerRepo : RepositoryRepo<OwnerModel>, IOwnerRepo
    {
        private readonly ApplicationDbContext _context;
        public OwnerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
