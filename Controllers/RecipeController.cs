using AutoMapper;
using comp306_group7_recipevault.Models;
using comp306_group7_recipevault.Repository;
using Microsoft.AspNetCore.Mvc;

namespace comp306_group7_recipevault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        // GET: api/recipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetAllRecipes()
        {
            var recipes = await _recipeRepository.GetAllRecipesAsync();
            var recipeDTOs = _mapper.Map<IEnumerable<RecipeDTO>>(recipes);

            return Ok(recipeDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDetailDTO>> GetRecipeById(string id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
                return NotFound();

            var recipeDetailDTO = _mapper.Map<RecipeDetailDTO>(recipe);
            return Ok(recipeDetailDTO);
        }

        // POST: api/recipe
        [HttpPost]
        public async Task<ActionResult> CreateRecipe([FromBody] RecipeCreateDTO recipeCreateDTO)
        {
            var recipe = _mapper.Map<Recipe>(recipeCreateDTO);
            await _recipeRepository.CreateRecipeAsync(recipe);

            var recipeDetailDTO = _mapper.Map<RecipeDetailDTO>(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipeDetailDTO);
        }

        // PUT: api/recipe/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRecipe(string id, [FromBody] RecipeCreateDTO recipeCreateDTO)
        {
            var existingRecipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (existingRecipe == null)
                return NotFound();

            _mapper.Map(recipeCreateDTO, existingRecipe);
            existingRecipe.RecipeId = id; 

            await _recipeRepository.UpdateRecipeAsync(existingRecipe);
            return NoContent();
        }

        // DELETE: api/recipe/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecipe(string id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
                return NotFound();

            await _recipeRepository.DeleteRecipeAsync(id);
            return NoContent();
        }

        [HttpPatch("update-category")]
        public async Task<ActionResult> UpdateCategoryForRecipes([FromBody] UpdateRecipeDTO request)
        {
            if (request.RecipeIds == null || request.RecipeIds.Count == 0)
            {
                return BadRequest("Recipe IDs cannot be empty.");
            }

            foreach (var recipeId in request.RecipeIds)
            {
                var existingRecipe = await _recipeRepository.GetRecipeByIdAsync(recipeId);
                if (existingRecipe == null)
                {
                    return NotFound($"Recipe with ID {recipeId} not found.");
                }

                existingRecipe.CategoryId = request.CategoryId;
                await _recipeRepository.UpdateRecipeAsync(existingRecipe);
            }

            return NoContent();
        }
    }
}
