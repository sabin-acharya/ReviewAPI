using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesReview.DTO;
using MoviesReview.Models;
using MoviesReview.Repositary.Interface;

namespace MoviesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        private readonly IMapper _mapper;
        public PokemonController(IUnitOfWorkRepo unitofwork, IMapper Mapper)
        {
            _unitofwork = unitofwork;
            _mapper = Mapper;
        }

        [HttpGet]
        public IActionResult GetPokemon()
        {
            var pokemon = _mapper.Map<List<PokemonDTO>>(_unitofwork.Pokemon.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(pokemon);
        }

        [HttpGet("Id")]
        public IActionResult GetPokemonById(int id)
        {
            var pokemonModel = _unitofwork.Pokemon.GetT(x => x.Id == id);
            if (pokemonModel == null)
            {
                return NotFound();
            }

            var pokemonDTO = _mapper.Map<PokemonDTO>(pokemonModel);

            return Ok(pokemonDTO);
        }

        [HttpGet("Id/rating")]
        public IActionResult Getrating(int id)
        {
            var rating = _unitofwork.Pokemon.GetRating(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(rating);
        }

        [HttpPost]
        public IActionResult CreatePokemon(PokemonDTO pdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pokemon = _unitofwork.Pokemon.GetAll().Where(x=>x.Id == pdto.Id).FirstOrDefault();

            if (pokemon != null)
            {
                ModelState.AddModelError("", "Already exist");
                return StatusCode(422, ModelState);
            }
            var pdtomap = _mapper.Map<PokemonModel>(pdto);
            _unitofwork.Pokemon.Add(pdtomap);
            _unitofwork.Save();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error while saiving the data");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpPut("Id")]
        public IActionResult EditPokemon(PokemonDTO pdto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pokemon = _unitofwork.Pokemon.GetT(x => x.Id == id);
            if (pokemon != null)
            {
                pokemon.Name = pdto.Name;
                pokemon.BirthDate = pdto.BirthDate;
            }
            _unitofwork.Pokemon.Update(pokemon);
            _unitofwork.Save();

            if (pokemon == null)
            {
                ModelState.AddModelError("", "Doesn't exist");
                return StatusCode(422, ModelState);
            }
            var pdtomap = _mapper.Map<PokemonDTO>(pokemon);
           
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error while saiving the data");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePokemon(int id)
        {
            var pokemon = _unitofwork.Pokemon.GetT(x => x.Id == id);

            if (pokemon == null)
            {
                return NotFound("Pokemon with the specified ID does not exist.");
            }

            _unitofwork.Pokemon.Delete(pokemon);
            
            _unitofwork.Save();
            return Ok();
        }

    }
}
