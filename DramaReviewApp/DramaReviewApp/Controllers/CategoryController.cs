using AutoMapper;
using DramaReviewApp.Dto;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DramaReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("drama/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Drama>))]
        [ProducesResponseType(400)]
        public IActionResult GetDramaByCategoryId(int categoryId)
        {
            var dramas = _mapper.Map<List<DramaDto>>(
                _categoryRepository.GetDramaByCategory(categoryId));
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(dramas);
        }


    }
}
