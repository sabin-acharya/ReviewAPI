using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;

namespace MoviesReview.Controllers
{
    public class PokemonMVCController : Controller
    {
        public IActionResult Index()
        {
            PokemonDTO pokemon = new PokemonDTO();

            return View(pokemon);
        }
    }
}
