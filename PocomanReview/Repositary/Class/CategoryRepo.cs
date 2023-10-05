using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
{
    public class CategoryRepo : RepositoryRepo<CategoryModel>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

    }
}
