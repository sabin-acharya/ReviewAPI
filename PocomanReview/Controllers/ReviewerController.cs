using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesReview.DTO;
using MoviesReview.Repositary.Interface;

namespace MoviesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        private readonly IMapper _mapper;
        public ReviewerController(IUnitOfWorkRepo unitofwork, IMapper Mapper)
        {
            _unitofwork = unitofwork;
            _mapper = Mapper;
        }

        [HttpGet]
        public IActionResult GetReviewer()
        {
            var reviewer = _mapper.Map<List<ReviewerDTO>>(_unitofwork.Reviewers.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return Ok(reviewer);
        }

        [HttpGet("Id")]
        public IActionResult GetReviewersById(int id)
        {
            var reviewer = _mapper.Map<List<ReviewerDTO>>(_unitofwork.Reviewers.GetT(x => x.Id == id));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(reviewer);
        }

    }
}
