using Microsoft.EntityFrameworkCore;
using PocomanReview.Models;

namespace PocomanReview.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<PokemonModel> Pokemons { get; set; }

        public DbSet<CategoryModel> Categorys { get; set; }

        public DbSet<CountryModel> Countrys { get; set; }
        public DbSet<OwnerModel> Owners { get; set; }

        public DbSet<PokemonCategoryModel> PokemonCategorys { get; set; }
        public DbSet<PokemonOwnerModel> PokemonOwners { get; set; }

        public DbSet<ReviewModel> Reviews { get; set; }

        public DbSet<ReviewerModel> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<PokemonCategoryModel>()

               .HasKey(PC => new { PC.CategoryId, PC.PokemonId });

            Builder.Entity<PokemonCategoryModel>()
                .HasOne(P => P.Pokemon)
                .WithMany(PC => PC.PokemonCategory)
                .HasForeignKey(P => P.PokemonId);

            Builder.Entity<PokemonCategoryModel>()
               .HasOne(C => C.Category)
               .WithMany(PC => PC.PokemonCategory)
               .HasForeignKey(C => C.CategoryId);



            // PokemonOwner

            Builder.Entity<PokemonOwnerModel>()
                 .HasKey(PO => new { PO.OwnerId, PO.PokemonId });

            Builder.Entity<PokemonOwnerModel>()
                .HasOne(P => P.Pokemon)
                .WithMany(PC => PC.PokemonOwner)
                .HasForeignKey(P => P.PokemonId);

            Builder.Entity<PokemonOwnerModel>()
               .HasOne(O => O.Owner)
               .WithMany(PC => PC.PokemonOwners)
               .HasForeignKey(O => O.OwnerId);

            
        }



    }
}
