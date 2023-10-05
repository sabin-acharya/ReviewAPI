using PocomanReview.Data;
using PocomanReview.Models;
using PocomanReview.Repositary.Interface;
using Shopping.Repository.Class;

namespace PocomanReview.Repositary.Class
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
