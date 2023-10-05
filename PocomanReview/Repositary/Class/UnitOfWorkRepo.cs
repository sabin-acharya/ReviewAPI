using PocomanReview.Data;


using PocomanReview.Migrations;
using PocomanReview.Repositary.Interface;

using PocomanReview.Repositary.Class;

namespace Shopping.Repository.Class
{
    public class UnitOfWorkRepo : IUnitOfWorkRepo
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepo Category { get; private set; }

        public ICountryRepo Country { get; private set; }

        public IOwnerRepo Owner { get; private set; }

        public IPokemonCategoryRepo PokemonCategory { get; private set; }

        public IPokemonOwnerRepo PokemonOwner { get; private set; }

        public IReviewerRepo Reviewers { get; private set; }
        public IReviewRepo Reviews { get; private set; }

        public IPokemonRepo Pokemon { get; private set; }

        

        public UnitOfWorkRepo(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepo(context);
            Country = new CountryRepo(context);
            Owner = new OwnerRepo(context);
            PokemonCategory = new PokemonCategoryRepo(context);
            Reviewers = new ReviewerRepo(context);
            Reviews = new ReviewRepo(context);
            Pokemon = new PokemonRepo(context);
            PokemonOwner = new PokemonOwnerRepo(context);



        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
