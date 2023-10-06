﻿namespace MoviesReview.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<PokemonCategoryModel> PokemonCategory { get; set; }
    }
}
