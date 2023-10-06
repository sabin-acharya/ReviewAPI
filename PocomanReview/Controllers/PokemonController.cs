﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;
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
            var pokemon = _mapper.Map<List<PokemonDTO>>(_unitofwork.Pokemon.GetT(x => x.Id == id));
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
