using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class CategoryRepo : RepositoryRepo<CategoryModel>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public ICollection<PokemonModel> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategorys.Where(x => x.CategoryId == categoryId).Select(x=>x.Pokemon).ToList();
        }
    }
}
