using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;
using MoviesReview.Repositary.Interface;

namespace MoviesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        private readonly IMapper _mapper;
        public OwnerController(IUnitOfWorkRepo unitofwork, IMapper Mapper)
        {
            _unitofwork = unitofwork;
            _mapper = Mapper;
        }

        [HttpGet]
        public IActionResult GetOwner()
        {
            var owner= _mapper.Map<List<OwnerDTO>>(_unitofwork.Owner.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(owner);
        }

        [HttpGet("Id")]
        public IActionResult GetOwnerById(int id)
        {
            var owner = _mapper.Map<List<OwnerDTO>>(_unitofwork.Owner.GetT(x => x.Id == id));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(owner);
        }

    }
}
