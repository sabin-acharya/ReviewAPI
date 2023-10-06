using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class ReviewerRepo : RepositoryRepo<ReviewerModel>, IReviewerRepo
    {
        private readonly ApplicationDbContext _context;
        public ReviewerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
