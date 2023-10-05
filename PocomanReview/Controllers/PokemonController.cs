using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocomanReview.Repositary.Interface;

namespace PocomanReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        public PokemonController(IUnitOfWorkRepo unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult GetPokemon()
        {
            var pokemon = _unitofwork.Pokemon.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(pokemon);
        }

        [HttpGet("Id")]
        public IActionResult GetPokemonById(int id)
        {
            var pokemon = _unitofwork.Pokemon.GetT(x => x.Id == id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(pokemon);
        }

        [HttpGet("Id/rating")]
        public IActionResult Getrating(int id) 
        {
            var rating = _unitofwork.Pokemon.GetRating(id);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(rating);
        }
    }
}
