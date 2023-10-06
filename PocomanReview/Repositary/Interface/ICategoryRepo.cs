using MoviesReview.Models;
using MoviesReview.Repository.Interface;

namespace MoviesReview.Repositary.Interface
{
    
        public interface ICategoryRepo : IRepositoryRepo<CategoryModel>
        {
        ICollection<PokemonModel> GetPokemonByCategory(int categoryId);
        }
    
}
