using MoviesReview.Data;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;
using MoviesReview.Repository.Class;

namespace MoviesReview.Repositary.Class
{
    public class CountryRepo : RepositoryRepo<CountryModel>, ICountryRepo
    {
        private readonly ApplicationDbContext _context;
        public CountryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

      
    }
}
