using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;
using MoviesReview.Repositary.Interface;

namespace MoviesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        private readonly IMapper _mapper;
        public CountryController(IUnitOfWorkRepo unitofwork, IMapper Mapper)
        {
            _unitofwork = unitofwork;
            _mapper = Mapper;
        }

        [HttpGet]
        public IActionResult GetCountry()
        {
            var country = _mapper.Map<List<CountryDTO>>(_unitofwork.Country.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(country);
        }

        [HttpGet("Id")]
        public IActionResult GetCategoryById(int id)
        {
            var country = _mapper.Map<List<CountryDTO>>(_unitofwork.Country.GetT(x => x.Id == id));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(country);
        }

       
    }
}
