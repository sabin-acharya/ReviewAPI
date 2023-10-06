using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class PokemonOwnerRepo : RepositoryRepo<PokemonOwnerModel>, IPokemonOwnerRepo
    {
        private readonly ApplicationDbContext _context;
        public PokemonOwnerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
