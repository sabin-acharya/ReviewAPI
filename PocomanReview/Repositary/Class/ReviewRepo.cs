using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class ReviewRepo : RepositoryRepo<ReviewModel>, IReviewRepo
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
