using AutoMapper;
using DramaReviewApp.Dto;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DramaReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepository directorRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        public IActionResult GetDirectors()
        {
            var directors = _mapper.Map<List<DirectorDto>>(_directorRepository.GetDirectors());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(directors);
        }

        [HttpGet("{directorId}")]
        [ProducesResponseType(200, Type = typeof(Director))]
        [ProducesResponseType(400)]
        public IActionResult GetDirector(int directorId)
        {
            if (!_directorRepository.DirectorExists(directorId))
                return NotFound();

            var director = _mapper.Map<DirectorDto>(_directorRepository.GetDirector(directorId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(director);
        }
        [HttpGet("{directorId}/drama")]
        [ProducesResponseType(200, Type = typeof(Director))]
        [ProducesResponseType(400)]
        public IActionResult GetDramaByDirector(int directorId)
        {
            if (!_directorRepository.DirectorExists(directorId))
            {
                return NotFound();
            }

            var director = _mapper.Map<List<DramaDto>>(
                _directorRepository.GetDramaByDirector(directorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(director);

        }
    }
}
