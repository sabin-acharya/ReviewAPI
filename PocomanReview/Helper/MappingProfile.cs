using AutoMapper;
using MoviesReview.DTO;
using MoviesReview.Models;

namespace MoviesReview.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        
        {
            CreateMap<PokemonModel, PokemonDTO>();
            CreateMap<CountryModel, CountryDTO>();
            CreateMap<ReviewModel, ReviewDTO>();
            CreateMap<ReviewerModel, ReviewerDTO>();
            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<OwnerModel, OwnerDTO>();
            
            
        }
       
    }
}
