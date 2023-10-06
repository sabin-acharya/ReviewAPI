using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
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
