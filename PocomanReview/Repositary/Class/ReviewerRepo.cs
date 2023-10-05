using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
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
