﻿namespace PocomanReview.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<ReviewModel> Reviews { get; set; }
        
        public ICollection<PokemonOwnerModel> PokemonOwner { get; set; } = new List<PokemonOwnerModel>();

        public ICollection<PokemonCategoryModel> PokemonCategory { get; set; }

    }
}
