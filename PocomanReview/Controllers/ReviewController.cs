using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;
using MoviesReview.Repositary.Interface;

namespace MoviesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        private readonly IMapper _mapper;
        public ReviewController(IUnitOfWorkRepo unitofwork, IMapper Mapper)
        {
            _unitofwork = unitofwork;
            _mapper = Mapper;
        }

        [HttpGet]
        public IActionResult GetReview()
        {
            var review = _mapper.Map<List<ReviewDTO>>(_unitofwork.Reviews.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(review);
        }

        [HttpGet("Id")]
        public IActionResult GetReviewById(int id)
        {
            var review = _mapper.Map<List<ReviewDTO>>(_unitofwork.Reviews.GetT(x => x.Id == id));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(review);
        }

    }
}
