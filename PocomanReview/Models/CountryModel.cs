﻿namespace PocomanReview.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OwnerModel> Owner { get; set; }

    }
}
