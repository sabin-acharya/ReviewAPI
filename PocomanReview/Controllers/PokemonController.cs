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
            if(!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(pokemon);
        }
    }
}
