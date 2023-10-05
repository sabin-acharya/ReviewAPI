using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
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
