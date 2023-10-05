using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
{
    public class PokemonCategoryRepo : RepositoryRepo<PokemonCategoryModel>, IPokemonCategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public PokemonCategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
