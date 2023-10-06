using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class PokemonRepo : RepositoryRepo<PokemonModel>, IPokemonRepo
    {
        private readonly ApplicationDbContext _context;
        public PokemonRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
