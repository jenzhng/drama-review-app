using AutoMapper;
using DramaReviewApp.Dto;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DramaReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DramaController : Controller
    {
        private readonly IDramaRepository _dramaRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public DramaController(IDramaRepository dramaRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _dramaRepository = dramaRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Drama>))]

        public IActionResult GetDramas()
        {
            var dramas = _mapper.Map<List<DramaDto>>(_dramaRepository.GetDramas());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dramas);
        }

        [HttpGet("{dramaId}")]
        [ProducesResponseType(200, Type = typeof(Drama))]
        [ProducesResponseType(400)]
        public IActionResult GetDrama(int dramaId)
        {
            if (!_dramaRepository.DramaExists(dramaId))
                return NotFound();

            var drama = _mapper.Map<DramaDto>(_dramaRepository.GetDrama(dramaId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(drama);
        }
        [HttpGet("{dramaId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetDramaRating(int dramaId)
        {
            if (!_dramaRepository.DramaExists(dramaId))
                return NotFound();

            var rating = _dramaRepository.GetDramaRating(dramaId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);

        }

        [HttpPut("{dramaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDrama(int dramaId,
          [FromQuery] int directorId, [FromQuery] int catId,
          [FromBody] DramaDto updatedDrama)
        {
            if (updatedDrama == null)
                return BadRequest(ModelState);

            if (dramaId != updatedDrama.Id)
                return BadRequest(ModelState);

            if (!_dramaRepository.DramaExists(dramaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var dramaMap = _mapper.Map<Drama>(updatedDrama);

            if (!_dramaRepository.UpdateDrama(directorId, catId, dramaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDrama([FromQuery] int directorId, [FromQuery] int catId, [FromBody] DramaDto dramaCreate)
        {
            if (dramaCreate == null)
                return BadRequest(ModelState);

            var dramas = _dramaRepository.GetDramas()
                .Where(c => c.Title.Trim().ToUpper() == dramaCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (dramas != null)
            {
                ModelState.AddModelError("", "Director already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dramaMap = _mapper.Map<Drama>(dramaCreate);


            if (!_dramaRepository.CreateDrama(directorId, catId, dramaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}
