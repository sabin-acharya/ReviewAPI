using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;
using MoviesReview.Repositary.Interface;

namespace MoviesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWorkRepo unitofwork, IMapper Mapper)
        {
            _unitofwork = unitofwork;
            _mapper = Mapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var categroy = _mapper.Map<List<CategoryDTO>>(_unitofwork.Category.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(categroy);
        }

        [HttpGet("Id")]
        public IActionResult GetCategoryById(int id)
        {

            var category = _mapper.Map<List<CategoryDTO>>(_unitofwork.Category.GetT(x => x.Id == id));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(category);
        }

        [HttpGet("categoryId")]
        public IActionResult GetPokemonByCategory(int categoryId) 
        {
            var pokemonbycategory = _mapper.Map<List<PokemonDTO>>(_unitofwork.Category.GetPokemonByCategory(categoryId));
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(pokemonbycategory);
        }
    }
}
