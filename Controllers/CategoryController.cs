using AutoMapper;
using comp306_group7_recipevault.Models;
using comp306_group7_recipevault.Repository;
using Microsoft.AspNetCore.Mvc;

namespace comp306_group7_recipevault.Controllers
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
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);
            return Ok(categoryDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            var categoryDetailDTO = _mapper.Map<CategoryDetailDTO>(category);
            return Ok(categoryDetailDTO);
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetCategoryDropdown()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryListDTOs = _mapper.Map<List<CategoryListDTO>>(categories);
            return Ok(categoryListDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            category.CategoryId = Guid.NewGuid().ToString(); 
            await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(string id, [FromBody] CreateCategoryDTO createCategoryDTO)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            _mapper.Map(createCategoryDTO, existingCategory);
            await _categoryRepository.UpdateCategoryAsync(existingCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            await _categoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
