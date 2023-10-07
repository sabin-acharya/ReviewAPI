using AutoMapper;
using MoviesReview.DTO;
using MoviesReview.Models;

namespace MoviesReview.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        
        {

            // Mapping the ones values to another and vice  versa
            CreateMap<PokemonModel, PokemonDTO>();
            CreateMap<PokemonDTO, PokemonModel>();

            CreateMap<CountryModel, CountryDTO>();
            CreateMap<CountryDTO, CountryModel>();

            CreateMap<ReviewModel, ReviewDTO>();
            CreateMap<ReviewDTO, ReviewModel>();

            CreateMap<ReviewerModel, ReviewerDTO>();
            CreateMap<ReviewerDTO, ReviewerModel>();
            

            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<CategoryDTO, CategoryModel>();

            CreateMap<OwnerModel, OwnerDTO>();
            CreateMap<OwnerDTO, OwnerModel>();
            
            
        }
       
    }
}
