using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
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
