namespace PocomanReview.Repositary.Interface
{
    public interface IUnitOfWorkRepo
    {
        ICategoryRepo Category { get; }
        IPokemonRepo Pokemon { get; }
        IReviewRepo Reviews { get; }

        IReviewerRepo Reviewers { get; }

        ICountryRepo Country { get; }

        IPokemonCategoryRepo PokemonCategory { get; }
        IPokemonOwnerRepo PokemonOwner { get; }
        IOwnerRepo Owner { get; }
        void Save();
    }
}
