using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
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
